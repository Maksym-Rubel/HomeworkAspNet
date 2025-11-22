using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "ItemWeekDays",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemWeekDays_DayId",
                table: "ItemWeekDays",
                column: "DayId");

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
                name: "FK_ItemWeekDays_WeekDays_DayId",
                table: "ItemWeekDays",
                column: "DayId",
                principalTable: "WeekDays",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemWeekDays_Items_ItemId",
                table: "ItemWeekDays");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemWeekDays_WeekDays_DayId",
                table: "ItemWeekDays");

            migrationBuilder.DropIndex(
                name: "IX_ItemWeekDays_DayId",
                table: "ItemWeekDays");

            migrationBuilder.DropIndex(
                name: "IX_ItemWeekDays_ItemId",
                table: "ItemWeekDays");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "ItemWeekDays");
        }
    }
}
