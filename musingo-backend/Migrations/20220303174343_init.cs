using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    cost = table.Column<double>(type: "double precision", nullable: false),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    offer_id = table.Column<int>(type: "int", nullable: true),
                    seller_id = table.Column<int>(type: "int", nullable: true),
                    buyer_id = table.Column<int>(type: "int", nullable: true),
                    last_update_time = table.Column<byte[]>(type: "timestamp", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_offers_offer_id",
                        column: x => x.offer_id,
                        principalTable: "offers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_users_buyer_id",
                        column: x => x.buyer_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_users_seller_id",
                        column: x => x.seller_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<double>(type: "double precision", nullable: false),
                    transaction_id = table.Column<int>(type: "int", nullable: true),
                    comment_text = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_comments_transactions_transaction_id",
                        column: x => x.transaction_id,
                        principalTable: "transactions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_offers_owner_id",
                table: "offers",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_buyer_id",
                table: "transactions",
                column: "buyer_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_offer_id",
                table: "transactions",
                column: "offer_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_seller_id",
                table: "transactions",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_comments_transaction_id",
                table: "user_comments",
                column: "transaction_id");
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
