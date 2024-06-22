using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace LegalCaseManagement.Data
{
    public class GenService<T> : GenInterface<T> where T : class
    {
        private readonly ApplicationDbContext myDbContext;
        protected IQueryable<T> Entities => myDbContext.Set<T>();

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

        

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await myDbContext.Set<T>().AddAsync(entity);
                return await myDbContext.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await myDbContext.Set<T>().FindAsync(id);
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

       
        
        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                myDbContext.Set<T>().Remove(entity);
                return await myDbContext.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await myDbContext.Set<T>().ToListAsync();
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
