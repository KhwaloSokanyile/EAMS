using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ReturnedSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "ReturnedSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemName",
                table: "ReturnedSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "buildsystemId",
                table: "ReturnedSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ResolvedTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ticketId",
                table: "ResolvedTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BuildSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "BuildSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemName",
                table: "BuildSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AssignedTickets",
                columns: table => new
                {
                    AssignedTicketsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminId = table.Column<int>(type: "int", nullable: false),
                    ticketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedTickets", x => x.AssignedTicketsId);
                    table.ForeignKey(
                        name: "FK_AssignedTickets_Admins_adminId",
                        column: x => x.adminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssignedTickets_Tickets_ticketId",
                        column: x => x.ticketId,
                        principalTable: "Tickets",
                        principalColumn: "TickectID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ReturnedAssets",
                columns: table => new
                {
                    ReturnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminId = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    assetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnedAssets", x => x.ReturnID);
                    table.ForeignKey(
                        name: "FK_ReturnedAssets_Admins_adminId",
                        column: x => x.adminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ReturnedAssets_Assets_assetId",
                        column: x => x.assetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ReturnedAssets_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedSystems_buildsystemId",
                table: "ReturnedSystems",
                column: "buildsystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ResolvedTickets_ticketId",
                table: "ResolvedTickets",
                column: "ticketId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTickets_adminId",
                table: "AssignedTickets",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTickets_ticketId",
                table: "AssignedTickets",
                column: "ticketId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedAssets_adminId",
                table: "ReturnedAssets",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedAssets_assetId",
                table: "ReturnedAssets",
                column: "assetId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedAssets_employeeId",
                table: "ReturnedAssets",
                column: "employeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResolvedTickets_Tickets_ticketId",
                table: "ResolvedTickets",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "TickectID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnedSystems_BuildSystems_buildsystemId",
                table: "ReturnedSystems",
                column: "buildsystemId",
                principalTable: "BuildSystems",
                principalColumn: "BuildID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResolvedTickets_Tickets_ticketId",
                table: "ResolvedTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnedSystems_BuildSystems_buildsystemId",
                table: "ReturnedSystems");

            migrationBuilder.DropTable(
                name: "AssignedTickets");

            migrationBuilder.DropTable(
                name: "ReturnedAssets");

            migrationBuilder.DropIndex(
                name: "IX_ReturnedSystems_buildsystemId",
                table: "ReturnedSystems");

            migrationBuilder.DropIndex(
                name: "IX_ResolvedTickets_ticketId",
                table: "ResolvedTickets");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ReturnedSystems");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "ReturnedSystems");

            migrationBuilder.DropColumn(
                name: "SystemName",
                table: "ReturnedSystems");

            migrationBuilder.DropColumn(
                name: "buildsystemId",
                table: "ReturnedSystems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ResolvedTickets");

            migrationBuilder.DropColumn(
                name: "ticketId",
                table: "ResolvedTickets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BuildSystems");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "BuildSystems");

            migrationBuilder.DropColumn(
                name: "SystemName",
                table: "BuildSystems");
        }
    }
}
