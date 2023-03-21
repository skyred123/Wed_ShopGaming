using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ConnectionStrings", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<LinhKien> LinhKiens { get;set; }
        public DbSet<LoaiSP> LoaiSPs { get;set; }
        public DbSet<ThongSo> ThongSos { get;set; }
    }
}