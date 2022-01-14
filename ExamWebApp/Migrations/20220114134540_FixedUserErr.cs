using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamWebApp.Migrations
{
    public partial class FixedUserErr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersIngredients_Recipes_RecipeId",
                table: "UsersIngredients");

            migrationBuilder.DropIndex(
                name: "IX_UsersIngredients_RecipeId",
                table: "UsersIngredients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "UsersIngredients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "UsersIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersIngredients_RecipeId",
                table: "UsersIngredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersIngredients_Recipes_RecipeId",
                table: "UsersIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
