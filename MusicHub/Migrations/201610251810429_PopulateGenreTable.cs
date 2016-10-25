namespace MusicHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Id,Name) VALUES (1,'Blues')");
            Sql("Insert Into Genres (Id,Name) VALUES (2,'Jazz')");
            Sql("Insert Into Genres (Id,Name) VALUES (3,'Rock')");
            Sql("Insert Into Genres (Id,Name) VALUES (4,'Country')");
        }

        public override void Down()
        {
            Sql("Delete from Genres where id In (1,2,3,4)");
        }
    }
}
