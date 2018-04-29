namespace VetClinicService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "AdminId", "dbo.Admins");
            DropIndex("dbo.Requests", new[] { "AdminId" });
            DropColumn("dbo.Requests", "AdminId");
            DropColumn("dbo.Requests", "Address");
            DropColumn("dbo.Requests", "Format");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "Format", c => c.String(nullable: false));
            AddColumn("dbo.Requests", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Requests", "AdminId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "AdminId");
            AddForeignKey("dbo.Requests", "AdminId", "dbo.Admins", "Id", cascadeDelete: true);
        }
    }
}
