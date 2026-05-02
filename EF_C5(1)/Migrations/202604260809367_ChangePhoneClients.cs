namespace EF_C5_1_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePhoneClients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Phone");
        }
    }
}
