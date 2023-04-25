using Dal.Base.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dal.Base;

/// <summary>
/// Основной реопзиторий,
/// выполняет CRUD операции для любых сущностей BaseDal
/// </summary>
/// <typeparam name="T">Тип сущности, для которой применяем репозиторий (Dal)</typeparam>
/// <typeparam name="TI">Тип уникального идентификатора (Id)</typeparam>
public class BaseRepository<T, TI> : IBaseRepository<T, TI> where T : BaseDal<TI>
{
    protected readonly DataContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DataContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    /// <summary>
    /// Вставляет запись в базу данных
    /// </summary>
    /// <param name="dal">Сущность, которую нужно вставить</param>
    /// <returns>Id новой записи</returns>
    public virtual async Task<TI> InsertAsync(T dal)
    {
        var entity = await _dbSet.AddAsync(dal);
        await _context.SaveChangesAsync();
        return entity.Entity.Id;
    }

    /// <summary>
    /// Удаляет запись из бд по ее Id
    /// </summary>
    /// <param name="id">уникальный идентификатор записи</param>
    public virtual async Task DeleteAsync(TI id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        
    }

    /// <summary>
    /// Получает данные из таблицы по Id 
    /// </summary>
    /// <param name="id">уникальный идентификатор записи</param>
    /// <returns></returns>
    public virtual async Task<T?> GetAsync(TI id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }

    /// <summary>
    /// Обновляет данные о записи по Id
    /// </summary>
    /// <param name="dal">Сущность для обновления</param>
    /// <returns>Id записи</returns>
    public virtual async Task<TI> UpdateAsync(T dal)
    {
        _context.Entry(dal).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return dal.Id;
    }

    public virtual List<T> GetAll()
    {
        return _dbSet.ToList();
    }
}