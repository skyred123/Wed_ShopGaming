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
                .HasMany(e => e.CT_LinhKiens)
                .WithOptional(e => e.LinhKien)
                .HasForeignKey(e => e.IdLinhKien);

            modelBuilder.Entity<MayTinh>()
                .HasMany(e => e.CT_LinhKiens)
                .WithOptional(e => e.MayTinh)
                .HasForeignKey(e => e.IdMayTinh);

            modelBuilder.Entity<LoaiLK>()
                .HasMany(e => e.LinhKiens)
                .WithOptional(e => e.LoaiLK)
                .HasForeignKey(e => e.IdLoaiLK);

            modelBuilder.Entity<LoaiMT>()
                .HasMany(e => e.MayTinh)
                .WithOptional(e => e.LoaiMT)
                .HasForeignKey(e => e.IdLoaiMT);


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
                .HasMany(e => e.CT_TSKTs)
                .WithOptional(e => e.LinhKien)
                .HasForeignKey(e => e.IdLinhKien);
            modelBuilder.Entity<TSKT>()
                .HasMany(e => e.CT_TSKTs)
                .WithOptional(e => e.TSKT)
                .HasForeignKey(e => e.IdTSKT);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.GioHangs)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<SanPham>()
                .HasMany(e=>e.GioHangs)
                .WithRequired(e=>e.SanPham) 
                .WillCascadeOnDelete(false);


        }
        public static ApplicationDbContext Create()
        {
            ApplicationDbContext dbContext= new ApplicationDbContext();
            dbContext.CauHinhs.Include(e => e.MayTinhs).Load();
            dbContext.CT_LinhKiens.Include(e=>e.MayTinh).Include(e=>e.LinhKien).Load();
            dbContext.CT_TSKTs.Include(e => e.TSKT).Include(e => e.LinhKien).Load();
            dbContext.Hangs.Include(e => e.SanPhams).Load();
            dbContext.HinhAnhs.Include(e => e.SanPham).Load();
            dbContext.LinhKiens.Include(e => e.SanPham).Include(e => e.CT_TSKTs).Include(e => e.LoaiLK).Include(e => e.CT_LinhKiens).Include(e=>e.SanPham).Load();
            dbContext.LoaiLKs.Include(e => e.LinhKiens).Load();
            dbContext.LoaiMTs.Include(e => e.MayTinh).Load();
            dbContext.MayTinhs.Include(e => e.SanPham).Include(e => e.CauHinh).Include(e => e.LoaiMT).Include(e=>e.CT_LinhKiens).Load();
            dbContext.SanPhams.Include(e => e.MayTinh).Include(e => e.LinhKien).Include(e => e.HinhAnhs).Include(e => e.Hang).Include(e => e.GioHangs).Load();
            dbContext.gioHangs.Include(e => e.SanPham).Include(e => e.User).Load();
            dbContext.TSKTs.Include(e => e.CT_TSKTs).Load();
            return dbContext;
        }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LinhKien> LinhKiens { get;set; }
        public DbSet<LoaiLK> LoaiLKs { get;set; }
        public DbSet<LoaiMT> LoaiMTs { get; set; }
        public DbSet<TSKT> TSKTs { get;set; }
        public DbSet<CauHinh> CauHinhs { get;set; }
        public DbSet<MayTinh> MayTinhs { get;set; }
        public DbSet<HinhAnh> HinhAnhs { get;set; }
        public DbSet<CT_TSKT> CT_TSKTs { get; set; }
        public DbSet<CT_LinhKien> CT_LinhKiens { get; set; }
        public DbSet<GioHang> gioHangs { get; set; }
    }
}