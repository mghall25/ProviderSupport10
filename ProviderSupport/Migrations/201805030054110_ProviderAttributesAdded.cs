namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProviderAttributesAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Provider", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Provider", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Provider", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Provider", "FirstName", c => c.String(maxLength: 50));
        }
    }
}
