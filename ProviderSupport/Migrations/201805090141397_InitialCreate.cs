namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillToOrg",
                c => new
                    {
                        BillToOrgID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.Int(nullable: false),
                        PhoneNum = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        Address3 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BillToOrgID);
            
            CreateTable(
                "dbo.CounsPa",
                c => new
                    {
                        CounsPaID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNum = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BillToOrgID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CounsPaID)
                .ForeignKey("dbo.BillToOrg", t => t.BillToOrgID, cascadeDelete: true)
                .Index(t => t.BillToOrgID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        PrimeNo = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNum = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        EmergencyName = c.String(nullable: false, maxLength: 50),
                        EmergencyEmail = c.String(nullable: false),
                        EmergencyPhone = c.String(nullable: false),
                        CounsPaID = c.Int(nullable: false),
                        Archived = c.Boolean(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.CounsPa", t => t.CounsPaID, cascadeDelete: true)
                .Index(t => t.CounsPaID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        ProviderID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        DateWorked = c.DateTime(nullable: false),
                        ServiceTypeID = c.Int(nullable: false),
                        TimeIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                        ServiceDesc = c.String(),
                        ProgressNote = c.String(),
                        OdometerStart = c.Int(),
                        OdometerEnd = c.Int(),
                        TravelPurpose = c.String(),
                        ExpenseVendor = c.String(),
                        ExpensePurpose = c.String(),
                        ExpenseAmount = c.Int(),
                        ServiceTypeEmplID = c.Int(nullable: false),
                        EmploymentDirSuppHrs = c.Int(),
                        IsDuplicate = c.Boolean(),
                        WhenInvoiced = c.DateTime(),
                        WhenSentToExprs = c.DateTime(),
                        WhenPaidToPayroll = c.DateTime(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Provider", t => t.ProviderID, cascadeDelete: true)
                .ForeignKey("dbo.ServiceType", t => t.ServiceTypeID, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypeEmpl", t => t.ServiceTypeEmplID, cascadeDelete: true)
                .Index(t => t.ProviderID)
                .Index(t => t.ClientID)
                .Index(t => t.ServiceTypeID)
                .Index(t => t.ServiceTypeEmplID);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        ProviderID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNum = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        PayRate = c.Double(nullable: false),
                        CprExpDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProviderID);
            
            CreateTable(
                "dbo.ServiceType",
                c => new
                    {
                        ServiceTypeID = c.Int(nullable: false),
                        Desc = c.String(nullable: false, maxLength: 50),
                        DescLong = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ServiceTypeID);
            
            CreateTable(
                "dbo.ServiceTypeEmpl",
                c => new
                    {
                        ServiceTypeEmplID = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Desc = c.String(nullable: false, maxLength: 50),
                        DescLong = c.String(nullable: false, maxLength: 150),
                        MultiDateEntry = c.Boolean(nullable: false),
                        VrService = c.Boolean(nullable: false),
                        Track1Fee = c.Decimal(precision: 18, scale: 2),
                        Track2Fee = c.Decimal(precision: 18, scale: 2),
                        Track3Fee = c.Decimal(precision: 18, scale: 2),
                        FlatFeeService = c.Boolean(),
                    })
                .PrimaryKey(t => t.ServiceTypeEmplID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ServiceTypeEmplID", "dbo.ServiceTypeEmpl");
            DropForeignKey("dbo.Transaction", "ServiceTypeID", "dbo.ServiceType");
            DropForeignKey("dbo.Transaction", "ProviderID", "dbo.Provider");
            DropForeignKey("dbo.Transaction", "ClientID", "dbo.Client");
            DropForeignKey("dbo.Client", "CounsPaID", "dbo.CounsPa");
            DropForeignKey("dbo.CounsPa", "BillToOrgID", "dbo.BillToOrg");
            DropIndex("dbo.Transaction", new[] { "ServiceTypeEmplID" });
            DropIndex("dbo.Transaction", new[] { "ServiceTypeID" });
            DropIndex("dbo.Transaction", new[] { "ClientID" });
            DropIndex("dbo.Transaction", new[] { "ProviderID" });
            DropIndex("dbo.Client", new[] { "CounsPaID" });
            DropIndex("dbo.CounsPa", new[] { "BillToOrgID" });
            DropTable("dbo.ServiceTypeEmpl");
            DropTable("dbo.ServiceType");
            DropTable("dbo.Provider");
            DropTable("dbo.Transaction");
            DropTable("dbo.Client");
            DropTable("dbo.CounsPa");
            DropTable("dbo.BillToOrg");
        }
    }
}
