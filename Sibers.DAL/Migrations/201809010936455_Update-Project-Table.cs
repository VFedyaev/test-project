namespace Sibers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Customer", c => c.String());
            AddColumn("dbo.Projects", "Perfomer", c => c.String());
            AddColumn("dbo.Projects", "ManagerId", c => c.Guid());
            AddColumn("dbo.Projects", "Employee_EId", c => c.Guid());
            CreateIndex("dbo.Projects", "Employee_EId");
            AddForeignKey("dbo.Projects", "Employee_EId", "dbo.Employees", "EId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Employee_EId", "dbo.Employees");
            DropIndex("dbo.Projects", new[] { "Employee_EId" });
            DropColumn("dbo.Projects", "Employee_EId");
            DropColumn("dbo.Projects", "ManagerId");
            DropColumn("dbo.Projects", "Perfomer");
            DropColumn("dbo.Projects", "Customer");
        }
    }
}
