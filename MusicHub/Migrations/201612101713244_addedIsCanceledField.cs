namespace MusicHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addedIsCanceledField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "IsCanceled", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Gigs", "IsCanceled");
        }
    }
}
