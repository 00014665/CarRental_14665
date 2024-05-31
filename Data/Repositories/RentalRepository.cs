using CarRental_14665.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CarRental_14665.Data.Repositories
{
    public class RentalRepository : IRepository <Rentals>
    {
        private readonly GeneralDbContext _context;

        public RentalRepository(GeneralDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rentals>> GetAllAsync() => await _context.Rentals.ToArrayAsync();

        public async Task<Rentals> GetByIDAsync(int id)
        {
            return await _context.Rentals.Include(t => t.Category).FirstOrDefaultAsync(t => t.categoryId == id);
        }

        public async Task AddAsync(Rentals entity)
        {
            entity.Category = await _context.Categories.FindAsync(entity.categoryId.Value);

            await _context.Rentals.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rentals entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Rentals.FindAsync(id);
            if (entity != null)
            {
                _context.Rentals.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
