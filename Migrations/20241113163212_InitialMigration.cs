using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionBoutiqueWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actif = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surnom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false),
                    MontantVerse = table.Column<double>(type: "float", nullable: false),
                    MontantRestant = table.Column<double>(type: "float", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dettes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "CreateAt", "Surnom", "Telephone", "UpdateAt", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Rue de Paris", new DateTime(2024, 11, 13, 16, 32, 11, 523, DateTimeKind.Local).AddTicks(2294), "kiki", "774799479", new DateTime(2024, 11, 13, 16, 32, 11, 523, DateTimeKind.Local).AddTicks(3872), 0 },
                    { 2, "456 Rue de Lyon", new DateTime(2024, 11, 13, 16, 32, 11, 523, DateTimeKind.Local).AddTicks(6323), "coura", "77479944", new DateTime(2024, 11, 13, 16, 32, 11, 523, DateTimeKind.Local).AddTicks(6324), 0 },
                    { 3, "789 Rue de Marseille", new DateTime(2024, 11, 13, 16, 32, 11, 523, DateTimeKind.Local).AddTicks(6330), "loulou", "774799473", new DateTime(2024, 11, 13, 16, 32, 11, 523, DateTimeKind.Local).AddTicks(6331), 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "ClientId", "CreateAt", "Email", "Login", "Password", "UpdateAt" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2024, 11, 13, 16, 32, 11, 525, DateTimeKind.Local).AddTicks(9316), "admin@example.com", "admin", "admin", new DateTime(2024, 11, 13, 16, 32, 11, 525, DateTimeKind.Local).AddTicks(9320) },
                    { 2, true, 2, new DateTime(2024, 11, 13, 16, 32, 11, 525, DateTimeKind.Local).AddTicks(9789), "user1@example.com", "user1", "user1", new DateTime(2024, 11, 13, 16, 32, 11, 525, DateTimeKind.Local).AddTicks(9790) },
                    { 3, false, 3, new DateTime(2024, 11, 13, 16, 32, 11, 525, DateTimeKind.Local).AddTicks(9797), "Boutiquier@example.com", "Boutiquier", "Boutiquier", new DateTime(2024, 11, 13, 16, 32, 11, 525, DateTimeKind.Local).AddTicks(9798) }
                });

            migrationBuilder.InsertData(
                table: "Dettes",
                columns: new[] { "Id", "ClientId", "CreateAt", "Date", "Montant", "MontantRestant", "MontantVerse", "UpdateAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 13, 16, 32, 11, 526, DateTimeKind.Local).AddTicks(8419), new DateTime(2024, 10, 13, 16, 32, 11, 526, DateTimeKind.Local).AddTicks(8421), 500.0, 300.0, 200.0, new DateTime(2024, 11, 13, 16, 32, 11, 526, DateTimeKind.Local).AddTicks(8420) },
                    { 2, 2, new DateTime(2024, 11, 13, 16, 32, 11, 527, DateTimeKind.Local).AddTicks(1164), new DateTime(2024, 9, 13, 16, 32, 11, 527, DateTimeKind.Local).AddTicks(1166), 1200.0, 700.0, 500.0, new DateTime(2024, 11, 13, 16, 32, 11, 527, DateTimeKind.Local).AddTicks(1165) },
                    { 3, 1, new DateTime(2024, 11, 13, 16, 32, 11, 527, DateTimeKind.Local).AddTicks(1191), new DateTime(2024, 8, 13, 16, 32, 11, 527, DateTimeKind.Local).AddTicks(1192), 750.0, 0.0, 750.0, new DateTime(2024, 11, 13, 16, 32, 11, 527, DateTimeKind.Local).AddTicks(1192) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dettes_ClientId",
                table: "Dettes",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dettes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
