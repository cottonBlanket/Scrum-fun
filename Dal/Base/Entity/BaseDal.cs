namespace Dal.Base;

/// <summary>
/// Оссновная сущность, все остальные наследуются от нее
/// </summary>
/// <typeparam name="T">Тип Id - int or guid</typeparam>
public class BaseDal<T> 
{
    /// <summary>
    /// Идентификатор строки в таблице
    /// </summary>
    public T Id { get; set; }
}