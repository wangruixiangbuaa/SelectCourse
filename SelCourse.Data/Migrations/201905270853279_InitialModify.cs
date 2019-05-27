namespace SelCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModify : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        BeTime = c.DateTime(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
