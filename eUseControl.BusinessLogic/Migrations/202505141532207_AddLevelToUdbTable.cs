namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLevelToUdbTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UDbTables", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UDbTables", "Level");
        }
    }
}
