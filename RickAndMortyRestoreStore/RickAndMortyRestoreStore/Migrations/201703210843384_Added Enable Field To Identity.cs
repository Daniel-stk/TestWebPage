namespace RickAndMortyRestoreStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEnableFieldToIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsEnabled", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsEnabled");
        }
    }
}
