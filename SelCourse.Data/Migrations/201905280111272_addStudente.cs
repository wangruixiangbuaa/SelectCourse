namespace SelCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudente : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Number");
            DropColumn("dbo.People", "ClassId");
            DropColumn("dbo.People", "SchoolId");
            DropColumn("dbo.People", "GradeId");
            DropColumn("dbo.People", "Hobby");
            DropColumn("dbo.People", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.People", "Hobby", c => c.String());
            AddColumn("dbo.People", "GradeId", c => c.Int());
            AddColumn("dbo.People", "SchoolId", c => c.Int());
            AddColumn("dbo.People", "ClassId", c => c.Int());
            AddColumn("dbo.People", "Number", c => c.String());
        }
    }
}
