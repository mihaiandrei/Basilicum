using Microsoft.EntityFrameworkCore.Migrations;

namespace Basilicum.Server.Migrations
{
    public partial class AddAccuracy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Accuracy",
                table: "Parameter",
                nullable: false,
                defaultValue: 0.001);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accuracy",
                table: "Parameter");
        }
    }
}
