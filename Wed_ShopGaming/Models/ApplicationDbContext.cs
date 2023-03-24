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
            modelBuilder.Entity<CauHinh>()
                .HasMany(e => e.MayTinhs)
                .WithOptional(e => e.CauHinh)
                .HasForeignKey(e => e.IdCH);

            modelBuilder.Entity<Hang>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.Hang)
                .HasForeignKey(e => e.IdHang);

            modelBuilder.Entity<LinhKien>()
                .HasMany(e => e.MayTinhs)
                .WithMany(e => e.LinhKiens)
                .Map(m => m.ToTable("CT_LinhKien").MapLeftKey("IdLinhKien").MapRightKey("IdMayTinh"));

            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.LinhKiens)
                .WithOptional(e => e.LoaiSP)
                .HasForeignKey(e => e.IdLoaiSP);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.HinhAnhs)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.IDSanPham);

            modelBuilder.Entity<SanPham>()
                .HasOptional(e => e.LinhKien)
                .WithRequired(e => e.SanPham);

            modelBuilder.Entity<SanPham>()
                .HasOptional(e => e.MayTinh)
                .WithRequired(e => e.SanPham);
            modelBuilder.Entity<LinhKien>()
                .HasMany(e => e.TSKTs)
                .WithMany(e => e.LinhKiens)
                .Map(m => m.ToTable("CT_TSKT").MapLeftKey("IdLinhKien").MapRightKey("IdTSKT"));
        }
        public static ApplicationDbContext Create()
        {
            ApplicationDbContext dbContext= new ApplicationDbContext();
            dbContext.CauHinhs.Include(e => e.MayTinhs).Load();
            dbContext.Hangs.Include(e => e.SanPhams).Load();
            dbContext.HinhAnhs.Include(e => e.SanPham).Load();
            dbContext.LinhKiens.Include(e => e.SanPham).Include(e => e.MayTinhs).Include(e => e.LoaiSP).Include(e => e.TSKTs).Load();
            dbContext.LoaiSPs.Include(e => e.LinhKiens).Load();
            dbContext.MayTinhs.Include(e => e.SanPham).Include(e => e.LinhKiens).Include(e => e.CauHinh).Load();
            dbContext.SanPhams.Include(e => e.MayTinh).Include(e => e.LinhKien).Include(e => e.HinhAnhs).Include(e => e.Hang).Load();
            return dbContext;
        }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LinhKien> LinhKiens { get;set; }
        public DbSet<LoaiSP> LoaiSPs { get;set; }
        public DbSet<TSKT> TSKTs { get;set; }
        public DbSet<CauHinh> CauHinhs { get;set; }
        public DbSet<MayTinh> MayTinhs { get;set; }
        public DbSet<HinhAnh> HinhAnhs { get;set; }
    }
}