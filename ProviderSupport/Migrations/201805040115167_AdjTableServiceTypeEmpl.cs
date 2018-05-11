namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjTableServiceTypeEmpl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceTypeEmpl", "Desc", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ServiceTypeEmpl", "DescLong", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceTypeEmpl", "DescLong", c => c.String());
            AlterColumn("dbo.ServiceTypeEmpl", "Desc", c => c.String());
        }
    }
}
