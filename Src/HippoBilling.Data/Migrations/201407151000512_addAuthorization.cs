namespace HippoBilling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAuthorization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Insurance1 = c.String(),
                        Insurance2 = c.String(),
                        dx = c.String(),
                        cpt = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Location_Id = c.Guid(),
                        Patient_Id = c.Guid(),
                        Provider_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .ForeignKey("dbo.Providers", t => t.Provider_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.Provider_Id);
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Authorizations", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.Authorizations", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Authorizations", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Authorizations", new[] { "Provider_Id" });
            DropIndex("dbo.Authorizations", new[] { "Patient_Id" });
            DropIndex("dbo.Authorizations", new[] { "Location_Id" });
            DropTable("dbo.Authorizations");
        }
    }
}
