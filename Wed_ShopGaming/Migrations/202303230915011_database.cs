namespace Wed_ShopGaming.Migrations
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
                "dbo.CT_LinhKien",
                c => new
                    {
                        IdLinhKien = c.String(nullable: false, maxLength: 128),
                        IdMayTinh = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IdLinhKien, t.IdMayTinh })
                .ForeignKey("dbo.SanPhams", t => t.IdLinhKien, cascadeDelete: true)
                .ForeignKey("dbo.SanPhams", t => t.IdMayTinh, cascadeDelete: true)
                .Index(t => t.IdLinhKien)
                .Index(t => t.IdMayTinh);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Long(nullable: false),
                        IdHang = c.String(maxLength: 128),
                        IdThongSo = c.String(maxLength: 128),
                        IdCH = c.String(maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        LinhKien_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ThongSoes", t => t.IdThongSo)
                .ForeignKey("dbo.CauHinhs", t => t.IdCH)
                .ForeignKey("dbo.Hangs", t => t.IdHang)
                .ForeignKey("dbo.SanPhams", t => t.LinhKien_Id)
                .Index(t => t.IdHang)
                .Index(t => t.IdThongSo)
                .Index(t => t.IdCH)
                .Index(t => t.LinhKien_Id);
            
            CreateTable(
                "dbo.Hangs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThongSoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        IdLoaiSP = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiSPs", t => t.IdLoaiSP)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.HinhAnhs", "IDSanPham", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "LinhKien_Id", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "IdHang", "dbo.Hangs");
            DropForeignKey("dbo.CT_LinhKien", "IdMayTinh", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "IdCH", "dbo.CauHinhs");
            DropForeignKey("dbo.CT_LinhKien", "IdLinhKien", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "IdThongSo", "dbo.ThongSoes");
            DropForeignKey("dbo.ThongSoes", "IdLoaiSP", "dbo.LoaiSPs");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.HinhAnhs", new[] { "IDSanPham" });
            DropIndex("dbo.ThongSoes", new[] { "IdLoaiSP" });
            DropIndex("dbo.SanPhams", new[] { "LinhKien_Id" });
            DropIndex("dbo.SanPhams", new[] { "IdCH" });
            DropIndex("dbo.SanPhams", new[] { "IdThongSo" });
            DropIndex("dbo.SanPhams", new[] { "IdHang" });
            DropIndex("dbo.CT_LinhKien", new[] { "IdMayTinh" });
            DropIndex("dbo.CT_LinhKien", new[] { "IdLinhKien" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.HinhAnhs");
            DropTable("dbo.LoaiSPs");
            DropTable("dbo.ThongSoes");
            DropTable("dbo.Hangs");
            DropTable("dbo.SanPhams");
            DropTable("dbo.CT_LinhKien");
            DropTable("dbo.CauHinhs");
        }
    }
}
