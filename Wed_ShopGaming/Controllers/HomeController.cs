using System.Linq;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.ViewModels;
using PagedList;
using Wed_ShopGaming.Models.Entity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.EnterpriseServices.CompensatingResourceManager;

namespace Wed_ShopGaming.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;

        public HomeController()
        {
            context = ApplicationDbContext.Create();


        }
        public ActionResult Index()
        {


            PagingSPViewModel model = new PagingSPViewModel();
            HinhAnhMainViewModel hinhAnhMain = null;
            List<HinhAnhMainViewModel> LapTop = new List<HinhAnhMainViewModel>();
            List<HinhAnhMainViewModel> MayTinh = new List<HinhAnhMainViewModel>();
            List<HinhAnhMainViewModel> DanhChoBan = new List<HinhAnhMainViewModel>();
            List<HinhAnhMainViewModel> LinhKien = new List<HinhAnhMainViewModel>();
            if (model.page == 0 || model.page == null) model.page = 1;
            model.pageSize = 8;
            if (model.pageSize == 0) { model.pageSize = 1; }
            model.pageNumber = (model.page ?? 1);
            foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == true))
            {
                if (item.Amount != 0)
                {
                    hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    LapTop.Add(hinhAnhMain);
                }
            }
            MayTinh = new List<HinhAnhMainViewModel>();
            foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("MayTinh") == true))
            {
                if (item.Amount != 0)
                {
                    hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    MayTinh.Add(hinhAnhMain);
                }
                    
            }
            DanhChoBan = new List<HinhAnhMainViewModel>();
            foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == false && e.MayTinh.LoaiMT.Name.Contains("MayTinh") == false))
            {
                if (item.Amount != 0)
                {
                    hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    DanhChoBan.Add(hinhAnhMain);
                }
                    
            }
            LinhKien = new List<HinhAnhMainViewModel>();
            foreach (var item in context.SanPhams.ToList())
            {
                if (item.LinhKien != null)
                {
                    if (item.Amount != 0)
                    {
                        hinhAnhMain = new HinhAnhMainViewModel();
                        if (item.HinhAnhs.Count() != 0)
                        {
                            hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                        }
                        else
                        {
                            hinhAnhMain.img = "";
                        }
                        hinhAnhMain.sanPham = item;
                        LinhKien.Add(hinhAnhMain);
                    }
                       
                }
            }


            if (Session["page"] == null && Session["check"] == null)
            {
                model.LapTop = LapTop.ToPagedList((int)model.page, model.pageSize);
                model.MayTinh = MayTinh.ToPagedList((int)model.page, model.pageSize);
                model.DanhChoBan = DanhChoBan.ToPagedList((int)model.page, model.pageSize);
                model.LinhKien = LinhKien.ToPagedList((int)model.page, model.pageSize);
            }
            else
            {
                if ((int)Session["check"] == 1)
                {
                    model.LapTop = LapTop.ToPagedList((int)Session["page"], model.pageSize);
                    model.MayTinh = MayTinh.ToPagedList((int)model.page, model.pageSize);
                    model.DanhChoBan = DanhChoBan.ToPagedList((int)model.page, model.pageSize);
                    model.LinhKien = LinhKien.ToPagedList((int)model.page, model.pageSize);

                }
                if ((int)Session["check"] == 2)
                {
                    model.LapTop = LapTop.ToPagedList((int)model.page, model.pageSize);
                    model.MayTinh = MayTinh.ToPagedList((int)Session["page"], model.pageSize);
                    model.DanhChoBan = DanhChoBan.ToPagedList((int)model.page, model.pageSize);
                    model.LinhKien = LinhKien.ToPagedList((int)model.page, model.pageSize);

                }
                if ((int)Session["check"] == 3)
                {
                    model.LapTop = LapTop.ToPagedList((int)model.page, model.pageSize);
                    model.MayTinh = MayTinh.ToPagedList((int)model.page, model.pageSize);
                    model.DanhChoBan = DanhChoBan.ToPagedList((int)Session["page"], model.pageSize);
                    model.LinhKien = LinhKien.ToPagedList((int)model.page, model.pageSize);

                }
                if ((int)Session["check"] == 4)
                {
                    model.LapTop = LapTop.ToPagedList((int)model.page, model.pageSize);
                    model.MayTinh = MayTinh.ToPagedList((int)model.page, model.pageSize);
                    model.DanhChoBan = DanhChoBan.ToPagedList((int)model.page, model.pageSize);
                    model.LinhKien = LinhKien.ToPagedList((int)Session["page"], model.pageSize);

                }
            }
            if (User.Identity.IsAuthenticated)
            {
                var listgiohang = context.gioHangs.Where(e => e.UserId == User.Identity.GetUserId());
                List<GioHangViewModel> gioHangViewModel = new List<GioHangViewModel>();
                foreach (var item in listgiohang)
                {
                    GioHangViewModel temp = new GioHangViewModel()
                    {
                        sanPham = item.SanPham,
                        count = item.Count,
                    };
                    gioHangViewModel.Add(temp);
                }

                Session["GioHang"] = gioHangViewModel;
            }
            else
            {
                Session["GioHang"] = new List<GioHangViewModel>();
            }
            return View(model);
        }

        public ActionResult DanhSachSPCheck(int? page, int check)
        {
            List<HinhAnhMainViewModel> model = new List<HinhAnhMainViewModel>();
            if (page == 0 || page == null) page = 1;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            if (check == 1)
            {
                foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == true))
                {
                    HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    model.Add(hinhAnhMain);
                }
            }
            if (check == 2)
            {
                foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("MayTinh") == true))
                {
                    HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    model.Add(hinhAnhMain);
                }
            }
            if (check == 3)
            {
                foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == false || e.MayTinh.LoaiMT.Name.Contains("MayTinh") == true))
                {
                    HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    model.Add(hinhAnhMain);
                }
            }
            if (check == 4)
            {
                foreach (var item in context.SanPhams.ToList())
                {
                    if (item.LinhKien != null)
                    {
                        HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                        if (item.HinhAnhs.Count() != 0)
                        {
                            hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                        }
                        else
                        {
                            hinhAnhMain.img = "";
                        }
                        hinhAnhMain.sanPham = item;
                        model.Add(hinhAnhMain);
                    }
                }
            }
            Session["PagingSP"] = model.ToPagedList((int)page, pageSize);
            return RedirectToAction("DanhSachSP", "Home");
        }
        public ActionResult DanhSachSP()
        {
            IPagedList<HinhAnhMainViewModel> model;
            if (Session["PagingSP"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model = Session["PagingSP"] as IPagedList<HinhAnhMainViewModel>;
            }
            return View(model);
        }
        public ActionResult ChiTietSP(string id)
        {
            var model = context.SanPhams.FirstOrDefault(e => e.Id == id);
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public ActionResult AddGioHang(string id,string strURL)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var check = context.gioHangs.Where(e => e.UserId == userid);
                var sanPham = new SanPham();
                var giohang = new GioHang()
                {
                    UserId = User.Identity.GetUserId(),
                };
                if (check == null)
                {
                    Session["GioHang"] = new List<GioHangViewModel>();
                    sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                    GioHangViewModel item = new GioHangViewModel()
                    {
                        sanPham = sanPham,
                        count = 1,
                    };
                    giohang.Count = item.count;
                    (Session["GioHang"] as List<GioHangViewModel>).Add(item);
                }
                else if (check != null)
                {
                    List<GioHangViewModel> gioHangViewModel = new List<GioHangViewModel>();
                    foreach (var item in check)
                    {
                        GioHangViewModel temp = new GioHangViewModel()
                        {
                            sanPham = item.SanPham,
                            count = item.Count,
                        };
                        gioHangViewModel.Add(temp);
                    }
                    
                    Session["GioHang"] = gioHangViewModel;

                    GioHangViewModel item1 = (Session["GioHang"] as List<GioHangViewModel>).FirstOrDefault(e => e.sanPham.Id == id);
                    if (item1 != null)
                    {
                        item1.count++;
                        giohang.Count++;
                    }
                    else
                    {
                        sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                        GioHangViewModel temp = new GioHangViewModel()
                        {
                            sanPham = sanPham,
                            count = 1,
                        };
                        giohang.Count= temp.count;
                        (Session["GioHang"] as List<GioHangViewModel>).Add(temp);
                    }
                }
                giohang.SanPhamId = sanPham.Id;
                context.gioHangs.Add(giohang);
                context.SaveChanges();
            }
            else
            {
                if (Session["GioHang"] == null)
                {
                    Session["GioHang"] = new List<GioHangViewModel>();
                    var sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                    GioHangViewModel item = new GioHangViewModel()
                    {
                        sanPham = sanPham,
                        count = 1,
                    };
                    (Session["GioHang"] as List<GioHangViewModel>).Add(item);
                }
                else
                {
                    GioHangViewModel item = (Session["GioHang"] as List<GioHangViewModel>).FirstOrDefault(e => e.sanPham.Id == id);
                    if (item != null)
                    {
                        item.count++;
                    }
                    else
                    {
                        var sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                        GioHangViewModel giohang = new GioHangViewModel()
                        {
                            sanPham = sanPham,
                            count = 1,
                        };
                        (Session["GioHang"] as List<GioHangViewModel>).Add(giohang);
                    }
                }
            }
            return Redirect(strURL);
        }
        public double TongTienGioHang()
        {
            var gioHangs = Session["GioHang"] as List<GioHangViewModel>;
            double result = 0;
            if (gioHangs != null)
            {
                foreach (var item in gioHangs)
                {
                    result = item.sanPham.Price * item.count;
                }
            }
            return result;
        }
        public ActionResult ListGioHang()
        {
            if (User.Identity.IsAuthenticated)
            {
                var listgiohang = context.gioHangs.Where(e => e.UserId == User.Identity.GetUserId());
                List<GioHangViewModel> gioHangViewModel = new List<GioHangViewModel>();
                foreach (var item in listgiohang)
                {
                    GioHangViewModel temp = new GioHangViewModel()
                    {
                        sanPham = item.SanPham,
                        count = item.Count,
                    };
                    gioHangViewModel.Add(temp);
                }

                Session["GioHang"] = gioHangViewModel;
            }
            var gioHangs = Session["GioHang"] as List<GioHangViewModel>;
            ViewBag.TongTien = TongTienGioHang();
            List<HinhAnhMainViewModel> model = new List<HinhAnhMainViewModel>();
            if (gioHangs == null)
            {
                return View(model);
            }
            foreach(var item in gioHangs)
            {
                HinhAnhMainViewModel temp = new HinhAnhMainViewModel();
                temp.sanPham = item.sanPham;
                temp.img = item.sanPham.HinhAnhs.FirstOrDefault(e=>e.STT==0).Img;
                temp.count = item.count;
                model.Add(temp);
            }
            return View(model);
        }
        public ActionResult CheckOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                var gioHangs = Session["GioHang"] as List<GioHangViewModel>;
                ViewBag.TongTien = TongTienGioHang();
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
            return RedirectToAction("Login", "Account");
        }
        public ActionResult PageList(int page, int check) {
            Session["page"]  = page;
            Session["check"] = check;
            return RedirectToAction("Index", "Home");
        }
    }
}