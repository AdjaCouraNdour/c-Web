using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionBoutiqueWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndFixtures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actif = table.Column<bool>(type: "bit", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
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
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    TypeDette = table.Column<int>(type: "int", nullable: false),
                    EtatDette = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CreateAt", "EtatArticle", "Libelle", "Prix", "QteStock", "Reference", "UpdateAt" },
                values: new object[] { 1, new DateTime(2024, 11, 17, 23, 50, 47, 843, DateTimeKind.Local).AddTicks(7765), 0, "Bonbon Jina", 100, 50.0, "A00001", new DateTime(2024, 11, 17, 23, 50, 47, 843, DateTimeKind.Local).AddTicks(7766) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "ClientId", "CreateAt", "Email", "Login", "Password", "UpdateAt", "UserRole" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2024, 11, 17, 23, 50, 47, 840, DateTimeKind.Local).AddTicks(7431), "admin@example.com", "admin", "admin", new DateTime(2024, 11, 17, 23, 50, 47, 840, DateTimeKind.Local).AddTicks(7436), 1 },
                    { 2, true, 2, new DateTime(2024, 11, 17, 23, 50, 47, 840, DateTimeKind.Local).AddTicks(8348), "boutiquier@example.com", "boutiquier", "boutiquier", new DateTime(2024, 11, 17, 23, 50, 47, 840, DateTimeKind.Local).AddTicks(8349), 1 },
                    { 3, true, 3, new DateTime(2024, 11, 17, 23, 50, 47, 840, DateTimeKind.Local).AddTicks(8356), "client@example.com", "client", "client", new DateTime(2024, 11, 17, 23, 50, 47, 840, DateTimeKind.Local).AddTicks(8356), 1 },
                    { 4, true, 4, new DateTime(2024, 11, 17, 23, 50, 47, 840, DateTimeKind.Local).AddTicks(8361), "padma@example.com", "padma", "padma", new DateTime(2024, 11, 17, 23, 50, 47, 840, DateTimeKind.Local).AddTicks(8362), 1 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "CreateAt", "Surnom", "Telephone", "UpdateAt", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Rue de Paris", new DateTime(2024, 11, 17, 23, 50, 47, 838, DateTimeKind.Local).AddTicks(1999), "kiki", "774799479", new DateTime(2024, 11, 17, 23, 50, 47, 838, DateTimeKind.Local).AddTicks(3398), 1 },
                    { 2, "123 Rue de Dakar", new DateTime(2024, 11, 17, 23, 50, 47, 838, DateTimeKind.Local).AddTicks(6448), "Adja Coura", "774790479", new DateTime(2024, 11, 17, 23, 50, 47, 838, DateTimeKind.Local).AddTicks(6449), 2 },
                    { 3, " Saint Louis", new DateTime(2024, 11, 17, 23, 50, 47, 838, DateTimeKind.Local).AddTicks(6454), "Annha", "774799409", new DateTime(2024, 11, 17, 23, 50, 47, 838, DateTimeKind.Local).AddTicks(6455), 3 },
                    { 4, " Saint Louis", new DateTime(2024, 11, 17, 23, 50, 47, 838, DateTimeKind.Local).AddTicks(6459), "Padama", "770009409", new DateTime(2024, 11, 17, 23, 50, 47, 838, DateTimeKind.Local).AddTicks(6459), 4 }
                });

            migrationBuilder.InsertData(
                table: "Dettes",
                columns: new[] { "Id", "ClientId", "CreateAt", "Date", "EtatDette", "Montant", "MontantRestant", "MontantVerse", "TypeDette", "UpdateAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 17, 23, 50, 47, 841, DateTimeKind.Local).AddTicks(6778), new DateTime(2024, 10, 17, 23, 50, 47, 841, DateTimeKind.Local).AddTicks(7520), 0, 500.0, 300.0, 200.0, 0, new DateTime(2024, 11, 17, 23, 50, 47, 841, DateTimeKind.Local).AddTicks(6782) },
                    { 2, 2, new DateTime(2024, 11, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(920), new DateTime(2024, 10, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(923), 0, 500.0, 300.0, 200.0, 0, new DateTime(2024, 11, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(921) },
                    { 3, 2, new DateTime(2024, 11, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(946), new DateTime(2024, 10, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(948), 0, 500.0, 300.0, 200.0, 0, new DateTime(2024, 11, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(947) },
                    { 4, 3, new DateTime(2024, 11, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(953), new DateTime(2024, 10, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(954), 0, 500.0, 300.0, 200.0, 0, new DateTime(2024, 11, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(953) }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "ArticleId", "CreateAt", "DetteId", "QteDette", "UpdateAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(7991), 1, 5.0, new DateTime(2024, 11, 17, 23, 50, 47, 842, DateTimeKind.Local).AddTicks(7994) },
                    { 2, 1, new DateTime(2024, 11, 17, 23, 50, 47, 843, DateTimeKind.Local).AddTicks(239), 2, 5.0, new DateTime(2024, 11, 17, 23, 50, 47, 843, DateTimeKind.Local).AddTicks(243) },
                    { 3, 1, new DateTime(2024, 11, 17, 23, 50, 47, 843, DateTimeKind.Local).AddTicks(248), 3, 5.0, new DateTime(2024, 11, 17, 23, 50, 47, 843, DateTimeKind.Local).AddTicks(249) },
                    { 4, 1, new DateTime(2024, 11, 17, 23, 50, 47, 843, DateTimeKind.Local).AddTicks(253), 4, 5.0, new DateTime(2024, 11, 17, 23, 50, 47, 843, DateTimeKind.Local).AddTicks(255) }
                });

            migrationBuilder.InsertData(
                table: "Paiements",
                columns: new[] { "Id", "CreateAt", "Date", "DetteId", "Montant", "UpdateAt" },
                values: new object[] { 1, new DateTime(2024, 11, 17, 23, 50, 47, 846, DateTimeKind.Local).AddTicks(7838), new DateTime(2024, 11, 17, 23, 50, 47, 846, DateTimeKind.Local).AddTicks(9423), 1, 200.0, new DateTime(2024, 11, 17, 23, 50, 47, 846, DateTimeKind.Local).AddTicks(7841) });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ArticleId",
                table: "Details",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_DetteId",
                table: "Details",
                column: "DetteId");

            migrationBuilder.CreateIndex(
                name: "IX_Dettes_ClientId",
                table: "Dettes",
                column: "ClientId");

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

            migrationBuilder.DropTable(
                name: "Dettes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
