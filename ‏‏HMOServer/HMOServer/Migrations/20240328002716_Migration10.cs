using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO.API.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Positive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recovery = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vaccination",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientIdID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccination", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vaccination_Patient_PatientIdID",
                        column: x => x.PatientIdID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccination_Producer_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_PatientIdID",
                table: "Vaccination",
                column: "PatientIdID");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_ProducerID",
                table: "Vaccination",
                column: "ProducerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccination");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Producer");
        }
    }
}
