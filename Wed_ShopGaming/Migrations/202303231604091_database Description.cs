namespace Wed_ShopGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TSKTs", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TSKTs", "Description");
        }
    }
}
