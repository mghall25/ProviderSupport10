namespace ProviderSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionExpenseAmountTypeToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "ExpenseAmount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "ExpenseAmount", c => c.String());
        }
    }
}
