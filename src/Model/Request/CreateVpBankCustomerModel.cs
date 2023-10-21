namespace Model.Request;

public class CreateVpBankCustomerModel
{
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string Country { get; set; }
    public string LoanPayMust { get; set; }
    public string GiveSalaryType { get; set; }

    public DateTime AppliedDate { get; set; } = DateTime.Now;
    public string Email { get; set; }
}