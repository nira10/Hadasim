using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO.Data.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Patient",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Patient",
                newName: "Adress");
        }
    }
}
