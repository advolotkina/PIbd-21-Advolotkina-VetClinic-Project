namespace VetClinicService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminId = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Format = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.RequestDrugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drugs", t => t.DrugId, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.Drugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceDrugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drugs", t => t.DrugId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.RequestDrugs", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.ServiceDrugs", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ServiceDrugs", "DrugId", "dbo.Drugs");
            DropForeignKey("dbo.RequestDrugs", "DrugId", "dbo.Drugs");
            DropIndex("dbo.ServiceDrugs", new[] { "DrugId" });
            DropIndex("dbo.ServiceDrugs", new[] { "ServiceId" });
            DropIndex("dbo.RequestDrugs", new[] { "DrugId" });
            DropIndex("dbo.RequestDrugs", new[] { "RequestId" });
            DropIndex("dbo.Requests", new[] { "AdminId" });
            DropTable("dbo.Services");
            DropTable("dbo.ServiceDrugs");
            DropTable("dbo.Drugs");
            DropTable("dbo.RequestDrugs");
            DropTable("dbo.Requests");
            DropTable("dbo.Admins");
        }
    }
}
