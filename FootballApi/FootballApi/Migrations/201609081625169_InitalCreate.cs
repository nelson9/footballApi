namespace FootballApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatchResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameWeek = c.Int(nullable: false),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        HomeGoals = c.Int(nullable: false),
                        AwayGoals = c.Int(nullable: false),
                        Result = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchResults", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.MatchResults", "AwayTeamId", "dbo.Teams");
            DropIndex("dbo.MatchResults", new[] { "AwayTeamId" });
            DropIndex("dbo.MatchResults", new[] { "HomeTeamId" });
            DropTable("dbo.Teams");
            DropTable("dbo.MatchResults");
        }
    }
}
