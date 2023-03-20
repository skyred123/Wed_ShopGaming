using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
        public DbSet<DMSP> DMSPs { get;set; }
    }
}