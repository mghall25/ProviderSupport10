namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientRemoveBillingOrgColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Client", "BillToOrg");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "BillToOrg", c => c.String());
        }
    }
}
