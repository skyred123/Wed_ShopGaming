namespace Wed_ShopGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hoadon : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            DropColumn("dbo.AspNetUsers", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Adress", c => c.String());
            DropForeignKey("dbo.CT_DH", "SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.HoaDons", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CT_DH", "HoaDonId", "dbo.HoaDons");
            DropIndex("dbo.HoaDons", new[] { "UserId" });
            DropIndex("dbo.CT_DH", new[] { "HoaDonId" });
            DropIndex("dbo.CT_DH", new[] { "SanPhamId" });
            DropColumn("dbo.AspNetUsers", "Address");
            DropTable("dbo.HoaDons");
            DropTable("dbo.CT_DH");
        }
    }
}
