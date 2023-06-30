using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedEquipmentAndExerciseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users_tb");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users_tb",
                newName: "IdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users_tb",
                table: "users_tb",
                column: "IdUser");

            migrationBuilder.CreateTable(
                name: "equipments_tb",
                columns: table => new
                {
                    IdEquipment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    isForHomeWorkout = table.Column<bool>(type: "bit", nullable: false),
                    isForOutdoorWorkout = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipments_tb", x => x.IdEquipment);
                });

            migrationBuilder.CreateTable(
                name: "exercises_tb",
                columns: table => new
                {
                    IdExercise = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetMuscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSets = table.Column<int>(type: "int", nullable: false),
                    CountOfExercisesToRepeat = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises_tb", x => x.IdExercise);
                    table.ForeignKey(
                        name: "FK_exercises_tb_users_tb_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "users_tb",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseEquipment",
                columns: table => new
                {
                    EquipmentIdEquipment = table.Column<int>(type: "int", nullable: false),
                    ExerciseIdExercise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseEquipment", x => new { x.EquipmentIdEquipment, x.ExerciseIdExercise });
                    table.ForeignKey(
                        name: "FK_ExerciseEquipment_equipments_tb_EquipmentIdEquipment",
                        column: x => x.EquipmentIdEquipment,
                        principalTable: "equipments_tb",
                        principalColumn: "IdEquipment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseEquipment_exercises_tb_ExerciseIdExercise",
                        column: x => x.ExerciseIdExercise,
                        principalTable: "exercises_tb",
                        principalColumn: "IdExercise",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEquipment_ExerciseIdExercise",
                table: "ExerciseEquipment",
                column: "ExerciseIdExercise");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_tb_AuthorId",
                table: "exercises_tb",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseEquipment");

            migrationBuilder.DropTable(
                name: "equipments_tb");

            migrationBuilder.DropTable(
                name: "exercises_tb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users_tb",
                table: "users_tb");

            migrationBuilder.RenameTable(
                name: "users_tb",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
