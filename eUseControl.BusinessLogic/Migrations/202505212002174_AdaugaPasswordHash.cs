using System;
using System.Data.Entity.Migrations;

namespace eUseControl.BusinessLogic.Migrations
{
     public partial class AdaugaPasswordHash : DbMigration
     {
          public override void Up()
          {
               AddColumn("dbo.UDbTables", "PasswordHash", c => c.String());
          }

          public override void Down()
          {
               DropColumn("dbo.UDbTables", "PasswordHash");
          }
     }
}
