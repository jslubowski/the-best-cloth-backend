﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBestCloth.API.Migrations
{
    public partial class RemoveUsernameColumnFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "text",
                nullable: true);
        }
    }
}
