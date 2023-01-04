using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    public partial class AddedTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SignUp",
                table: "SignUp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SignIn",
                table: "SignIn");

            migrationBuilder.RenameTable(
                name: "SignUp",
                newName: "SignUps");

            migrationBuilder.RenameTable(
                name: "SignIn",
                newName: "SignIns");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignUps",
                table: "SignUps",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignIns",
                table: "SignIns",
                column: "Email");

            migrationBuilder.CreateTable(
                name: "ResolvedTickets",
                columns: table => new
                {
                    ResolveTickectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resolved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResolvedTickets", x => x.ResolveTickectID);
                    table.ForeignKey(
                        name: "FK_ResolvedTickets_Admins_adminId",
                        column: x => x.adminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TickectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminId = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TickectID);
                    table.ForeignKey(
                        name: "FK_Tickets_Admins_adminId",
                        column: x => x.adminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResolvedTickets_adminId",
                table: "ResolvedTickets",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_adminId",
                table: "Tickets",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_employeeId",
                table: "Tickets",
                column: "employeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResolvedTickets");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SignUps",
                table: "SignUps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SignIns",
                table: "SignIns");

            migrationBuilder.RenameTable(
                name: "SignUps",
                newName: "SignUp");

            migrationBuilder.RenameTable(
                name: "SignIns",
                newName: "SignIn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignUp",
                table: "SignUp",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignIn",
                table: "SignIn",
                column: "Email");
        }
    }
}
