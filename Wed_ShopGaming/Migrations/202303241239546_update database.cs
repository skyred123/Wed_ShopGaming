﻿namespace Wed_ShopGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SanPhams", t => t.Id)
                .ForeignKey("dbo.CauHinhs", t => t.IdCH)
                .Index(t => t.Id)
                .Index(t => t.IdCH);
            
            CreateTable(
                "dbo.LinhKiens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdLoaiSP = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiSPs", t => t.IdLoaiSP)
                .ForeignKey("dbo.SanPhams", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.IdLoaiSP);
            
            CreateTable(
                "dbo.LoaiSPs",
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
                        Img = c.Binary(),
                        IDSanPham = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SanPhams", t => t.IDSanPham)
                .Index(t => t.IDSanPham);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.CT_LinhKien",
                c => new
                    {
                        IdMayTinh = c.String(nullable: false, maxLength: 128),
                        IdLinhKien = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IdMayTinh, t.IdLinhKien })
                .ForeignKey("dbo.LinhKiens", t => t.IdMayTinh, cascadeDelete: true)
                .ForeignKey("dbo.MayTinhs", t => t.IdLinhKien, cascadeDelete: true)
                .Index(t => t.IdMayTinh)
                .Index(t => t.IdLinhKien);
            
            CreateTable(
                "dbo.CT_TSKT",
                c => new
                    {
                        IdLinhKien = c.String(nullable: false, maxLength: 128),
                        IdTSKT = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IdLinhKien, t.IdTSKT })
                .ForeignKey("dbo.LinhKiens", t => t.IdLinhKien, cascadeDelete: true)
                .ForeignKey("dbo.TSKTs", t => t.IdTSKT, cascadeDelete: true)
                .Index(t => t.IdLinhKien)
                .Index(t => t.IdTSKT);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MayTinhs", "IdCH", "dbo.CauHinhs");
            DropForeignKey("dbo.CT_TSKT", "IdTSKT", "dbo.TSKTs");
            DropForeignKey("dbo.CT_TSKT", "IdLinhKien", "dbo.LinhKiens");
            DropForeignKey("dbo.MayTinhs", "Id", "dbo.SanPhams");
            DropForeignKey("dbo.LinhKiens", "Id", "dbo.SanPhams");
            DropForeignKey("dbo.HinhAnhs", "IDSanPham", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "IdHang", "dbo.Hangs");
            DropForeignKey("dbo.CT_LinhKien", "IdLinhKien", "dbo.MayTinhs");
            DropForeignKey("dbo.CT_LinhKien", "IdMayTinh", "dbo.LinhKiens");
            DropForeignKey("dbo.LinhKiens", "IdLoaiSP", "dbo.LoaiSPs");
            DropIndex("dbo.CT_TSKT", new[] { "IdTSKT" });
            DropIndex("dbo.CT_TSKT", new[] { "IdLinhKien" });
            DropIndex("dbo.CT_LinhKien", new[] { "IdLinhKien" });
            DropIndex("dbo.CT_LinhKien", new[] { "IdMayTinh" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.HinhAnhs", new[] { "IDSanPham" });
            DropIndex("dbo.SanPhams", new[] { "IdHang" });
            DropIndex("dbo.LinhKiens", new[] { "IdLoaiSP" });
            DropIndex("dbo.LinhKiens", new[] { "Id" });
            DropIndex("dbo.MayTinhs", new[] { "IdCH" });
            DropIndex("dbo.MayTinhs", new[] { "Id" });
            DropTable("dbo.CT_TSKT");
            DropTable("dbo.CT_LinhKien");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TSKTs");
            DropTable("dbo.HinhAnhs");
            DropTable("dbo.Hangs");
            DropTable("dbo.SanPhams");
            DropTable("dbo.LoaiSPs");
            DropTable("dbo.LinhKiens");
            DropTable("dbo.MayTinhs");
            DropTable("dbo.CauHinhs");
        }
    }
}
