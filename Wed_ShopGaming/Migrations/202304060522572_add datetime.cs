namespace Wed_ShopGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoaDons", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoaDons", "DateTime");
        }
    }
}
