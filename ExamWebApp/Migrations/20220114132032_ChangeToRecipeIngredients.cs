using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamWebApp.Migrations
{
    public partial class ChangeToRecipeIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Measurements_MeasurementId",
                table: "RecipeIngredients");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_MeasurementId",
                table: "RecipeIngredients");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_RecipeId_IngredientId_MeasurementId",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "MeasurementId",
                table: "RecipeIngredients");

            migrationBuilder.AddColumn<string>(
                name: "Measurement",
                table: "RecipeIngredients",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId_IngredientId",
                table: "RecipeIngredients",
                columns: new[] { "RecipeId", "IngredientId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_RecipeId_IngredientId",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "Measurement",
                table: "RecipeIngredients");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementId",
                table: "RecipeIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_MeasurementId",
                table: "RecipeIngredients",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId_IngredientId_MeasurementId",
                table: "RecipeIngredients",
                columns: new[] { "RecipeId", "IngredientId", "MeasurementId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Measurements_MeasurementId",
                table: "RecipeIngredients",
                column: "MeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
