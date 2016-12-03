namespace MyContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "Name", c => c.String(maxLength: 255));
        }
    }
}
