using Microsoft.EntityFrameworkCore.Migrations;

namespace UniqueString.Infrastructure.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniqueString",
                columns: table => new
                {
                    Text = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueString", x => x.Text);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniqueString_Text",
                table: "UniqueString",
                column: "Text",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniqueString");
        }
    }
}
