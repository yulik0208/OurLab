namespace VirtualLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PercentsOfDone = c.Single(nullable: false),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Result_Id = c.Int(),
                        Result_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Results", t => t.Result_Id)
                .ForeignKey("dbo.Results", t => t.Result_Id1)
                .Index(t => t.Result_Id)
                .Index(t => t.Result_Id1);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Supports",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdQuestion = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        Content = c.String(),
                        Answer = c.String(),
                        IdAdmin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Users", "Roots", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "Id", "dbo.Users");
            DropForeignKey("dbo.Supports", "Id", "dbo.Users");
            DropForeignKey("dbo.Results", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Topics", "Result_Id1", "dbo.Results");
            DropForeignKey("dbo.Tasks", "Id", "dbo.Topics");
            DropForeignKey("dbo.Answers", "Id", "dbo.Tasks");
            DropForeignKey("dbo.Topics", "Result_Id", "dbo.Results");
            DropIndex("dbo.Supports", new[] { "Id" });
            DropIndex("dbo.Answers", new[] { "Id" });
            DropIndex("dbo.Tasks", new[] { "Id" });
            DropIndex("dbo.Topics", new[] { "Result_Id1" });
            DropIndex("dbo.Topics", new[] { "Result_Id" });
            DropIndex("dbo.Results", new[] { "Topic_Id" });
            DropIndex("dbo.Results", new[] { "Id" });
            DropColumn("dbo.Users", "Roots");
            DropTable("dbo.Supports");
            DropTable("dbo.Answers");
            DropTable("dbo.Tasks");
            DropTable("dbo.Topics");
            DropTable("dbo.Results");
        }
    }
}
