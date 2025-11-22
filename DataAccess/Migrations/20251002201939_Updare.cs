using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Updare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemWeekDays_WeekDays_WeekDayId",
                table: "ItemWeekDays");

            migrationBuilder.DropIndex(
                name: "IX_ItemWeekDays_WeekDayId",
                table: "ItemWeekDays");

            migrationBuilder.DropColumn(
                name: "WeekDayId",
                table: "ItemWeekDays");

            migrationBuilder.CreateIndex(
                name: "IX_ItemWeekDays_DaysId",
                table: "ItemWeekDays",
                column: "DaysId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemWeekDays_WeekDays_DaysId",
                table: "ItemWeekDays",
                column: "DaysId",
                principalTable: "WeekDays",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemWeekDays_WeekDays_DaysId",
                table: "ItemWeekDays");

            migrationBuilder.DropIndex(
                name: "IX_ItemWeekDays_DaysId",
                table: "ItemWeekDays");

            migrationBuilder.AddColumn<int>(
                name: "WeekDayId",
                table: "ItemWeekDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemWeekDays_WeekDayId",
                table: "ItemWeekDays",
                column: "WeekDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemWeekDays_WeekDays_WeekDayId",
                table: "ItemWeekDays",
                column: "WeekDayId",
                principalTable: "WeekDays",
                principalColumn: "Id");
        }
    }
}
