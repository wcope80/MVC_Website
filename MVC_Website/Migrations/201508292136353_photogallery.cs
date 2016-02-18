namespace MVC_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photogallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhotoGalleries",
                c => new
                    {
                        PhotoID = c.Guid(nullable: false),
                        Name = c.String(),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.PhotoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhotoGalleries");
        }
    }
}
