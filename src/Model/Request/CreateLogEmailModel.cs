namespace Model.Request;

public class CreateLogEmailModel
{
    public Guid VpBankCustomerId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}