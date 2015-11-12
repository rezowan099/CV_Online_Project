namespace CV_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmploymentHistories", "To", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProfessionalQualifications", "From", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProfessionalQualifications", "To", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProfessionalQualifications", "To", c => c.String(nullable: false));
            AlterColumn("dbo.ProfessionalQualifications", "From", c => c.String(nullable: false));
            AlterColumn("dbo.EmploymentHistories", "To", c => c.DateTime());
        }
    }
}
