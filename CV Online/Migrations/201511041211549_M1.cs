namespace CV_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmploymentHistories", "From", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmploymentHistories", "To", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmploymentHistories", "To", c => c.String());
            AlterColumn("dbo.EmploymentHistories", "From", c => c.String(nullable: false));
        }
    }
}
