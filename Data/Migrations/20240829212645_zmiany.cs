﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETCLINIC.Data.Migrations
{
    /// <inheritdoc />
    public partial class zmiany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patients");
        }
    }
}
