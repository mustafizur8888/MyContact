namespace MyContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "Favourite", c => c.Boolean());
            AlterColumn("dbo.Contact", "EntryDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "Favourite", c => c.Boolean(nullable: false));
        }
    }
}
