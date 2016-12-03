namespace MyContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedentrybyandentrydate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "EntryBy", c => c.String());
            AddColumn("dbo.Contact", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "Name", c => c.String());
            DropColumn("dbo.Contact", "EntryDate");
            DropColumn("dbo.Contact", "EntryBy");
        }
    }
}
