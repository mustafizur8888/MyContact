namespace MyContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class birthdayoptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
