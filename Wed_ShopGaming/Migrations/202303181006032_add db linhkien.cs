namespace Wed_ShopGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddblinhkien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DMSPs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LinhKiens",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdLoaiSP = c.Guid(nullable: false),
                        IdThongSo = c.Guid(nullable: false),
                        IdDMSP = c.Guid(nullable: false),
                        IdSanPham = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DMSPs", t => t.IdDMSP, cascadeDelete: true)
                .ForeignKey("dbo.LoaiSPs", t => t.IdLoaiSP, cascadeDelete: true)
                .ForeignKey("dbo.SanPhams", t => t.IdSanPham, cascadeDelete: true)
                .ForeignKey("dbo.ThongSoes", t => t.IdThongSo, cascadeDelete: true)
                .Index(t => t.IdLoaiSP)
                .Index(t => t.IdThongSo)
                .Index(t => t.IdDMSP)
                .Index(t => t.IdSanPham);
            
            CreateTable(
                "dbo.LoaiSPs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Long(nullable: false),
                        IdHang = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hangs", t => t.IdHang, cascadeDelete: true)
                .Index(t => t.IdHang);
            
            CreateTable(
                "dbo.Hangs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThongSoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
            DropForeignKey("dbo.LinhKiens", "IdThongSo", "dbo.ThongSoes");
            DropForeignKey("dbo.LinhKiens", "IdSanPham", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "IdHang", "dbo.Hangs");
            DropForeignKey("dbo.LinhKiens", "IdLoaiSP", "dbo.LoaiSPs");
            DropForeignKey("dbo.LinhKiens", "IdDMSP", "dbo.DMSPs");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SanPhams", new[] { "IdHang" });
            DropIndex("dbo.LinhKiens", new[] { "IdSanPham" });
            DropIndex("dbo.LinhKiens", new[] { "IdDMSP" });
            DropIndex("dbo.LinhKiens", new[] { "IdThongSo" });
            DropIndex("dbo.LinhKiens", new[] { "IdLoaiSP" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ThongSoes");
            DropTable("dbo.Hangs");
            DropTable("dbo.SanPhams");
            DropTable("dbo.LoaiSPs");
            DropTable("dbo.LinhKiens");
            DropTable("dbo.DMSPs");
        }
    }
}
