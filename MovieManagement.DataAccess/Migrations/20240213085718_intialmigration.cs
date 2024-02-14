using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class intialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biographys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biographys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biographys_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Tom", "Hanks" },
                    { 2, "Meryl", "Streep" },
                    { 3, "Leonardo", "DiCaprio" },
                    { 4, "Charlize", "Theron" },
                    { 5, "Brad", "Pitt" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Comedy" },
                    { 4, "Drama" },
                    { 5, "Fantasy" },
                    { 6, "Horror" },
                    { 7, "Mystery" },
                    { 8, "Romance" },
                    { 9, "Sci-Fi" },
                    { 10, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ActorId", "Description", "GenreId", "Language", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "A man with a low IQ accomplishes great things in his life.", 1, 0, "Forrest Gump", 2 },
                    { 2, 2, "A smart but sensible new graduate lands a job as an assistant to Miranda Priestly, the demanding editor-in-chief of a high-fashion magazine.", 4, 0, "The Devil Wears Prada", 1 },
                    { 3, 3, "A thief who enters the dreams of others to steal their secrets.", 2, 0, "Inception", 2 },
                    { 4, 4, "In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler in search of her homeland.", 3, 0, "Mad Max: Fury Road", 3 },
                    { 5, 5, "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", 4, 0, "Fight Club", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biographys_ActorId",
                table: "Biographys",
                column: "ActorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ActorId",
                table: "Movies",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biographys");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
