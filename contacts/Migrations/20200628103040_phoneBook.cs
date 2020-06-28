using Microsoft.EntityFrameworkCore.Migrations;

namespace contacts.Migrations
{
    public partial class phoneBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhoneBookid",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhoneBook",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBook", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PhoneBookid",
                table: "Contacts",
                column: "PhoneBookid");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhoneBook_PhoneBookid",
                table: "Contacts",
                column: "PhoneBookid",
                principalTable: "PhoneBook",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhoneBook_PhoneBookid",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "PhoneBook");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PhoneBookid",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PhoneBookid",
                table: "Contacts");
        }
    }
}
