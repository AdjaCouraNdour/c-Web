using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionBoutiqueWeb.Migrations
{
    /// <inheritdoc />
    public partial class Fixtures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dettes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dettes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EtatDette",
                table: "Dettes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeDette",
                table: "Dettes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<int>(type: "int", nullable: false),
                    QteStock = table.Column<double>(type: "float", nullable: false),
                    EtatArticle = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DetteId = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paiements_Dettes_DetteId",
                        column: x => x.DetteId,
                        principalTable: "Dettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QteDette = table.Column<double>(type: "float", nullable: false),
                    DetteId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_Dettes_DetteId",
                        column: x => x.DetteId,
                        principalTable: "Dettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CreateAt", "EtatArticle", "Libelle", "Prix", "QteStock", "Reference", "UpdateAt" },
                values: new object[] { 1, new DateTime(2024, 11, 13, 23, 15, 33, 49, DateTimeKind.Local).AddTicks(8612), 0, "Bonbon Jina", 100, 50.0, "A00001", new DateTime(2024, 11, 13, 23, 15, 33, 49, DateTimeKind.Local).AddTicks(8614) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 11, 13, 23, 15, 33, 44, DateTimeKind.Local).AddTicks(3654), new DateTime(2024, 11, 13, 23, 15, 33, 44, DateTimeKind.Local).AddTicks(4640) });

            migrationBuilder.UpdateData(
                table: "Dettes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Date", "EtatDette", "TypeDette", "UpdateAt" },
                values: new object[] { new DateTime(2024, 11, 13, 23, 15, 33, 48, DateTimeKind.Local).AddTicks(3249), new DateTime(2024, 10, 13, 23, 15, 33, 48, DateTimeKind.Local).AddTicks(3846), 0, 0, new DateTime(2024, 11, 13, 23, 15, 33, 48, DateTimeKind.Local).AddTicks(3255) });

            migrationBuilder.InsertData(
                table: "Paiements",
                columns: new[] { "Id", "CreateAt", "Date", "DetteId", "Montant", "UpdateAt" },
                values: new object[] { 1, new DateTime(2024, 11, 13, 23, 15, 33, 54, DateTimeKind.Local).AddTicks(3412), new DateTime(2024, 11, 13, 23, 15, 33, 54, DateTimeKind.Local).AddTicks(5247), 1, 200.0, new DateTime(2024, 11, 13, 23, 15, 33, 54, DateTimeKind.Local).AddTicks(3418) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt", "UserRole" },
                values: new object[] { new DateTime(2024, 11, 13, 23, 15, 33, 47, DateTimeKind.Local).AddTicks(2099), new DateTime(2024, 11, 13, 23, 15, 33, 47, DateTimeKind.Local).AddTicks(2105), 1 });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "ArticleId", "CreateAt", "DetteId", "QteDette", "UpdateAt" },
                values: new object[] { 1, 1, new DateTime(2024, 11, 13, 23, 15, 33, 49, DateTimeKind.Local).AddTicks(607), 1, 5.0, new DateTime(2024, 11, 13, 23, 15, 33, 49, DateTimeKind.Local).AddTicks(608) });

            migrationBuilder.CreateIndex(
                name: "IX_Details_ArticleId",
                table: "Details",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_DetteId",
                table: "Details",
                column: "DetteId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_DetteId",
                table: "Paiements",
                column: "DetteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EtatDette",
                table: "Dettes");

            migrationBuilder.DropColumn(
                name: "TypeDette",
                table: "Dettes");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 11, 13, 19, 2, 27, 101, DateTimeKind.Local).AddTicks(7389), new DateTime(2024, 11, 13, 19, 2, 27, 101, DateTimeKind.Local).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "Dettes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Date", "UpdateAt" },
                values: new object[] { new DateTime(2024, 11, 13, 19, 2, 27, 107, DateTimeKind.Local).AddTicks(4793), new DateTime(2024, 10, 13, 19, 2, 27, 107, DateTimeKind.Local).AddTicks(5674), new DateTime(2024, 11, 13, 19, 2, 27, 107, DateTimeKind.Local).AddTicks(4798) });

            migrationBuilder.InsertData(
                table: "Dettes",
                columns: new[] { "Id", "ClientId", "CreateAt", "Date", "Montant", "MontantRestant", "MontantVerse", "UpdateAt" },
                values: new object[] { 3, 1, new DateTime(2024, 11, 13, 19, 2, 27, 107, DateTimeKind.Local).AddTicks(8415), new DateTime(2024, 8, 13, 19, 2, 27, 107, DateTimeKind.Local).AddTicks(8417), 750.0, 0.0, 750.0, new DateTime(2024, 11, 13, 19, 2, 27, 107, DateTimeKind.Local).AddTicks(8416) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 11, 13, 19, 2, 27, 106, DateTimeKind.Local).AddTicks(2448), new DateTime(2024, 11, 13, 19, 2, 27, 106, DateTimeKind.Local).AddTicks(2462) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "ClientId", "CreateAt", "Email", "Login", "Password", "UpdateAt" },
                values: new object[,]
                {
                    { 2, true, 2, new DateTime(2024, 11, 13, 19, 2, 27, 106, DateTimeKind.Local).AddTicks(3265), "user1@example.com", "user1", "user1", new DateTime(2024, 11, 13, 19, 2, 27, 106, DateTimeKind.Local).AddTicks(3266) },
                    { 3, false, 3, new DateTime(2024, 11, 13, 19, 2, 27, 106, DateTimeKind.Local).AddTicks(3276), "Boutiquier@example.com", "Boutiquier", "Boutiquier", new DateTime(2024, 11, 13, 19, 2, 27, 106, DateTimeKind.Local).AddTicks(3277) }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "CreateAt", "Surnom", "Telephone", "UpdateAt", "UserId" },
                values: new object[,]
                {
                    { 2, "456 Rue de Lyon", new DateTime(2024, 11, 13, 19, 2, 27, 103, DateTimeKind.Local).AddTicks(303), "coura", "77479944", new DateTime(2024, 11, 13, 19, 2, 27, 103, DateTimeKind.Local).AddTicks(304), 2 },
                    { 3, "789 Rue de Marseille", new DateTime(2024, 11, 13, 19, 2, 27, 103, DateTimeKind.Local).AddTicks(313), "loulou", "774799473", new DateTime(2024, 11, 13, 19, 2, 27, 103, DateTimeKind.Local).AddTicks(314), 3 }
                });

            migrationBuilder.InsertData(
                table: "Dettes",
                columns: new[] { "Id", "ClientId", "CreateAt", "Date", "Montant", "MontantRestant", "MontantVerse", "UpdateAt" },
                values: new object[] { 2, 2, new DateTime(2024, 11, 13, 19, 2, 27, 107, DateTimeKind.Local).AddTicks(8388), new DateTime(2024, 9, 13, 19, 2, 27, 107, DateTimeKind.Local).AddTicks(8391), 1200.0, 700.0, 500.0, new DateTime(2024, 11, 13, 19, 2, 27, 107, DateTimeKind.Local).AddTicks(8390) });
        }
    }
}
