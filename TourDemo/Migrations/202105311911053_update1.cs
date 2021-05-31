namespace TourDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminTours", "From_Tour_Num", c => c.Int());
            AddColumn("dbo.AdminTours", "To_Tour_Num", c => c.Int());
            CreateIndex("dbo.AdminTours", "From_Tour_Num");
            CreateIndex("dbo.AdminTours", "To_Tour_Num");
            AddForeignKey("dbo.AdminTours", "From_Tour_Num", "dbo.AdminTours", "Tour_Num");
            AddForeignKey("dbo.AdminTours", "To_Tour_Num", "dbo.AdminTours", "Tour_Num");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminTours", "To_Tour_Num", "dbo.AdminTours");
            DropForeignKey("dbo.AdminTours", "From_Tour_Num", "dbo.AdminTours");
            DropIndex("dbo.AdminTours", new[] { "To_Tour_Num" });
            DropIndex("dbo.AdminTours", new[] { "From_Tour_Num" });
            DropColumn("dbo.AdminTours", "To_Tour_Num");
            DropColumn("dbo.AdminTours", "From_Tour_Num");
        }
    }
}
