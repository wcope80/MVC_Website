namespace MVC_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMessages : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.MaxAttempts",
            //    c => new
            //        {
            //            MaxAttemptId = c.Int(nullable: false, identity: true),
            //            Exercise = c.String(),
            //            Weight = c.Int(nullable: false),
            //            Reps = c.Int(nullable: false),
            //            CalculatedMax = c.Int(nullable: false),
            //            MaxDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.MaxAttemptId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Subject = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
            DropTable("dbo.MaxAttempts");
        }
    }
}
