using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SelesReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelesReports",
                columns: table => new
                {
                    SelesReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelesReportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillNumber = table.Column<int>(type: "int", nullable: false),
                    BillNumber1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelesReports", x => x.SelesReportID);
                    table.ForeignKey(
                        name: "FK_SelesReports_Bills_BillNumber1",
                        column: x => x.BillNumber1,
                        principalTable: "Bills",
                        principalColumn: "BillNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelesReports_BillNumber1",
                table: "SelesReports",
                column: "BillNumber1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelesReports");
        }
    }
}
