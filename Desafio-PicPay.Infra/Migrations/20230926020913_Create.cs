using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_PicPay.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    DocumentType = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    FkUserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_UserType_FkUserType",
                        column: x => x.FkUserType,
                        principalTable: "UserType",
                        principalColumn: "UserTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentValue = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    FkUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_User_FkUser",
                        column: x => x.FkUser,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PreviousValue = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    NewValue = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    FkAccountSender = table.Column<int>(type: "int", nullable: false),
                    FkAccountReceiver = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_FkAccountReceiver",
                        column: x => x.FkAccountReceiver,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_FkAccountSender",
                        column: x => x.FkAccountSender,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_FkUser",
                table: "Account",
                column: "FkUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_FkAccountReceiver",
                table: "Transaction",
                column: "FkAccountReceiver");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_FkAccountSender",
                table: "Transaction",
                column: "FkAccountSender");

            migrationBuilder.CreateIndex(
                name: "IX_User_FkUserType",
                table: "User",
                column: "FkUserType",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
