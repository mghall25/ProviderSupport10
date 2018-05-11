namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
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
            
            AddColumn("dbo.Client", "CounsPaID", c => c.Int(nullable: false));
            AddColumn("dbo.Client", "BillToOrg", c => c.String());
            AlterColumn("dbo.Client", "PrimeNo", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Client", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Client", "PhoneNum", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "EmergencyName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Client", "EmergencyEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "EmergencyPhone", c => c.String(nullable: false));
            AlterColumn("dbo.Provider", "PhoneNum", c => c.String(nullable: false));
            AlterColumn("dbo.Provider", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Client", "CounsPaID");

            // ADDED THIS - Create a temp BillToOrg for CounsPa to point to.
            Sql("INSERT INTO dbo.BillToOrg (Name, Type, PhoneNum, Email, Address1, Address2, Address3) VALUES ('Temp', 1, '1234567894','em@fds.com','345 Blaine','','Newberg, OR 97132')");

            // might have to add info to CounsPa here

            // had problem with this statement
            AddForeignKey("dbo.Client", "CounsPaID", "dbo.CounsPa", "CounsPaID", cascadeDelete: true);
            
            DropColumn("dbo.Client", "PA");
            DropColumn("dbo.Client", "PaOrg");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "PaOrg", c => c.String());
            AddColumn("dbo.Client", "PA", c => c.String());
            DropForeignKey("dbo.Client", "CounsPaID", "dbo.CounsPa");
            DropForeignKey("dbo.CounsPa", "BillToOrgID", "dbo.BillToOrg");
            DropIndex("dbo.Client", new[] { "CounsPaID" });
            DropIndex("dbo.CounsPa", new[] { "BillToOrgID" });
            AlterColumn("dbo.Provider", "Email", c => c.String());
            AlterColumn("dbo.Provider", "PhoneNum", c => c.String());
            AlterColumn("dbo.Client", "EmergencyPhone", c => c.String());
            AlterColumn("dbo.Client", "EmergencyEmail", c => c.String());
            AlterColumn("dbo.Client", "EmergencyName", c => c.String());
            AlterColumn("dbo.Client", "Email", c => c.String());
            AlterColumn("dbo.Client", "PhoneNum", c => c.String());
            AlterColumn("dbo.Client", "LastName", c => c.String());
            AlterColumn("dbo.Client", "FirstName", c => c.String());
            AlterColumn("dbo.Client", "PrimeNo", c => c.String());
            DropColumn("dbo.Client", "BillToOrg");
            DropColumn("dbo.Client", "CounsPaID");
            DropTable("dbo.CounsPa");
            DropTable("dbo.BillToOrg");
        }
    }
}
