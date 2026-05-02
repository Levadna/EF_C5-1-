namespace EF_C5_1_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployeeShop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeShop",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Department = c.String(nullable: false),
                    Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeShop");
        }
    }
}
