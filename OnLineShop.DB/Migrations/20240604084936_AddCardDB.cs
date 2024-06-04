using Microsoft.EntityFrameworkCore.Migrations;

namespace OnLineShop.DB.Migrations
{
    public partial class AddCardDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDBItems_CartDBs_CartDBId",
                table: "CardDBItems");

            migrationBuilder.AlterColumn<int>(
                name: "CartDBId",
                table: "CardDBItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CardDBItems_CartDBs_CartDBId",
                table: "CardDBItems",
                column: "CartDBId",
                principalTable: "CartDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDBItems_CartDBs_CartDBId",
                table: "CardDBItems");

            migrationBuilder.AlterColumn<int>(
                name: "CartDBId",
                table: "CardDBItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDBItems_CartDBs_CartDBId",
                table: "CardDBItems",
                column: "CartDBId",
                principalTable: "CartDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
