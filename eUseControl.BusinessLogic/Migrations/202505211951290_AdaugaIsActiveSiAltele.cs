namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdaugaIsActiveSiAltele : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UDbTables", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UDbTables", "IsActive");
        }
    }
}
