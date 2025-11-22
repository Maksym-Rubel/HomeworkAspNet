using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Addpwe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemWeekDays_Items_ItemId",
                table: "ItemWeekDays");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemWeekDays_WeekDays_DaysId",
                table: "ItemWeekDays");

            migrationBuilder.DropIndex(
                name: "IX_ItemWeekDays_DaysId",
                table: "ItemWeekDays");

            migrationBuilder.DropIndex(
                name: "IX_ItemWeekDays_ItemId",
                table: "ItemWeekDays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemWeekDays_DaysId",
                table: "ItemWeekDays",
                column: "DaysId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemWeekDays_ItemId",
                table: "ItemWeekDays",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemWeekDays_Items_ItemId",
                table: "ItemWeekDays",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemWeekDays_WeekDays_DaysId",
                table: "ItemWeekDays",
                column: "DaysId",
                principalTable: "WeekDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
