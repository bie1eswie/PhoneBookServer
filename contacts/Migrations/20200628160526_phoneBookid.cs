using Microsoft.EntityFrameworkCore.Migrations;

namespace contacts.Migrations
{
    public partial class phoneBookid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhoneBooks_PhoneBookid",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneBookid",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhoneBooks_PhoneBookid",
                table: "Contacts",
                column: "PhoneBookid",
                principalTable: "PhoneBooks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhoneBooks_PhoneBookid",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneBookid",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhoneBooks_PhoneBookid",
                table: "Contacts",
                column: "PhoneBookid",
                principalTable: "PhoneBooks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
