using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    PublicationYear = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    AvailableStock = table.Column<int>(nullable: false),
                    IsBestSeller = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
