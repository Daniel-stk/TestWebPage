namespace RickAndMortyRestoreStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixJobCommentRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentModels", "CommentId", "dbo.JobModels");
            DropIndex("dbo.CommentModels", new[] { "CommentId" });
            DropPrimaryKey("dbo.CommentModels");
            AddColumn("dbo.CommentModels", "JobId", c => c.Int(nullable: false));
            AlterColumn("dbo.CommentModels", "CommentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CommentModels", "CommentId");
            CreateIndex("dbo.CommentModels", "JobId");
            AddForeignKey("dbo.CommentModels", "JobId", "dbo.JobModels", "JobId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentModels", "JobId", "dbo.JobModels");
            DropIndex("dbo.CommentModels", new[] { "JobId" });
            DropPrimaryKey("dbo.CommentModels");
            AlterColumn("dbo.CommentModels", "CommentId", c => c.Int(nullable: false));
            DropColumn("dbo.CommentModels", "JobId");
            AddPrimaryKey("dbo.CommentModels", "CommentId");
            CreateIndex("dbo.CommentModels", "CommentId");
            AddForeignKey("dbo.CommentModels", "CommentId", "dbo.JobModels", "JobId");
        }
    }
}
