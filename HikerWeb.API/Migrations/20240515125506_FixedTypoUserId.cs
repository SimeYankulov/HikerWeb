using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikerWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypoUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsertId",
                table: "UserActivities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsertId",
                table: "UserActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
