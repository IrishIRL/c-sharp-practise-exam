using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamWebApp.Migrations
{
    public partial class AddedMeasurements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measurement",
                table: "RecipeIngredients");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementId",
                table: "UsersIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementId",
                table: "RecipeIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasurementName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersIngredients_MeasurementId",
                table: "UsersIngredients",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_MeasurementId",
                table: "RecipeIngredients",
                column: "MeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Measurement_MeasurementId",
                table: "RecipeIngredients",
                column: "MeasurementId",
                principalTable: "Measurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersIngredients_Measurement_MeasurementId",
                table: "UsersIngredients",
                column: "MeasurementId",
                principalTable: "Measurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Measurement_MeasurementId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersIngredients_Measurement_MeasurementId",
                table: "UsersIngredients");

            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropIndex(
                name: "IX_UsersIngredients_MeasurementId",
                table: "UsersIngredients");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_MeasurementId",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "MeasurementId",
                table: "UsersIngredients");

            migrationBuilder.DropColumn(
                name: "MeasurementId",
                table: "RecipeIngredients");

            migrationBuilder.AddColumn<string>(
                name: "Measurement",
                table: "RecipeIngredients",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }
    }
}
