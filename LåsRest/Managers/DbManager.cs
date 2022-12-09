using LåsRest.Models;
using Microsoft.EntityFrameworkCore;

namespace LåsRest.Managers
{
    public class DbManager <T> where T : class
    {
        public async Task<List<T>> GetObjects()
        {
            using (var context = new LåsDbContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }
        public async Task<T> Add(T obj)
        {
            using (var context = new LåsDbContext())
            {
                var entity = context.Set<T>().Add(obj).Entity;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<T> Update(T obj)
        {
            using(var context = new LåsDbContext())
            {
               var entity = context.Set<T>().Update(obj).Entity;
               await context.SaveChangesAsync();
               return entity;
            }
        }

        public async Task<T> Delete(T obj)
        {
            using(var context = new LåsDbContext())
            {
                var entity = context.Set<T>().Remove(obj).Entity;
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
