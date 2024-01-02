namespace BotTg.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAutoMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMs", "AutoMessage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMs", "AutoMessage");
        }
    }
}
