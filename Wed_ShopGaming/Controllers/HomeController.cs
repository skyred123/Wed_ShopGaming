using System.Linq;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.ViewModels;
using Wed_ShopGaming.DTO;
using PagedList;
using Wed_ShopGaming.Models.Entity;

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
            if (PageDTO.paging == null)
            {
                model = new PagingSPViewModel();
                if (model.page == 0) model.page = 1;
                model.pageSize = 9;
                if (model.pageSize == 0) { model.pageSize = 1; }
                model.pageNumber = (model.page ?? 1);
                if (model.totalPage ==0)
                {
                    model.LapTop = context.MayTinhs.Where(e => e.LoaiMT.Name.Contains("LapTop") == true).ToList();
                    model.MayTinh = context.MayTinhs.Where(e => e.LoaiMT.Name.Contains("MayTinh") == true).ToList();
                    model.DanhChoBan = context.MayTinhs.Where(e => e.LoaiMT.Name.Contains("LapTop") == false && e.LoaiMT.Name.Contains("MayTinh") == false).ToList();
                    model.LinhKien = context.LinhKiens.ToList();
                }
            }
            return View(model);

        }
        /*[HttpPost]
        public ActionResult LapTop_Partial(int? page)
        {

            return RedirectToAction("Index", "Home", new {id = 9999});
        }*/
    }
}