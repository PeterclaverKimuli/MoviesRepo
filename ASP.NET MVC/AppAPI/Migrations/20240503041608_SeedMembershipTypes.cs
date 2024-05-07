using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembershipTypes(SignupFee, DurationInMonths, DiscountRate, Name) " +
                "VALUES(0, 0, 0, 'Pas as you go')");
            migrationBuilder.Sql("INSERT INTO MembershipTypes(SignupFee, DurationInMonths, DiscountRate, Name) " +
                "VALUES(30, 1, 10, 'Monthly')");
            migrationBuilder.Sql("INSERT INTO MembershipTypes(SignupFee, DurationInMonths, DiscountRate, Name) " +
                "VALUES(90, 3, 15, 'Quarterly')");
            migrationBuilder.Sql("INSERT INTO MembershipTypes(SignupFee, DurationInMonths, DiscountRate, Name) " +
                "VALUES(300, 12, 20, 'Yearly')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
