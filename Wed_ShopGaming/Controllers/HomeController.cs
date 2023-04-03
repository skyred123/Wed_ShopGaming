using System.Linq;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.ViewModels;
using PagedList;
using Wed_ShopGaming.Models.Entity;
using System.Collections.Generic;

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
            MayTinh = new List<HinhAnhMainViewModel>();
            foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("MayTinh") == true))
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
            DanhChoBan = new List<HinhAnhMainViewModel>();
            foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == false && e.MayTinh.LoaiMT.Name.Contains("MayTinh") == true))
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
            LinhKien = new List<HinhAnhMainViewModel>();
            foreach (var item in context.SanPhams.ToList())
            {
                if (item.LinhKien != null)
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
                foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == false && e.MayTinh.LoaiMT.Name.Contains("MayTinh") == true))
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
            if (Session["GioHang"] == null)
            {
                Session["GioHang"] = new List<GioHang>();
                var sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                GioHang item = new GioHang() {
                    sanPham = sanPham,
                    count = 1,
                };
                (Session["GioHang"] as List<GioHang>).Add(item);
            }
            else
            {
                GioHang item = (Session["GioHang"] as List<GioHang>).FirstOrDefault(e=>e.sanPham.Id == id);
                if(item != null)
                {
                    item.count++;
                }
                else
                {
                    var sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                    GioHang giohang = new GioHang()
                    {
                        sanPham = sanPham,
                        count = 1,
                    };
                    (Session["GioHang"] as List<GioHang>).Add(giohang);
                }
            }
            return Redirect(strURL);
            
        }
        public ActionResult ListGioHang()
        {
            var gioHangs = Session["GioHang"] as List<GioHang>;
            
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
        public ActionResult PageList(int page, int check) {
            Session["page"]  = page;
            Session["check"] = check;
            return RedirectToAction("Index", "Home");
        }
    }
}