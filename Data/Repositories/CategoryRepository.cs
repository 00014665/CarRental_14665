using CarRental_14665.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace CarRental_14665.Data.Repositories
{
  
        public class CategoryRepository : IRepository<Category>
        {
            private readonly GeneralDbContext _context;

            public CategoryRepository(GeneralDbContext context)
            {
                _context = context;
            }

            // Add or create new entity 
            public async Task AddAsync(Category categories)
            {
                await _context.Categories.AddAsync(categories);
                await _context.SaveChangesAsync();
            }


            public async Task DeleteAsync(int id)
            {
                var entity = await _context.Categories.FindAsync(id);
                if (entity != null)
                {
                    _context.Categories.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }


            public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToArrayAsync();


            public async Task<Category> GetByIDAsync(int id) => await _context.Categories.FindAsync(id);
 
            public async Task UpdateAsync(Category categories)
            {
                _context.Entry(categories).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
}

