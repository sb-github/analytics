namespace ReportingDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportingSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportingDate = c.DateTime(),
                        SkillID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: true)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportingSkills", "SkillID", "dbo.Skills");
            DropIndex("dbo.ReportingSkills", new[] { "SkillID" });
            DropTable("dbo.Skills");
            DropTable("dbo.ReportingSkills");
        }
    }
}
