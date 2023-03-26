using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class eposide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eposide_Series_SeriesId",
                table: "Eposide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eposide",
                table: "Eposide");

            migrationBuilder.RenameTable(
                name: "Eposide",
                newName: "Eposides");

            migrationBuilder.RenameIndex(
                name: "IX_Eposide_SeriesId",
                table: "Eposides",
                newName: "IX_Eposides_SeriesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eposides",
                table: "Eposides",
                column: "EposideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eposides_Series_SeriesId",
                table: "Eposides",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eposides_Series_SeriesId",
                table: "Eposides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eposides",
                table: "Eposides");

            migrationBuilder.RenameTable(
                name: "Eposides",
                newName: "Eposide");

            migrationBuilder.RenameIndex(
                name: "IX_Eposides_SeriesId",
                table: "Eposide",
                newName: "IX_Eposide_SeriesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eposide",
                table: "Eposide",
                column: "EposideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eposide_Series_SeriesId",
                table: "Eposide",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
