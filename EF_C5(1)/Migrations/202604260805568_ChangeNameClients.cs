namespace EF_C5_1_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameClients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientsShop",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Email = c.String()
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
