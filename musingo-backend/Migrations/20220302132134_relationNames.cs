using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace musingo_backend.Migrations
{
    public partial class relationNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_offers_OfferId",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_BuyerId",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_SellerId",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_user_comments_transactions_TransactionId",
                table: "user_comments");

            migrationBuilder.DropIndex(
                name: "IX_user_comments_TransactionId",
                table: "user_comments");

            migrationBuilder.DropIndex(
                name: "IX_transactions_BuyerId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_OfferId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_SellerId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "user_comments");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "transactions");

            migrationBuilder.AddColumn<int>(
                name: "transaction_id",
                table: "user_comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "buyer_id",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "offer_id",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "seller_id",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_comments_transaction_id",
                table: "user_comments",
                column: "transaction_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_offers_offer_id",
                table: "transactions",
                column: "offer_id",
                principalTable: "offers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_buyer_id",
                table: "transactions",
                column: "buyer_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_seller_id",
                table: "transactions",
                column: "seller_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_comments_transactions_transaction_id",
                table: "user_comments",
                column: "transaction_id",
                principalTable: "transactions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_offers_offer_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_buyer_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_seller_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_user_comments_transactions_transaction_id",
                table: "user_comments");

            migrationBuilder.DropIndex(
                name: "IX_user_comments_transaction_id",
                table: "user_comments");

            migrationBuilder.DropIndex(
                name: "IX_transactions_buyer_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_offer_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_seller_id",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "transaction_id",
                table: "user_comments");

            migrationBuilder.DropColumn(
                name: "buyer_id",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "offer_id",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "seller_id",
                table: "transactions");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "user_comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_comments_TransactionId",
                table: "user_comments",
                column: "TransactionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_offers_OfferId",
                table: "transactions",
                column: "OfferId",
                principalTable: "offers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_BuyerId",
                table: "transactions",
                column: "BuyerId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_SellerId",
                table: "transactions",
                column: "SellerId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_comments_transactions_TransactionId",
                table: "user_comments",
                column: "TransactionId",
                principalTable: "transactions",
                principalColumn: "id");
        }
    }
}
