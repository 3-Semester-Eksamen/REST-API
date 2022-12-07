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
        public async Task Add(T obj)
        {
            using(var context = new LåsDbContext())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(T obj)
        {
            using(var context = new LåsDbContext())
            {
                context.Set<T>().Update(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
            using(var context = new LåsDbContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }
    }
}
