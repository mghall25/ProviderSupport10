namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        PrimeNo = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNum = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        EmergencyName = c.String(),
                        EmergencyEmail = c.String(),
                        EmergencyPhone = c.String(),
                        PA = c.String(),
                        PaOrg = c.String(),
                        Archived = c.Boolean(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        ProviderID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        DateWorked = c.DateTime(nullable: false),
                        ServiceType = c.Int(nullable: false),
                        TimeIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                        ServiceDesc = c.String(),
                        ProgressNote = c.String(),
                        OdometerStart = c.Int(),
                        OdometerEnd = c.Int(),
                        TravelPurpose = c.String(),
                        ExpenseVendor = c.String(),
                        ExpensePurpose = c.String(),
                        ExpenseAmount = c.String(),
                        EmploymentType = c.Int(),
                        EmploymentDirSuppHrs = c.Int(),
                        IsDuplicate = c.Boolean(),
                        WhenInvoiced = c.DateTime(),
                        WhenSentToExprs = c.DateTime(),
                        WhenPaidToPayroll = c.DateTime(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Provider", t => t.ProviderID, cascadeDelete: true)
                .Index(t => t.ProviderID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        ProviderID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNum = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PayRate = c.Double(nullable: false),
                        CprExpDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProviderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ProviderID", "dbo.Provider");
            DropForeignKey("dbo.Transaction", "ClientID", "dbo.Client");
            DropIndex("dbo.Transaction", new[] { "ClientID" });
            DropIndex("dbo.Transaction", new[] { "ProviderID" });
            DropTable("dbo.Provider");
            DropTable("dbo.Transaction");
            DropTable("dbo.Client");
        }
    }
}
