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
                .HasMany(e => e.ThongSos)
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

            modelBuilder.Entity<ThongSo>()
                .HasMany(e => e.LinhKiens)
                .WithOptional(e => e.ThongSo)
                .HasForeignKey(e => e.IdThongSo);
        }
        public static ApplicationDbContext Create()
        {
            ApplicationDbContext dbContext= new ApplicationDbContext();
            /*dbContext.ThongSos.Include(e => e.LoaiSP).Load();
            dbContext.LoaiSPs.Include(e => e.ThongSos).Load();*/
            return dbContext;
        }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LinhKien> LinhKiens { get;set; }
        public DbSet<LoaiSP> LoaiSPs { get;set; }
        public DbSet<ThongSo> ThongSos { get;set; }
        public DbSet<CauHinh> CauHinhs { get;set; }
        public DbSet<MayTinh> MayTinhs { get;set; }
        public DbSet<HinhAnh> HinhAnhs { get;set; }
    }
}