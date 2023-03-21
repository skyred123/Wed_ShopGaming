namespace Wed_ShopGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatethongso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LinhKiens", "IdDMSP", "dbo.DMSPs");
            DropForeignKey("dbo.LinhKiens", "IdLoaiSP", "dbo.LoaiSPs");
            DropIndex("dbo.LinhKiens", new[] { "IdLoaiSP" });
            DropIndex("dbo.LinhKiens", new[] { "IdDMSP" });
            AddColumn("dbo.ThongSoes", "IdLoaiSP", c => c.Guid(nullable: false));
            CreateIndex("dbo.ThongSoes", "IdLoaiSP");
            AddForeignKey("dbo.ThongSoes", "IdLoaiSP", "dbo.LoaiSPs", "Id", cascadeDelete: true);
            DropColumn("dbo.LinhKiens", "IdLoaiSP");
            DropColumn("dbo.LinhKiens", "IdDMSP");
            DropTable("dbo.DMSPs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DMSPs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LinhKiens", "IdDMSP", c => c.Guid(nullable: false));
            AddColumn("dbo.LinhKiens", "IdLoaiSP", c => c.Guid(nullable: false));
            DropForeignKey("dbo.ThongSoes", "IdLoaiSP", "dbo.LoaiSPs");
            DropIndex("dbo.ThongSoes", new[] { "IdLoaiSP" });
            DropColumn("dbo.ThongSoes", "IdLoaiSP");
            CreateIndex("dbo.LinhKiens", "IdDMSP");
            CreateIndex("dbo.LinhKiens", "IdLoaiSP");
            AddForeignKey("dbo.LinhKiens", "IdLoaiSP", "dbo.LoaiSPs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LinhKiens", "IdDMSP", "dbo.DMSPs", "Id", cascadeDelete: true);
        }
    }
}
