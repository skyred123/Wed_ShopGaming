namespace Wed_ShopGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoaDons", "OrderStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoaDons", "OrderStatus");
        }
    }
}
