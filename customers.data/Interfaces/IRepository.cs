using customers.domain;

public interface IRepository<T> where T : Generic32
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    //Task<List<T>> SearchAsync(string searchText);
    Task UpdateAsync(T entity);
    void Remove(T entity);
    Task SaveChangesAsync();
}
