using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OwnsManyIssue.Migrations
{
    public partial class CreateOwnsManyIssueDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aggregates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aggregates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondValueObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondValueObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondValueObjects_Aggregates_AggregateId",
                        column: x => x.AggregateId,
                        principalTable: "Aggregates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FourthFifthValueObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnyValue = table.Column<int>(nullable: false),
                    SecondValueObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FourthFifthValueObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FourthFifthValueObjects_SecondValueObjects_SecondValueObjectId",
                        column: x => x.SecondValueObjectId,
                        principalTable: "SecondValueObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThirdValueObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SecondValueObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdValueObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThirdValueObjects_SecondValueObjects_SecondValueObjectId",
                        column: x => x.SecondValueObjectId,
                        principalTable: "SecondValueObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThirdFifthValueObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnyValue = table.Column<int>(nullable: false),
                    ThirdValueObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdFifthValueObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThirdFifthValueObjects_ThirdValueObjects_ThirdValueObjectId",
                        column: x => x.ThirdValueObjectId,
                        principalTable: "ThirdValueObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FourthFifthValueObjects_SecondValueObjectId",
                table: "FourthFifthValueObjects",
                column: "SecondValueObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondValueObjects_AggregateId",
                table: "SecondValueObjects",
                column: "AggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdFifthValueObjects_ThirdValueObjectId",
                table: "ThirdFifthValueObjects",
                column: "ThirdValueObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdValueObjects_SecondValueObjectId",
                table: "ThirdValueObjects",
                column: "SecondValueObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FourthFifthValueObjects");

            migrationBuilder.DropTable(
                name: "ThirdFifthValueObjects");

            migrationBuilder.DropTable(
                name: "ThirdValueObjects");

            migrationBuilder.DropTable(
                name: "SecondValueObjects");

            migrationBuilder.DropTable(
                name: "Aggregates");
        }
    }
}
