using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Data.Migrations
{
    public partial class socialMediaUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserISkills");

            migrationBuilder.AddColumn<string>(
                name: "FBUrl",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserInterpersonalSkills",
                columns: table => new
                {
                    InterpersonalSkillsId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterpersonalSkills", x => new { x.userId, x.InterpersonalSkillsId });
                    table.ForeignKey(
                        name: "FK_UserInterpersonalSkills_InterpersonalSkills_InterpersonalSkillsId",
                        column: x => x.InterpersonalSkillsId,
                        principalTable: "InterpersonalSkills",
                        principalColumn: "InterpersonalSkillsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterpersonalSkills_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTechnicalSkills",
                columns: table => new
                {
                    TechnicalSkillsId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTechnicalSkills", x => new { x.userId, x.TechnicalSkillsId });
                    table.ForeignKey(
                        name: "FK_UserTechnicalSkills_TechnicalSkills_TechnicalSkillsId",
                        column: x => x.TechnicalSkillsId,
                        principalTable: "TechnicalSkills",
                        principalColumn: "TechnicalSkillsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTechnicalSkills_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterpersonalSkills_InterpersonalSkillsId",
                table: "UserInterpersonalSkills",
                column: "InterpersonalSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTechnicalSkills_TechnicalSkillsId",
                table: "UserTechnicalSkills",
                column: "TechnicalSkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterpersonalSkills");

            migrationBuilder.DropTable(
                name: "UserTechnicalSkills");

            migrationBuilder.DropColumn(
                name: "FBUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserISkills",
                columns: table => new
                {
                    InterpersonalSkillsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TechnicalSkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserISkills", x => new { x.InterpersonalSkillsId, x.UserId, x.TechnicalSkillsId });
                    table.ForeignKey(
                        name: "FK_UserISkills_InterpersonalSkills_InterpersonalSkillsId",
                        column: x => x.InterpersonalSkillsId,
                        principalTable: "InterpersonalSkills",
                        principalColumn: "InterpersonalSkillsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserISkills_TechnicalSkills_TechnicalSkillsId",
                        column: x => x.TechnicalSkillsId,
                        principalTable: "TechnicalSkills",
                        principalColumn: "TechnicalSkillsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserISkills_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserISkills_TechnicalSkillsId",
                table: "UserISkills",
                column: "TechnicalSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserISkills_UserId",
                table: "UserISkills",
                column: "UserId");
        }
    }
}
