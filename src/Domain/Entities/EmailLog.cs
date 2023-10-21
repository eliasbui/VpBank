using System.ComponentModel.DataAnnotations;
using Domain.Contract;

namespace Domain.Entities;

public class EmailLog : IEntities<Guid>
{
    [Key] public Guid Id { get; set; }
    public Guid IdVpBankCustomer { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}