using System.ComponentModel.DataAnnotations;
using Domain.Contract;

namespace Domain.Entities;

public class VpBankCustomer : IEntities<Guid>
{
    [Key] public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string Country { get; set; }
    public string LoanPayMust { get; set; }
    public string GiveSalaryType { get; set; }
    public DateTime AppliedDate { get; set; }
    public string Email { get; set; } = "";
}