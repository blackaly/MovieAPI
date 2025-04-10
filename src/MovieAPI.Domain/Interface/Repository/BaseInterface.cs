namespace MovieAPI.Domain.Interface.Repository
{
    public interface BaseInterface<T> where T : class, new()
    {
        Task<T> Add(T entity);
        Task<bool> Delete(T entity);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}
