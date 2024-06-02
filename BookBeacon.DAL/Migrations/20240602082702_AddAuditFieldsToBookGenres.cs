using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookBeacon.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditFieldsToBookGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookLanguage",
                table: "BookLanguage");

            migrationBuilder.DropIndex(
                name: "IX_BookLanguage_BookId",
                table: "BookLanguage");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookLanguage");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BookGenre",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "BookGenre",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BookGenre",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "BookGenre",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookLanguage",
                table: "BookLanguage",
                columns: new[] { "BookId", "LanguageId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookLanguage",
                table: "BookLanguage");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BookGenre");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BookGenre");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BookGenre");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BookGenre");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookLanguage",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookLanguage",
                table: "BookLanguage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookLanguage_BookId",
                table: "BookLanguage",
                column: "BookId");
        }
    }
}
