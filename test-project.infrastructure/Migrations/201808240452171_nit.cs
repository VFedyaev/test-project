namespace test_project.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeProjects", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeProjects", "ProjectId", "dbo.Projects");
            DropIndex("dbo.EmployeeProjects", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeProjects", new[] { "ProjectId" });
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Projects");
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
            
            AddColumn("dbo.Employees", "EId", c => c.Guid(nullable: false));
            AddColumn("dbo.Projects", "PId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Employees", "EId");
            AddPrimaryKey("dbo.Projects", "PId");
            DropColumn("dbo.Employees", "Id");
            DropColumn("dbo.Employees", "EmployeeProjectId");
            DropColumn("dbo.Projects", "Id");
            DropColumn("dbo.Projects", "EmployeeProjectId");
            DropTable("dbo.EmployeeProjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeProjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Projects", "EmployeeProjectId", c => c.Guid());
            AddColumn("dbo.Projects", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Employees", "EmployeeProjectId", c => c.Guid());
            AddColumn("dbo.Employees", "Id", c => c.Guid(nullable: false));
            DropForeignKey("dbo.ProjectEmployee", "EId", "dbo.Employees");
            DropForeignKey("dbo.ProjectEmployee", "PId", "dbo.Projects");
            DropIndex("dbo.ProjectEmployee", new[] { "EId" });
            DropIndex("dbo.ProjectEmployee", new[] { "PId" });
            DropPrimaryKey("dbo.Projects");
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Projects", "PId");
            DropColumn("dbo.Employees", "EId");
            DropTable("dbo.ProjectEmployee");
            AddPrimaryKey("dbo.Projects", "Id");
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.EmployeeProjects", "ProjectId");
            CreateIndex("dbo.EmployeeProjects", "EmployeeId");
            AddForeignKey("dbo.EmployeeProjects", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeProjects", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
