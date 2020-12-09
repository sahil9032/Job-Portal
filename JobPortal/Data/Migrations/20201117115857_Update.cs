using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_Jobs_JobId",
                table: "Applicant");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_AspNetUsers_UserId",
                table: "Applicant");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_IdentityUserId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_IdentityUserId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicant",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Applicant",
                newName: "Applicants");

            migrationBuilder.RenameIndex(
                name: "IX_Applicant_UserId",
                table: "Applicants",
                newName: "IX_Applicants_UserId");

            migrationBuilder.AddColumn<string>(
                name: "ProviderId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResumeLink",
                table: "Applicants",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                columns: new[] { "JobId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProviderId",
                table: "Jobs",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_AspNetUsers_UserId",
                table: "Applicants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_ProviderId",
                table: "Jobs",
                column: "ProviderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_AspNetUsers_UserId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_ProviderId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ProviderId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ResumeLink",
                table: "Applicants");

            migrationBuilder.RenameTable(
                name: "Applicants",
                newName: "Applicant");

            migrationBuilder.RenameIndex(
                name: "IX_Applicants_UserId",
                table: "Applicant",
                newName: "IX_Applicant_UserId");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicant",
                table: "Applicant",
                columns: new[] { "JobId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IdentityUserId",
                table: "Jobs",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicant_Jobs_JobId",
                table: "Applicant",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicant_AspNetUsers_UserId",
                table: "Applicant",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_IdentityUserId",
                table: "Jobs",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
