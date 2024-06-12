namespace LegalCaseManagement.Data
{
    public interface GenInterface<T> where T : class
    {
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T GetById(int id);
        List<T> GetAll();

        Task<bool> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        //Task<T> GetByIdAsync(string id);
    }
}
