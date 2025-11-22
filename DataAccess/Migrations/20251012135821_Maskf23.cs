using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Maskf23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsControlWork",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "IsControlWork",
                table: "homeWorkItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsControlWork",
                table: "homeWorkItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsControlWork",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
