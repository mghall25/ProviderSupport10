namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableServiceTypeEmpl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceTypeEmpl",
                c => new
                    {
                        ServiceTypeEmplID = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Desc = c.String(),
                        DescLong = c.String(),
                        MultiDateEntry = c.Boolean(nullable: false),
                        VrService = c.Boolean(nullable: false),
                        Track1Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Track2Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Track3Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ServiceTypeEmplID);
            
            AddColumn("dbo.Transaction", "ServiceTypeEmplID", c => c.Int());
            CreateIndex("dbo.Transaction", "ServiceTypeEmplID");
            // NO PROBLEM ADDING FOREIGN KEY BECAUSE I DIDN'T SET IT AS REQUIRED YET!!! Do this in future--add [Required] to model AFTER updating the database
            AddForeignKey("dbo.Transaction", "ServiceTypeEmplID", "dbo.ServiceTypeEmpl", "ServiceTypeEmplID");
            DropColumn("dbo.Transaction", "EmploymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "EmploymentType", c => c.Int());
            DropForeignKey("dbo.Transaction", "ServiceTypeEmplID", "dbo.ServiceTypeEmpl");
            DropIndex("dbo.Transaction", new[] { "ServiceTypeEmplID" });
            DropColumn("dbo.Transaction", "ServiceTypeEmplID");
            DropTable("dbo.ServiceTypeEmpl");
        }
    }
}
