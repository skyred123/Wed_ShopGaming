using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.ViewModels;
using Wed_ShopGaming.Models.Entity;
using Newtonsoft.Json.Linq;
using Wed_ShopGaming.Others;

namespace Wed_ShopGaming.Controllers
{
    public class ThanhToanController : Controller
    {
        ApplicationDbContext context;

        public ThanhToanController()
        {
            context = ApplicationDbContext.Create();


        }
        // GET: ThanhToan
        public ActionResult CheckOut(string strUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                var gioHangs = Session["GioHang"] as List<GioHangViewModel>;
                ViewBag.TongTien = new HomeController().TongTienGioHang(gioHangs);
                var userid = User.Identity.GetUserId();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                ViewBag.User = userManager.FindById(userid);
                List<HinhAnhMainViewModel> model = new List<HinhAnhMainViewModel>();
                if (gioHangs == null)
                {
                    return View(model);
                }
                foreach (var item in gioHangs)
                {
                    HinhAnhMainViewModel temp = new HinhAnhMainViewModel();
                    temp.sanPham = item.sanPham;
                    if (item.sanPham.HinhAnhs.Count() != 0)
                    {
                        temp.img = item.sanPham.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        temp.img = "";
                    }
                   
                    temp.count = item.count;
                    model.Add(temp);
                }
                return View(model);
            }
            return RedirectToAction("Login", "Account", strUrl);
        }
        public ActionResult ThanhToan(string payment)
        {
            List<HinhAnhMainViewModel> viewModel = Session["ThanhToan"] as List<HinhAnhMainViewModel>;
            if (viewModel != null && payment != null)
            {
                if (payment == "COD")
                {
                    double result = 0;
                    HoaDon hoaDon = new HoaDon() {
                        Id = Guid.NewGuid().ToString(),
                        UserId = User.Identity.GetUserId(),
                        Status = "Chua Thanh Toan",
                        OrderStatus = "Cho Xac Nhan",
                    Payments = payment,
                    };
                    List<CT_DH> dhList = new List<CT_DH>(); 
                    foreach(var item in viewModel)
                    {
                        CT_DH cT_DH = new CT_DH();
                        cT_DH.SanPhamId = item.sanPham.Id;
                        cT_DH.HoaDonId = hoaDon.Id;
                        cT_DH.Amount = item.count.ToString();
                        cT_DH.Price = item.sanPham.Price.ToString();
                        result= result + (item.count * item.sanPham.Price);
                        dhList.Add(cT_DH);
                    }
                    hoaDon.Price = result.ToString();
                    hoaDon.DateTime= DateTime.Now;
                    context.HoaDons.Add(hoaDon);
                    context.CT_DHs.AddRange(dhList);
                    var userid = User.Identity.GetUserId();
                    var giohang = context.gioHangs.Where(e => e.UserId == userid);
                    context.gioHangs.RemoveRange(giohang);
                    context.SaveChanges();
                    RedirectToAction("ThanhToanTC", "ThanhToan", new { check = true });
                }
                else if (payment == "MOMO")
                {
                    return RedirectToAction("Payment", "ThanhToan", viewModel);
                }
            }
            return RedirectToAction("ThanhToanTC", "ThanhToan", new { check = false });
        }
        public ActionResult Payment()
        {
            List<HinhAnhMainViewModel> model = Session["ThanhToan"] as List<HinhAnhMainViewModel>;
            if (model == null)
            {
                return RedirectToAction("ThanhToanTC", "ThanhToan", new { check = false });
            }
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "Thanh Toan Mua Hang wed Shop Gaming: " + String.Format("{0:0,0}", model.Sum(e => e.count * e.sanPham.Price)) +"đ";
            string returnUrl = "https://localhost:44370/ThanhToan/ConfirmPaymentClient";
            string notifyurl = "https://4c8d-2001-ee0-5045-50-58c1-b2ec-3123-740d.ap.ngrok.io/ThanhToan/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = "1000";
            string orderid = DateTime.Now.Ticks.ToString(); //mã đơn hàng
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }
        public ActionResult ConfirmPaymentClient(MoMoViewModel model)
        {
            string rMessage = model.message;
            string rOrderId = model.orderId;
            string rErrorCode = model.errorCode; // = 0: thanh toán thành công
            string rmount = model.amount;
            if (model.errorCode =="0")
            {
                var viewModel = Session["ThanhToan"] as List<HinhAnhMainViewModel>;
                double result = 0;
                HoaDon hoaDon = new HoaDon()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = User.Identity.GetUserId(),
                    Status = "Da Thanh Toan",
                    OrderStatus = "Cho Xac Nhan",
                    Payments = "MOMO",
                };
                List<CT_DH> dhList = new List<CT_DH>();
                foreach (var item in viewModel)
                {
                    CT_DH cT_DH = new CT_DH();
                    cT_DH.SanPhamId = item.sanPham.Id;
                    cT_DH.HoaDonId = hoaDon.Id;
                    cT_DH.Amount = item.count.ToString();
                    cT_DH.Price = item.sanPham.Price.ToString();
                    result = result + (item.count * item.sanPham.Price);
                    dhList.Add(cT_DH);
                }
                hoaDon.Price = result.ToString();
                hoaDon.DateTime = DateTime.Now;
                context.HoaDons.Add(hoaDon);
                context.CT_DHs.AddRange(dhList);
                var userid = User.Identity.GetUserId();
                var giohang = context.gioHangs.Where(e => e.UserId == userid);
                context.gioHangs.RemoveRange(giohang);
                context.SaveChanges();
                return RedirectToAction("ThanhToanTC", "ThanhToan", new {check = true});
            }
            else
            {
                return RedirectToAction("ThanhToanTC", "ThanhToan", new { check = false });
            }
        }
        public ActionResult ThanhToanTC(bool check)
        {
            if(check)
            {
                Session["GioHang"] = new List<GioHangViewModel>();
                ViewBag.Message = "Thanh Toan Thanh Cong";
            }
            else
            {
                ViewBag.Message = "Thanh Toan Khong Thanh Cong";
            }
            return View();
        }
    }
}