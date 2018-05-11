namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class see : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceType", "Transaction_TransactionID", "dbo.Transaction");
            DropForeignKey("dbo.Transaction", "ServiceType_ServiceTypeID1", "dbo.ServiceType");
            DropForeignKey("dbo.Transaction", "ServiceType_ServiceTypeID", "dbo.ServiceType");
            DropIndex("dbo.Transaction", new[] { "ServiceType_ServiceTypeID" });
            DropIndex("dbo.Transaction", new[] { "ServiceType_ServiceTypeID1" });
            DropIndex("dbo.ServiceType", new[] { "Transaction_TransactionID" });
            DropColumn("dbo.Transaction", "ServiceTypeID");
            DropColumn("dbo.Transaction", "ServiceTypeID");
            RenameColumn(table: "dbo.Transaction", name: "ServiceType_ServiceTypeID1", newName: "ServiceTypeID");
            RenameColumn(table: "dbo.Transaction", name: "ServiceType_ServiceTypeID", newName: "ServiceTypeID");
            AlterColumn("dbo.Transaction", "ServiceTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "ServiceTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "ServiceTypeID");
            AddForeignKey("dbo.Transaction", "ServiceTypeID", "dbo.ServiceType", "ServiceTypeID", cascadeDelete: true);
            DropColumn("dbo.ServiceType", "Transaction_TransactionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceType", "Transaction_TransactionID", c => c.Int());
            DropForeignKey("dbo.Transaction", "ServiceTypeID", "dbo.ServiceType");
            DropIndex("dbo.Transaction", new[] { "ServiceTypeID" });
            AlterColumn("dbo.Transaction", "ServiceTypeID", c => c.Int());
            AlterColumn("dbo.Transaction", "ServiceTypeID", c => c.Int());
            RenameColumn(table: "dbo.Transaction", name: "ServiceTypeID", newName: "ServiceType_ServiceTypeID");
            RenameColumn(table: "dbo.Transaction", name: "ServiceTypeID", newName: "ServiceType_ServiceTypeID1");
            AddColumn("dbo.Transaction", "ServiceTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "ServiceTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceType", "Transaction_TransactionID");
            CreateIndex("dbo.Transaction", "ServiceType_ServiceTypeID1");
            CreateIndex("dbo.Transaction", "ServiceType_ServiceTypeID");
            AddForeignKey("dbo.Transaction", "ServiceType_ServiceTypeID", "dbo.ServiceType", "ServiceTypeID");
            AddForeignKey("dbo.Transaction", "ServiceType_ServiceTypeID1", "dbo.ServiceType", "ServiceTypeID");
            AddForeignKey("dbo.ServiceType", "Transaction_TransactionID", "dbo.Transaction", "TransactionID");
        }
    }
}
