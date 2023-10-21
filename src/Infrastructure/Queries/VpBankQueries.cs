namespace Infrastructure.Queries;

public static class VpBankQueries
{
    public static string GetAllVpBankCustomers =>
        """
        SELECT * from "VpBankCustomer" ORDER BY "AppliedDate" DESC
        """;

    public static string InsertVpBankCustomer => """
                                                 INSERT INTO "VpBankCustomer" ("CustomerName", "PhoneNumber", "Country", "LoanPayMust", "GiveSalaryType", "Email")
                                                 VALUES (@CustomerName, @PhoneNumber, @Country, @LoanPayMust, @GiveSalaryType, @Email)
                                                 """;

    public static string InsertLogEmail => """
                                           INSERT INTO "EmailLog" ("VpBankCustomerId", "CreatedDate")
                                           VALUES (@VpBankCustomerId, @CreatedDate)
                                           """;

    public static string DeleteVpBankCustomer => """
                                                 DELETE FROM "VpBankCustomer" WHERE "Id" = @Id
                                                 """;

    public static string GetLogEmailByIdCustomer => """
                                                    SELECT * FROM "EmailLog" WHERE "VpBankCustomerId" = @Id order by "CreatedDate" DESC
                                                    """;

    public static string DeleteLogEmailByIdCustomer => """
                                                       DELETE FROM "EmailLog" WHERE "VpBankCustomerId" = @Id
                                                       """;
}