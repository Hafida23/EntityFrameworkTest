using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkTest.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    SurName = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Published = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Name", "SurName" },
                values: new object[,]
                {
                    { 1, "Alfredo ", "Covelli" },
                    { 2, "Ramachandra ", "Guha" },
                    { 3, "Waman Subha ", "Prabhu" },
                    { 4, "Dalai ", "Lama" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Published", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vahana Masterclass" },
                    { 2, new DateTime(2000, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Right Under Our Nose" },
                    { 3, new DateTime(1986, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Commonwealth of Cricket" },
                    { 4, new DateTime(2005, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Little Book of Encouragement" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Florian", "Esprit" },
                    { 2, "Sagar", "Bhanadari" },
                    { 3, "Olga", "Kharchuk" },
                    { 4, "Akin", "Baroti" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
