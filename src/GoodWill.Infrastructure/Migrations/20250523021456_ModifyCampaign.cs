﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodWill.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCampaign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverPhoto",
                table: "Campaigns",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhoto",
                table: "Campaigns");
        }
    }
}
