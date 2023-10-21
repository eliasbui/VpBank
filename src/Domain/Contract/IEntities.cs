namespace Domain.Contract;

public interface IEntities<T>
{
    T Id { get; set; }
}