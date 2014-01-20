namespace CateringApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAdditions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        MenuID = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FoodID)
                .ForeignKey("dbo.Menu", t => t.MenuID, cascadeDelete: true)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.MenuID)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        TownID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantID)
                .ForeignKey("dbo.Town", t => t.TownID, cascadeDelete: true)
                .Index(t => t.TownID);
            
            CreateTable(
                "dbo.Town",
                c => new
                    {
                        TownID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TownID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Restaurant", new[] { "TownID" });
            DropIndex("dbo.Food", new[] { "RestaurantID" });
            DropIndex("dbo.Food", new[] { "MenuID" });
            DropForeignKey("dbo.Restaurant", "TownID", "dbo.Town");
            DropForeignKey("dbo.Food", "RestaurantID", "dbo.Restaurant");
            DropForeignKey("dbo.Food", "MenuID", "dbo.Menu");
            DropTable("dbo.Town");
            DropTable("dbo.Restaurant");
            DropTable("dbo.Menu");
            DropTable("dbo.Food");
        }
    }
}
