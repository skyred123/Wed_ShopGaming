using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.ViewModels;

namespace Wed_ShopGaming.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        public ApplicationDbContext _dbContext { get; set; }
        public AccountController()
        {
            _dbContext =  ApplicationDbContext.Create();
        }
        // GET: Admin/Account
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            var user = userManager.Users.ToList();
            List<ListUserViewModel> model = new List<ListUserViewModel>();
            foreach (var item in user)
            {
                ListUserViewModel list = new ListUserViewModel();
                list.User = item;
                var roles = userManager.GetRoles(item.Id);
                list.NameRole = string.Join(",", roles);
                model.Add(list);
            }
            if(model == null)
            {
                ModelState.AddModelError("Error", "Error");
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(model);
        }
        public ActionResult Delete(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            ApplicationUser user = userManager.FindById(id);
            if (user == null)
            {
                ModelState.AddModelError("Error", "Error");
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            userManager.Delete(user);
            return RedirectToAction("Index", "Account", new { area = "Admin" });
        }
    }
}