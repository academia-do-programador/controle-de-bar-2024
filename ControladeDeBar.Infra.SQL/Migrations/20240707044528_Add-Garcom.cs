﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControladeDeBar.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddGarcom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGarcom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGarcom", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBGarcom");
        }
    }
}
