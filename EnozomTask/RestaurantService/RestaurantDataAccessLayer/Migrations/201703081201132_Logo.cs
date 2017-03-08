namespace RestaurantDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Logo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stores", "StoreLogo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "StoreLogo", c => c.String(nullable: false));
        }
    }
}
