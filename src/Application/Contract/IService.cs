using Common.Base;

namespace Application.Contract;

public interface IService<T> where T : class
{
    Task<BaseResultApiResponse<T>> GetAllAsync();
}