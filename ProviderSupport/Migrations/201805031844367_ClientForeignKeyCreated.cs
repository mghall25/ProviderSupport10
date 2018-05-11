namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientForeignKeyCreated : DbMigration
    {
        public override void Up()
        {
            // Create  a temp BillToOrg for CounsPa to point to.
            // Sql("INSERT INTO dbo.BillToOrg (Name, Type, PhoneNum, Email, Address1,Address2,Address3) VALUES ('Temp', 1, '4567891235','em@fds.com','345 Blaine','Apt 3','Newberg, OR 97132')");

            AddForeignKey("dbo.Client", "CounsPaID", "dbo.CounsPa", "CounsPaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
        }
    }
}
