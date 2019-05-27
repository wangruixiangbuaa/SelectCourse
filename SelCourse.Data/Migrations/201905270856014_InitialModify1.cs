namespace SelCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModify1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Area", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Area");
        }
    }
}
