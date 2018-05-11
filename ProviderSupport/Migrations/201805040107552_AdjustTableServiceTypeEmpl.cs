namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustTableServiceTypeEmpl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceTypeEmpl", "FlatFeeService", c => c.Boolean());
            AlterColumn("dbo.ServiceTypeEmpl", "Track1Fee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ServiceTypeEmpl", "Track2Fee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ServiceTypeEmpl", "Track3Fee", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceTypeEmpl", "Track3Fee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ServiceTypeEmpl", "Track2Fee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ServiceTypeEmpl", "Track1Fee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ServiceTypeEmpl", "FlatFeeService");
        }
    }
}
