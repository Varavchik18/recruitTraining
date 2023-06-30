using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullableFields2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentType",
                table: "equipments_tb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentType",
                table: "equipments_tb");
        }
    }
}
