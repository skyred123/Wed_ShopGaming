namespace Wed_ShopGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HinhAnhs", "Img", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HinhAnhs", "Img", c => c.Binary());
        }
    }
}
