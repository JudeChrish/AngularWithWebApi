namespace DotnetMobDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Cus_Property : DbMigration
    {
        public override void Up()
        {
            AddColumn("Master.Customer", "CustStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Master.Customer", "CustStatus");
        }
    }
}
