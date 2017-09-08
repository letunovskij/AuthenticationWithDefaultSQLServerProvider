namespace DefaultAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.user_info",
                c => new
                    {
                        FullName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.FullName);
            
            AddColumn("dbo.AspNetUsers", "ApplicationUserInfo_FullName", c => c.String(maxLength: 200));
            CreateIndex("dbo.AspNetUsers", "ApplicationUserInfo_FullName");
            AddForeignKey("dbo.AspNetUsers", "ApplicationUserInfo_FullName", "dbo.user_info", "FullName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ApplicationUserInfo_FullName", "dbo.user_info");
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUserInfo_FullName" });
            DropColumn("dbo.AspNetUsers", "ApplicationUserInfo_FullName");
            DropTable("dbo.user_info");
        }
    }
}
