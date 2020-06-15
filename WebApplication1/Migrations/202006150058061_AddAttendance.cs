namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        AttendeeID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseID, t.AttendeeID })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .Index(t => t.CourseID)
                .Index(t => t.AttendeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "AttendeeID", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeID" });
            DropIndex("dbo.Attendances", new[] { "CourseID" });
            DropTable("dbo.Attendances");
        }
    }
}
