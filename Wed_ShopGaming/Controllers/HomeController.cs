using System.Linq;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.ViewModels;
using Wed_ShopGaming.DTO;
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
            /*PagingSPViewModel model = new PagingSPViewModel();
            HinhAnhMainViewModel hinhAnhMain = null;
            List<HinhAnhMainViewModel> LapTop = new List<HinhAnhMainViewModel>();
            List<HinhAnhMainViewModel> MayTinh = new List<HinhAnhMainViewModel>();
            List<HinhAnhMainViewModel> DanhChoBan = new List<HinhAnhMainViewModel>();
            List<HinhAnhMainViewModel> LinhKien = new List<HinhAnhMainViewModel>();
            if (model.totalPage == 0)
            {
                if (model.page == 0 || model.page == null) model.page = 1;
                model.pageSize = 2;
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
            }*/
            return View();
        }
    }
}