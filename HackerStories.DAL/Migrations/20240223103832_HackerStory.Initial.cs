using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HackerStories.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HackerStoryInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "Image", "Time", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "Description 1", "/story-images/hacker-story-uniqueId-1.jpg", new DateTime(2024, 2, 23, 16, 8, 32, 236, DateTimeKind.Local).AddTicks(5749), "Title 1", "/story/1" },
                    { 2, "Description 2", "/story-images/hacker-story-uniqueId-2.jpg", new DateTime(2024, 2, 23, 16, 8, 32, 236, DateTimeKind.Local).AddTicks(5765), "Title 2", "/story/2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}
