namespace SelCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Number", c => c.String());
            AddColumn("dbo.People", "ClassId", c => c.Int());
            AddColumn("dbo.People", "SchoolId", c => c.Int());
            AddColumn("dbo.People", "GradeId", c => c.Int());
            AddColumn("dbo.People", "Hobby", c => c.String());
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Discriminator");
            DropColumn("dbo.People", "Hobby");
            DropColumn("dbo.People", "GradeId");
            DropColumn("dbo.People", "SchoolId");
            DropColumn("dbo.People", "ClassId");
            DropColumn("dbo.People", "Number");
        }
    }
}
