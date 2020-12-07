using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaceId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    Start = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamName = table.Column<string>(nullable: true),
                    VehicleModel = table.Column<string>(nullable: true),
                    VehicleManufacturingDate = table.Column<string>(nullable: true),
                    vehicleState = table.Column<int>(nullable: false),
                    TypeOfVehicles = table.Column<int>(nullable: false),
                    Speed = table.Column<double>(nullable: false),
                    TimeForFixing = table.Column<int>(nullable: false),
                    HeavyMalfunctionProbability = table.Column<double>(nullable: false),
                    LightMalfunctionProbability = table.Column<double>(nullable: false),
                    RandomNumber = table.Column<double>(nullable: false),
                    CurrentTime = table.Column<double>(nullable: false),
                    DistanceToFinish = table.Column<double>(nullable: false),
                    TimeSpentOnFixingRest = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "VehicleRace");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
