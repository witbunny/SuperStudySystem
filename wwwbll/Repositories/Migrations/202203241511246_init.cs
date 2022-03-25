namespace wwwbll.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        InvitedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.InvitedBy_Id)
                .Index(t => t.InvitedBy_Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "InvitedBy_Id", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            DropIndex("dbo.Users", new[] { "InvitedBy_Id" });
            DropTable("dbo.Articles");
            DropTable("dbo.Users");
        }
    }
}
