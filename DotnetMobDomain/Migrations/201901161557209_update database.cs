namespace DotnetMobDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Master.Employee",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        EmpFName = c.String(),
                        EmpLName = c.String(),
                        Department = c.String(),
                        EmpStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropTable("Master.Employee");
        }
    }
}
