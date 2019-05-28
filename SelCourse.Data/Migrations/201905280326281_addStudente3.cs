namespace SelCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudente3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        SId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        ClassId = c.Int(nullable: false),
                        SchoolId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                        Hobby = c.String(),
                    })
                .PrimaryKey(t => t.SId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
