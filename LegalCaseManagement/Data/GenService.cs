namespace LegalCaseManagement.Data
{
    public class GenService<T> : GenInterface<T> where T : class
    {
        private readonly ApplicationDbContext myDbContext;
        protected IQueryable<T> Entities { get => myDbContext.Set<T>(); }
        public GenService(ApplicationDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        public bool Add(T entity)
        {
            try
            {
                myDbContext.Set<T>().Add(entity);
                return myDbContext.SaveChanges() != 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                myDbContext.Set<T>().Remove(entity);
                return myDbContext.SaveChanges() != 0;

            }
            catch
            {
                return false;
            }
        }

        public List<T> GetAll()
        {
            return myDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return myDbContext.Set<T>().Find(id);
        }

        public bool Update(T entity)
        {
            try
            {
                myDbContext.Set<T>().Update(entity);
                return myDbContext.SaveChanges() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
