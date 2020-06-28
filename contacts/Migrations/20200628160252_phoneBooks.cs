using Microsoft.EntityFrameworkCore.Migrations;

namespace contacts.Migrations
{
    public partial class phoneBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhoneBook_PhoneBookid",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneBook",
                table: "PhoneBook");

            migrationBuilder.RenameTable(
                name: "PhoneBook",
                newName: "PhoneBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneBooks",
                table: "PhoneBooks",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhoneBooks_PhoneBookid",
                table: "Contacts",
                column: "PhoneBookid",
                principalTable: "PhoneBooks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhoneBooks_PhoneBookid",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneBooks",
                table: "PhoneBooks");

            migrationBuilder.RenameTable(
                name: "PhoneBooks",
                newName: "PhoneBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneBook",
                table: "PhoneBook",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhoneBook_PhoneBookid",
                table: "Contacts",
                column: "PhoneBookid",
                principalTable: "PhoneBook",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
