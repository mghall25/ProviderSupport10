namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientNullableCounsPAID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Client", "CounsPaID", "dbo.CounsPa");
            DropIndex("dbo.Client", new[] { "CounsPaID" });
            AlterColumn("dbo.Client", "CounsPaID", c => c.Int());
            CreateIndex("dbo.Client", "CounsPaID");
            AddForeignKey("dbo.Client", "CounsPaID", "dbo.CounsPa", "CounsPaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "CounsPaID", "dbo.CounsPa");
            DropIndex("dbo.Client", new[] { "CounsPaID" });
            AlterColumn("dbo.Client", "CounsPaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Client", "CounsPaID");
            AddForeignKey("dbo.Client", "CounsPaID", "dbo.CounsPa", "CounsPaID", cascadeDelete: true);
        }
    }
}
