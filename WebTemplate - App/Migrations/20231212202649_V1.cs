using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sajt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sajt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Biljka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    DaLiCveta = table.Column<bool>(type: "bit", nullable: false),
                    List = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrvenastaZeljasta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZivotniVek = table.Column<int>(type: "int", nullable: false),
                    Zaliha = table.Column<int>(type: "int", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SajtIdID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biljka", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Biljka_Sajt_SajtIdID",
                        column: x => x.SajtIdID,
                        principalTable: "Sajt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lampa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Visina = table.Column<int>(type: "int", nullable: false),
                    Sirina = table.Column<int>(type: "int", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zaliha = table.Column<int>(type: "int", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SajtIdID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lampa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lampa_Sajt_SajtIdID",
                        column: x => x.SajtIdID,
                        principalTable: "Sajt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Saksija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Visina = table.Column<int>(type: "int", nullable: false),
                    Sirina = table.Column<int>(type: "int", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Materijal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zaliha = table.Column<int>(type: "int", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SajtIdID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saksija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Saksija_Sajt_SajtIdID",
                        column: x => x.SajtIdID,
                        principalTable: "Sajt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KomentariIOcena",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    BiljkaID = table.Column<int>(type: "int", nullable: true),
                    LampaID = table.Column<int>(type: "int", nullable: true),
                    SaksijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KomentariIOcena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KomentariIOcena_Biljka_BiljkaID",
                        column: x => x.BiljkaID,
                        principalTable: "Biljka",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KomentariIOcena_Lampa_LampaID",
                        column: x => x.LampaID,
                        principalTable: "Lampa",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KomentariIOcena_Saksija_SaksijaID",
                        column: x => x.SaksijaID,
                        principalTable: "Saksija",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biljka_SajtIdID",
                table: "Biljka",
                column: "SajtIdID");

            migrationBuilder.CreateIndex(
                name: "IX_KomentariIOcena_BiljkaID",
                table: "KomentariIOcena",
                column: "BiljkaID");

            migrationBuilder.CreateIndex(
                name: "IX_KomentariIOcena_LampaID",
                table: "KomentariIOcena",
                column: "LampaID");

            migrationBuilder.CreateIndex(
                name: "IX_KomentariIOcena_SaksijaID",
                table: "KomentariIOcena",
                column: "SaksijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Lampa_SajtIdID",
                table: "Lampa",
                column: "SajtIdID");

            migrationBuilder.CreateIndex(
                name: "IX_Saksija_SajtIdID",
                table: "Saksija",
                column: "SajtIdID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KomentariIOcena");

            migrationBuilder.DropTable(
                name: "Biljka");

            migrationBuilder.DropTable(
                name: "Lampa");

            migrationBuilder.DropTable(
                name: "Saksija");

            migrationBuilder.DropTable(
                name: "Sajt");
        }
    }
}
