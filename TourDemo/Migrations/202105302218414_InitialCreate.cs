namespace TourDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminTours",
                c => new
                    {
                        Tour_Num = c.Int(nullable: false, identity: true),
                        Tour_Name = c.String(),
                        Tour_Duration = c.String(),
                        LocationFrom = c.Int(nullable: false),
                        LocationTO = c.Int(nullable: false),
                        TourDate = c.DateTime(nullable: false),
                        TourStartTime = c.DateTime(nullable: false),
                        TourName = c.String(nullable: false, maxLength: 30),
                        Price = c.Single(nullable: false),
                        Deposit = c.Double(nullable: false),
                        UserID = c.Int(),
                        Num_Guests = c.Int(),
                        Discount = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Tour_Num);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminTours");
        }
    }
}
