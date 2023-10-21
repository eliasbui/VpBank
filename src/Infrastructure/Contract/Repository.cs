namespace Infrastructure.Contract;

public interface IRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();

    /// <summary>
    ///     Get entity by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(Guid id);

    /// <summary>
    ///     Add entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> AddAsync(T entity);

    /// <summary>
    ///     Update entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(T entity);

    /// <summary>
    ///     Delete entity
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);
}