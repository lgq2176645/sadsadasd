using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tensee.Banch.Migrations
{
    public partial class AddSalaryCalculationMethodLWQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StepJson",
                table: "WorkFlows",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalaryCalculationMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    JsonText = table.Column<string>(nullable: true),
                    MethodCode = table.Column<string>(nullable: true),
                    MethodName = table.Column<string>(nullable: true),
                    SchemeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryCalculationMethod", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryCalculationMethod");

            migrationBuilder.DropColumn(
                name: "StepJson",
                table: "WorkFlows");
        }
    }
}
