using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManager.Infra.Data.Migrations
{
    public partial class CreatedPersonAssociations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonCoffeePlace",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    CoffeePlaceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCoffeePlace", x => new { x.PersonId, x.CoffeePlaceId });
                    table.ForeignKey(
                        name: "FK_PersonCoffeePlace_CoffeePlaces_CoffeePlaceId",
                        column: x => x.CoffeePlaceId,
                        principalTable: "CoffeePlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonCoffeePlace_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonEventRoom",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    EventRoomId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEventRoom", x => new { x.PersonId, x.EventRoomId });
                    table.ForeignKey(
                        name: "FK_PersonEventRoom_EventRooms_EventRoomId",
                        column: x => x.EventRoomId,
                        principalTable: "EventRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonEventRoom_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonCoffeePlace_CoffeePlaceId",
                table: "PersonCoffeePlace",
                column: "CoffeePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEventRoom_EventRoomId",
                table: "PersonEventRoom",
                column: "EventRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonCoffeePlace");

            migrationBuilder.DropTable(
                name: "PersonEventRoom");
        }
    }
}
