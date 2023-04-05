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
                    temp.img = item.sanPham.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    temp.count = item.count;
                    model.Add(temp);
                }
                return View(model);
            }
            return RedirectToAction("Login", "Account", strUrl);
        }
        public ActionResult ThanhToan(string payment)
        {
            var viewModel = Session["ThanhToan"] as List<HinhAnhMainViewModel>;
            if (viewModel != null && payment != null)
            {
                if (payment == "COD")
                {
                    double result = 0;
                    HoaDon hoaDon = new HoaDon() {
                        Id = Guid.NewGuid().ToString(),
                        UserId = User.Identity.GetUserId(),
                        Status = "Chua Thanh Toan",
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
                    context.HoaDons.Add(hoaDon);
                    context.CT_DHs.AddRange(dhList);
                    context.SaveChanges();
                    var userid = User.Identity.GetUserId();
                    var giohang = context.gioHangs.Where(e => e.UserId == userid);
                    context.gioHangs.RemoveRange(giohang);
                    context.SaveChanges();
                    RedirectToAction("ThanhToan", "ThanhToan");
                }
            }
            else if (payment == "MOMO")
            {
                return RedirectToAction("Payment", "ThanhToan");
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Payment()
        {
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "test";
            string returnUrl = "https://localhost:44370/ThanhToan/ThanhToanTC";
            string notifyurl = "https://4c8d-2001-ee0-5045-50-58c1-b2ec-3123-740d.ap.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

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
        public ActionResult ThanhToanTC()
        {
            return View();
        }


    }
}