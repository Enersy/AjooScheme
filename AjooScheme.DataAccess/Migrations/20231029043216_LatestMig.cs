using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjooScheme.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LatestMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AmountToContribute",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseContributionDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TypeOfContribution",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToContribute",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ReleaseContributionDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TypeOfContribution",
                table: "Customers");
        }
    }
}
