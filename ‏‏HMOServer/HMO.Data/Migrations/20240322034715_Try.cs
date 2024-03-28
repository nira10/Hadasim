using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO.Data.Migrations
{
    public partial class Try : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Patient",
                newName: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AddressID",
                table: "Patient",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Address_AddressID",
                table: "Patient",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Address_AddressID",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_AddressID",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Patient",
                newName: "Address");
        }
    }
}
