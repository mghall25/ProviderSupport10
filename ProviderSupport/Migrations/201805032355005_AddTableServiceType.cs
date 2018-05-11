namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableServiceType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceType",
                c => new
                    {
                        ServiceTypeID = c.Int(nullable: false),
                        Desc = c.String(nullable: false, maxLength: 50),
                        DescLong = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ServiceTypeID);
            
            AddColumn("dbo.Transaction", "ServiceTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "ServiceTypeID");
            // This line causes a problem
            AddForeignKey("dbo.Transaction", "ServiceTypeID", "dbo.ServiceType", "ServiceTypeID", cascadeDelete: true);
            DropColumn("dbo.Transaction", "ServiceType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "ServiceType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transaction", "ServiceTypeID", "dbo.ServiceType");
            DropIndex("dbo.Transaction", new[] { "ServiceTypeID" });
            DropColumn("dbo.Transaction", "ServiceTypeID");
            DropTable("dbo.ServiceType");
        }
    }
}
