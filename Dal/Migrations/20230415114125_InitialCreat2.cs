using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Room_RoomIdId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoomIdId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoomIdId",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomDalId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Mode",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoomDalId",
                table: "User",
                column: "RoomDalId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Room_RoomDalId",
                table: "User",
                column: "RoomDalId",
                principalTable: "Room",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Room_RoomDalId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoomDalId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoomDalId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Mode");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomIdId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_RoomIdId",
                table: "User",
                column: "RoomIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Room_RoomIdId",
                table: "User",
                column: "RoomIdId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
