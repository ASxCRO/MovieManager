namespace MovieManager.Services.Declaration
{
	public interface IBaseService<T> where T : class
	{
        Task<bool> Insert(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);
    }
}

