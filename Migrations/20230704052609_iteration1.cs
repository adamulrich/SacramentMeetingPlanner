using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class iteration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SacramentMeeting",
                columns: table => new
                {
                    sacramentMeetingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    wardName = table.Column<string>(type: "TEXT", nullable: false),
                    conductor = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    openingPrayer = table.Column<string>(type: "TEXT", nullable: false),
                    openingHymnId = table.Column<int>(type: "INTEGER", nullable: false),
                    sacramentHymnId = table.Column<int>(type: "INTEGER", nullable: false),
                    sacrmentHymnid = table.Column<int>(type: "INTEGER", nullable: false),
                    restHymnId = table.Column<int>(type: "INTEGER", nullable: false),
                    specialMusicalNumber = table.Column<string>(type: "TEXT", nullable: true),
                    closingHymnId = table.Column<int>(type: "INTEGER", nullable: false),
                    closingPrayer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentMeeting", x => x.sacramentMeetingId);
                    table.ForeignKey(
                        name: "FK_SacramentMeeting_Hymn_closingHymnId",
                        column: x => x.closingHymnId,
                        principalTable: "Hymn",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SacramentMeeting_Hymn_openingHymnId",
                        column: x => x.openingHymnId,
                        principalTable: "Hymn",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SacramentMeeting_Hymn_restHymnId",
                        column: x => x.restHymnId,
                        principalTable: "Hymn",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SacramentMeeting_Hymn_sacrmentHymnid",
                        column: x => x.sacrmentHymnid,
                        principalTable: "Hymn",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sacramentMeetingId = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    topic = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.id);
                    table.ForeignKey(
                        name: "FK_Speaker_SacramentMeeting_sacramentMeetingId",
                        column: x => x.sacramentMeetingId,
                        principalTable: "SacramentMeeting",
                        principalColumn: "sacramentMeetingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_closingHymnId",
                table: "SacramentMeeting",
                column: "closingHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_openingHymnId",
                table: "SacramentMeeting",
                column: "openingHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_restHymnId",
                table: "SacramentMeeting",
                column: "restHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_sacrmentHymnid",
                table: "SacramentMeeting",
                column: "sacrmentHymnid");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_sacramentMeetingId",
                table: "Speaker",
                column: "sacramentMeetingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "SacramentMeeting");

            migrationBuilder.DropTable(
                name: "Hymn");
        }
    }
}
