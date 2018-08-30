namespace Sibers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.EId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        PId = c.Guid(nullable: false),
                        ProjectName = c.String(),
                        StartedDate = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PId);
            
            CreateTable(
                "dbo.ProjectEmployee",
                c => new
                    {
                        PId = c.Guid(nullable: false),
                        EId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PId, t.EId })
                .ForeignKey("dbo.Projects", t => t.PId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EId, cascadeDelete: true)
                .Index(t => t.PId)
                .Index(t => t.EId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectEmployee", "EId", "dbo.Employees");
            DropForeignKey("dbo.ProjectEmployee", "PId", "dbo.Projects");
            DropIndex("dbo.ProjectEmployee", new[] { "EId" });
            DropIndex("dbo.ProjectEmployee", new[] { "PId" });
            DropTable("dbo.ProjectEmployee");
            DropTable("dbo.Projects");
            DropTable("dbo.Employees");
        }
    }
}
