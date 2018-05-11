namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjTrans : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "ServiceTypeEmplID", "dbo.ServiceTypeEmpl");
            DropIndex("dbo.Transaction", new[] { "ServiceTypeEmplID" });
            AlterColumn("dbo.Transaction", "ServiceTypeEmplID", c => c.Int());
            CreateIndex("dbo.Transaction", "ServiceTypeEmplID");
            AddForeignKey("dbo.Transaction", "ServiceTypeEmplID", "dbo.ServiceTypeEmpl", "ServiceTypeEmplID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ServiceTypeEmplID", "dbo.ServiceTypeEmpl");
            DropIndex("dbo.Transaction", new[] { "ServiceTypeEmplID" });
            AlterColumn("dbo.Transaction", "ServiceTypeEmplID", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "ServiceTypeEmplID");
            AddForeignKey("dbo.Transaction", "ServiceTypeEmplID", "dbo.ServiceTypeEmpl", "ServiceTypeEmplID", cascadeDelete: true);
        }
    }
}
