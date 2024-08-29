using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETCLINIC.Data.Migrations
{
    /// <inheritdoc />
    public partial class zmiany2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PESEL",
                table: "Patients",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PESEL",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
