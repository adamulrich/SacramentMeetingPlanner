using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class iteration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SacramentMeeting_Hymn_sacrmentHymnid",
                table: "SacramentMeeting");

            migrationBuilder.DropIndex(
                name: "IX_SacramentMeeting_sacrmentHymnid",
                table: "SacramentMeeting");

            migrationBuilder.DropColumn(
                name: "sacrmentHymnid",
                table: "SacramentMeeting");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_sacramentHymnId",
                table: "SacramentMeeting",
                column: "sacramentHymnId");

            migrationBuilder.AddForeignKey(
                name: "FK_SacramentMeeting_Hymn_sacramentHymnId",
                table: "SacramentMeeting",
                column: "sacramentHymnId",
                principalTable: "Hymn",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SacramentMeeting_Hymn_sacramentHymnId",
                table: "SacramentMeeting");

            migrationBuilder.DropIndex(
                name: "IX_SacramentMeeting_sacramentHymnId",
                table: "SacramentMeeting");

            migrationBuilder.AddColumn<int>(
                name: "sacrmentHymnid",
                table: "SacramentMeeting",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_sacrmentHymnid",
                table: "SacramentMeeting",
                column: "sacrmentHymnid");

            migrationBuilder.AddForeignKey(
                name: "FK_SacramentMeeting_Hymn_sacrmentHymnid",
                table: "SacramentMeeting",
                column: "sacrmentHymnid",
                principalTable: "Hymn",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
