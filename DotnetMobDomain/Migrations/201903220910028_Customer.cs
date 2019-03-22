namespace DotnetMobDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Master.Customer",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        CustName = c.String(),
                        CustMobileNo = c.Int(nullable: false),
                        CustAddress1 = c.String(),
                        CustAddress2 = c.String(),
                        CustAddress3 = c.String(),
                    })
                .PrimaryKey(t => t.CustId);
            
        }
        
        public override void Down()
        {
            DropTable("Master.Customer");
        }
    }
}
