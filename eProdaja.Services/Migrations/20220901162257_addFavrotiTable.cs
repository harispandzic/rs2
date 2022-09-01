using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eProdaja.Services.Migrations
{
    public partial class addFavrotiTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favoriti",
                columns: table => new
                {
                    FavoritiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProizvodId = table.Column<int>(type: "int", nullable: false),
                    KorisniciId = table.Column<int>(type: "int", nullable: false),
                    datumFavorita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoriti", x => x.FavoritiId);
                    table.ForeignKey(
                        name: "FK_Favoriti_Korisnici_KorisniciId",
                        column: x => x.KorisniciId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoriti_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "KorisniciUloge",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "KorisniciUloge",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Kupci",
                keyColumn: "KupacID",
                keyValue: 1,
                column: "DatumRegistracije",
                value: new DateTime(2022, 9, 1, 18, 22, 54, 564, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Kupci",
                keyColumn: "KupacID",
                keyValue: 2,
                column: "DatumRegistracije",
                value: new DateTime(2022, 9, 1, 18, 22, 54, 564, DateTimeKind.Local).AddTicks(4466));

            migrationBuilder.UpdateData(
                table: "Kupci",
                keyColumn: "KupacID",
                keyValue: 3,
                column: "DatumRegistracije",
                value: new DateTime(2022, 9, 1, 18, 22, 54, 564, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 9, 1, 18, 22, 54, 564, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2022, 9, 1, 18, 22, 54, 564, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2022, 9, 1, 18, 22, 54, 564, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2022, 9, 1, 18, 22, 54, 564, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.CreateIndex(
                name: "IX_Favoriti_KorisniciId",
                table: "Favoriti",
                column: "KorisniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoriti_ProizvodId",
                table: "Favoriti",
                column: "ProizvodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoriti");

            migrationBuilder.UpdateData(
                table: "KorisniciUloge",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "KorisniciUloge",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Kupci",
                keyColumn: "KupacID",
                keyValue: 1,
                column: "DatumRegistracije",
                value: new DateTime(2022, 7, 18, 23, 37, 23, 17, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Kupci",
                keyColumn: "KupacID",
                keyValue: 2,
                column: "DatumRegistracije",
                value: new DateTime(2022, 7, 18, 23, 37, 23, 17, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Kupci",
                keyColumn: "KupacID",
                keyValue: 3,
                column: "DatumRegistracije",
                value: new DateTime(2022, 7, 18, 23, 37, 23, 17, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 7, 18, 23, 37, 23, 17, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2022, 7, 18, 23, 37, 23, 17, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2022, 7, 18, 23, 37, 23, 17, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "NarudzbaID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2022, 7, 18, 23, 37, 23, 17, DateTimeKind.Local).AddTicks(2458));
        }
    }
}
