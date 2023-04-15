using Dal.Base;
using Dal.Base.Interface;
using Logic.Managers.Base.Interfaces;

namespace Logic.Managers.Base;

/// <summary>
/// Базовый мененджер для CRUD операций
/// </summary>
/// <typeparam name="T">Модель dal</typeparam>
/// <typeparam name="TI">Тип Id (Guid или int)</typeparam>
public class BaseManager<T, TI> : IBaseManager<T, TI> where T : BaseDal<TI>
{
    protected readonly IBaseRepository<T, TI> Repository;

    public BaseManager(IBaseRepository<T, TI> repository)
    {
        Repository = repository;
    }

    public async Task<TI> InsertAsync(T dal)
    {
        return await Repository.InsertAsync(dal);
    }

    public async Task DeleteAsync(TI id)
    {
        await Repository.DeleteAsync(id);
    }

    public async Task<T?> GetAsync(TI id)
    {
        return await Repository.GetAsync(id);
    }

    public async Task<TI> UpdateAsync(T dal)
    {
        return await Repository.UpdateAsync(dal);
    }
    
    public List<T> GetAll()
    {
        return Repository.GetAll();
    }
}