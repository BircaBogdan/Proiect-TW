﻿namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUDbTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 30),
                        LastLogin = c.DateTime(nullable: false),
                        LastIp = c.String(),
                        Level = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        Telefon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UDbTables");
        }
    }
}
