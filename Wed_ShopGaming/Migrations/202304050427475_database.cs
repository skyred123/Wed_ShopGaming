﻿namespace Wed_ShopGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CauHinhs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MayTinhs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdCH = c.String(maxLength: 128),
                        IdLoaiMT = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SanPhams", t => t.Id)
                .ForeignKey("dbo.LoaiMTs", t => t.IdLoaiMT)
                .ForeignKey("dbo.CauHinhs", t => t.IdCH)
                .Index(t => t.Id)
                .Index(t => t.IdCH)
                .Index(t => t.IdLoaiMT);
            
            CreateTable(
                "dbo.CT_LinhKien",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        IdLinhKien = c.String(maxLength: 128),
                        IdMayTinh = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.LinhKiens", t => t.IdLinhKien)
                .ForeignKey("dbo.MayTinhs", t => t.IdMayTinh)
                .Index(t => t.IdLinhKien)
                .Index(t => t.IdMayTinh);
            
            CreateTable(
                "dbo.LinhKiens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdLoaiLK = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiLKs", t => t.IdLoaiLK)
                .ForeignKey("dbo.SanPhams", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.IdLoaiLK);
            
            CreateTable(
                "dbo.CT_TSKT",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        IdLinhKien = c.String(maxLength: 128),
                        IdTSKT = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TSKTs", t => t.IdTSKT)
                .ForeignKey("dbo.LinhKiens", t => t.IdLinhKien)
                .Index(t => t.IdLinhKien)
                .Index(t => t.IdTSKT);
            
            CreateTable(
                "dbo.TSKTs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoaiLKs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Long(nullable: false),
                        IdHang = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hangs", t => t.IdHang)
                .Index(t => t.IdHang);
            
            CreateTable(
                "dbo.CT_DH",
                c => new
                    {
                        SanPhamId = c.String(nullable: false, maxLength: 128),
                        HoaDonId = c.String(nullable: false, maxLength: 128),
                        Amount = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => new { t.SanPhamId, t.HoaDonId })
                .ForeignKey("dbo.HoaDons", t => t.HoaDonId)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamId)
                .Index(t => t.SanPhamId)
                .Index(t => t.HoaDonId);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Status = c.String(),
                        Payments = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Adress = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        SanPhamId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SanPhamId, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamId)
                .Index(t => t.SanPhamId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Hangs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HinhAnhs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        STT = c.Int(nullable: false),
                        Img = c.String(),
                        IDSanPham = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SanPhams", t => t.IDSanPham)
                .Index(t => t.IDSanPham);
            
            CreateTable(
                "dbo.LoaiMTs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MayTinhs", "IdCH", "dbo.CauHinhs");
            DropForeignKey("dbo.MayTinhs", "IdLoaiMT", "dbo.LoaiMTs");
            DropForeignKey("dbo.CT_LinhKien", "IdMayTinh", "dbo.MayTinhs");
            DropForeignKey("dbo.MayTinhs", "Id", "dbo.SanPhams");
            DropForeignKey("dbo.LinhKiens", "Id", "dbo.SanPhams");
            DropForeignKey("dbo.HinhAnhs", "IDSanPham", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "IdHang", "dbo.Hangs");
            DropForeignKey("dbo.GioHangs", "SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.CT_DH", "SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HoaDons", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GioHangs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CT_DH", "HoaDonId", "dbo.HoaDons");
            DropForeignKey("dbo.LinhKiens", "IdLoaiLK", "dbo.LoaiLKs");
            DropForeignKey("dbo.CT_TSKT", "IdLinhKien", "dbo.LinhKiens");
            DropForeignKey("dbo.CT_TSKT", "IdTSKT", "dbo.TSKTs");
            DropForeignKey("dbo.CT_LinhKien", "IdLinhKien", "dbo.LinhKiens");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.HinhAnhs", new[] { "IDSanPham" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.GioHangs", new[] { "UserId" });
            DropIndex("dbo.GioHangs", new[] { "SanPhamId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.HoaDons", new[] { "UserId" });
            DropIndex("dbo.CT_DH", new[] { "HoaDonId" });
            DropIndex("dbo.CT_DH", new[] { "SanPhamId" });
            DropIndex("dbo.SanPhams", new[] { "IdHang" });
            DropIndex("dbo.CT_TSKT", new[] { "IdTSKT" });
            DropIndex("dbo.CT_TSKT", new[] { "IdLinhKien" });
            DropIndex("dbo.LinhKiens", new[] { "IdLoaiLK" });
            DropIndex("dbo.LinhKiens", new[] { "Id" });
            DropIndex("dbo.CT_LinhKien", new[] { "IdMayTinh" });
            DropIndex("dbo.CT_LinhKien", new[] { "IdLinhKien" });
            DropIndex("dbo.MayTinhs", new[] { "IdLoaiMT" });
            DropIndex("dbo.MayTinhs", new[] { "IdCH" });
            DropIndex("dbo.MayTinhs", new[] { "Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LoaiMTs");
            DropTable("dbo.HinhAnhs");
            DropTable("dbo.Hangs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.GioHangs");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.HoaDons");
            DropTable("dbo.CT_DH");
            DropTable("dbo.SanPhams");
            DropTable("dbo.LoaiLKs");
            DropTable("dbo.TSKTs");
            DropTable("dbo.CT_TSKT");
            DropTable("dbo.LinhKiens");
            DropTable("dbo.CT_LinhKien");
            DropTable("dbo.MayTinhs");
            DropTable("dbo.CauHinhs");
        }
    }
}
