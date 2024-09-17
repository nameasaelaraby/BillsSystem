using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ahmed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelesReports_Bills_BillNumber1",
                table: "SelesReports");

            migrationBuilder.DropIndex(
                name: "IX_SelesReports_BillNumber1",
                table: "SelesReports");

            migrationBuilder.DropColumn(
                name: "BillNumber1",
                table: "SelesReports");

            migrationBuilder.CreateIndex(
                name: "IX_SelesReports_BillNumber",
                table: "SelesReports",
                column: "BillNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_SelesReports_Bills_BillNumber",
                table: "SelesReports",
                column: "BillNumber",
                principalTable: "Bills",
                principalColumn: "BillNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelesReports_Bills_BillNumber",
                table: "SelesReports");

            migrationBuilder.DropIndex(
                name: "IX_SelesReports_BillNumber",
                table: "SelesReports");

            migrationBuilder.AddColumn<int>(
                name: "BillNumber1",
                table: "SelesReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SelesReports_BillNumber1",
                table: "SelesReports",
                column: "BillNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_SelesReports_Bills_BillNumber1",
                table: "SelesReports",
                column: "BillNumber1",
                principalTable: "Bills",
                principalColumn: "BillNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
