namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "BirthDay", c => c.DateTime());
            DropColumn("dbo.ApplicationUsers", "BrithDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUsers", "BrithDay", c => c.DateTime());
            DropColumn("dbo.ApplicationUsers", "BirthDay");
        }
    }
}
