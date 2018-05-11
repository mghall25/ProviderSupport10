namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBackRequiredFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "ClientID", "dbo.Client");
            DropForeignKey("dbo.Transaction", "ProviderID", "dbo.Provider");
            DropForeignKey("dbo.Transaction", "ServiceTypeID", "dbo.ServiceType");
            DropIndex("dbo.Transaction", new[] { "ProviderID" });
            DropIndex("dbo.Transaction", new[] { "ClientID" });
            DropIndex("dbo.Transaction", new[] { "ServiceTypeID" });
            AlterColumn("dbo.Transaction", "ProviderID", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "ClientID", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "ServiceTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "ProviderID");
            CreateIndex("dbo.Transaction", "ClientID");
            CreateIndex("dbo.Transaction", "ServiceTypeID");
            AddForeignKey("dbo.Transaction", "ClientID", "dbo.Client", "ClientID", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "ProviderID", "dbo.Provider", "ProviderID", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "ServiceTypeID", "dbo.ServiceType", "ServiceTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ServiceTypeID", "dbo.ServiceType");
            DropForeignKey("dbo.Transaction", "ProviderID", "dbo.Provider");
            DropForeignKey("dbo.Transaction", "ClientID", "dbo.Client");
            DropIndex("dbo.Transaction", new[] { "ServiceTypeID" });
            DropIndex("dbo.Transaction", new[] { "ClientID" });
            DropIndex("dbo.Transaction", new[] { "ProviderID" });
            AlterColumn("dbo.Transaction", "ServiceTypeID", c => c.Int());
            AlterColumn("dbo.Transaction", "ClientID", c => c.Int());
            AlterColumn("dbo.Transaction", "ProviderID", c => c.Int());
            CreateIndex("dbo.Transaction", "ServiceTypeID");
            CreateIndex("dbo.Transaction", "ClientID");
            CreateIndex("dbo.Transaction", "ProviderID");
            AddForeignKey("dbo.Transaction", "ServiceTypeID", "dbo.ServiceType", "ServiceTypeID");
            AddForeignKey("dbo.Transaction", "ProviderID", "dbo.Provider", "ProviderID");
            AddForeignKey("dbo.Transaction", "ClientID", "dbo.Client", "ClientID");
        }
    }
}
