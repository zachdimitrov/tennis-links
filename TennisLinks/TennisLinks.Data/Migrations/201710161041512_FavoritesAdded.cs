namespace TennisLinks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoritesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Details_Id = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Details", t => t.Details_Id)
                .Index(t => t.Details_Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "Details_Id", "dbo.Details");
            DropIndex("dbo.Favorites", new[] { "IsDeleted" });
            DropIndex("dbo.Favorites", new[] { "Details_Id" });
            DropTable("dbo.Favorites");
        }
    }
}
