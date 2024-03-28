using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO.Data.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "VaccineNum",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "Producer",
                table: "Vaccination",
                newName: "ProducerID");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Vaccination",
                newName: "PatientIdID");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Illness",
                newName: "PatientIdID");

            migrationBuilder.RenameColumn(
                name: "StreetID",
                table: "Address",
                newName: "StreetIDID");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "Address",
                newName: "CityIDID");

            migrationBuilder.AddColumn<int>(
                name: "CitiesID",
                table: "Streets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_PatientIdID",
                table: "Vaccination",
                column: "PatientIdID");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_ProducerID",
                table: "Vaccination",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CitiesID",
                table: "Streets",
                column: "CitiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Illness_PatientIdID",
                table: "Illness",
                column: "PatientIdID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityIDID",
                table: "Address",
                column: "CityIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetIDID",
                table: "Address",
                column: "StreetIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Cities_CityIDID",
                table: "Address",
                column: "CityIDID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Streets_StreetIDID",
                table: "Address",
                column: "StreetIDID",
                principalTable: "Streets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Illness_Patient_PatientIdID",
                table: "Illness",
                column: "PatientIdID",
                principalTable: "Patient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_Cities_CitiesID",
                table: "Streets",
                column: "CitiesID",
                principalTable: "Cities",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccination_Patient_PatientIdID",
                table: "Vaccination",
                column: "PatientIdID",
                principalTable: "Patient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccination_Producer_ProducerID",
                table: "Vaccination",
                column: "ProducerID",
                principalTable: "Producer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Cities_CityIDID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Streets_StreetIDID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Illness_Patient_PatientIdID",
                table: "Illness");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_Cities_CitiesID",
                table: "Streets");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccination_Patient_PatientIdID",
                table: "Vaccination");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccination_Producer_ProducerID",
                table: "Vaccination");

            migrationBuilder.DropIndex(
                name: "IX_Vaccination_PatientIdID",
                table: "Vaccination");

            migrationBuilder.DropIndex(
                name: "IX_Vaccination_ProducerID",
                table: "Vaccination");

            migrationBuilder.DropIndex(
                name: "IX_Streets_CitiesID",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_Illness_PatientIdID",
                table: "Illness");

            migrationBuilder.DropIndex(
                name: "IX_Address_CityIDID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StreetIDID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CitiesID",
                table: "Streets");

            migrationBuilder.RenameColumn(
                name: "ProducerID",
                table: "Vaccination",
                newName: "Producer");

            migrationBuilder.RenameColumn(
                name: "PatientIdID",
                table: "Vaccination",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "PatientIdID",
                table: "Illness",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "StreetIDID",
                table: "Address",
                newName: "StreetID");

            migrationBuilder.RenameColumn(
                name: "CityIDID",
                table: "Address",
                newName: "CityID");

            migrationBuilder.AddColumn<int>(
                name: "CityName",
                table: "Streets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VaccineNum",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
