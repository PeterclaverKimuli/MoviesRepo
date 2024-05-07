using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES('Action')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Family')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
