using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CT_LinhKien>().HasKey(e=> new { e.IdLinhKien, e.IdMayTinh });
        }
        public static ApplicationDbContext Create()
        {
            ApplicationDbContext dbContext= new ApplicationDbContext();
            dbContext.ThongSos.Include(e => e.LoaiSP).Load();
            dbContext.LoaiSPs.Include(e => e.ThongSos).Load();
            return dbContext;
        }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LinhKien> LinhKiens { get;set; }
        public DbSet<LoaiSP> LoaiSPs { get;set; }
        public DbSet<ThongSo> ThongSos { get;set; }
        public DbSet<CauHinh> CauHinhs { get;set; }
        public DbSet<MayTinh> MayTinhs { get;set; }
        public DbSet<CT_LinhKien> CT_LinhKiens { get;set; }
        public DbSet<HinhAnh> HinhAnhs { get;set; }
    }
}