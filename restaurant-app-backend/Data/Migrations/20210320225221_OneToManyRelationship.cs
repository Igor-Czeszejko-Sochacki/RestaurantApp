using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurant_app_backend.Data.Migrations
{
    public partial class OneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Food",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_RestaurantId",
                table: "Food",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Restaurants_RestaurantId",
                table: "Food",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Restaurants_RestaurantId",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_RestaurantId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Food");
        }
    }
}
