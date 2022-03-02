using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace musingo_backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    cost = table.Column<double>(type: "double precision", nullable: false),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    offer_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offers", x => x.id);
                    table.ForeignKey(
                        name: "FK_offers_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferId = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    last_update_time = table.Column<DateTime>(type: "timestamp", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "offers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rating = table.Column<double>(type: "double precision", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    comment_text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_comments_transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "transactions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_offers_owner_id",
                table: "offers",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_BuyerId",
                table: "transactions",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_OfferId",
                table: "transactions",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_SellerId",
                table: "transactions",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_user_comments_TransactionId",
                table: "user_comments",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_comments");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
