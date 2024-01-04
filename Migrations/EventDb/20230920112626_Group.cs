using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.Migrations.EventDb
{
    public partial class Group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupFieldStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupLastDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupCityOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupGrowHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupIdeaTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupRelatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupGeographicalArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupDurationOfRun = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupTargetSociety = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupHaveConnectionToOther = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupIntellectualProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupInnovativenessOfTheIdea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupProjectProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupFinishedPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupCompetitorsInMarket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupChallengesAndRisks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupFile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupPrTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupPrTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupPrPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupPrJobLeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupPrSeller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupPrStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupProjects_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupUserDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupUserCityOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupUserJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupUserPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupProjects_GroupId",
                table: "GroupProjects",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupProjects");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
