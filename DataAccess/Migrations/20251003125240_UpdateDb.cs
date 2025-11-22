using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemWeekDays_WeekDays_DayId",
                table: "ItemWeekDays");

            migrationBuilder.DropColumn(
                name: "DaysId",
                table: "ItemWeekDays");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "ItemWeekDays",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemWeekDays_WeekDays_DayId",
                table: "ItemWeekDays",
                column: "DayId",
                principalTable: "WeekDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemWeekDays_WeekDays_DayId",
                table: "ItemWeekDays");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "ItemWeekDays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DaysId",
                table: "ItemWeekDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemWeekDays_WeekDays_DayId",
                table: "ItemWeekDays",
                column: "DayId",
                principalTable: "WeekDays",
                principalColumn: "Id");
        }
    }
}
