using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSDotNet.DAL.Migrations
{
    public partial class updateBookingHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistories_Users_UserId",
                table: "BookingHistories");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "BookingHistories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "BookingHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistories_RoomId",
                table: "BookingHistories",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistories_Rooms_RoomId",
                table: "BookingHistories",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistories_Users_UserId",
                table: "BookingHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistories_Rooms_RoomId",
                table: "BookingHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistories_Users_UserId",
                table: "BookingHistories");

            migrationBuilder.DropIndex(
                name: "IX_BookingHistories_RoomId",
                table: "BookingHistories");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "BookingHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "BookingHistories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistories_Users_UserId",
                table: "BookingHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
