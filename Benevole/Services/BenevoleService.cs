using Benevole.Models;
using Microsoft.EntityFrameworkCore;

namespace Benevole.Services
{
    public class BenevoleService : IBenevoleService
    {
        private readonly BenevoleContext _context;

        public BenevoleService(BenevoleContext context) => _context = context;

        public async Task<IEnumerable<BenevoleModel>> GetAllAsync()
        {
            return await (_context.Benevoles ?? throw new InvalidOperationException("Benevoles null")).ToListAsync();
        }

        public async Task<BenevoleModel?> GetByIdAsync(int id)
        {
            return await (_context.Benevoles ?? throw new InvalidOperationException("Benevoles  null")).FindAsync(id);
        }

        public async Task AddAsync(BenevoleModel benevole)
        {
            if (_context.Benevoles == null)
            {
                throw new InvalidOperationException("Benevoles null");
            }
            _context.Benevoles.Add(benevole);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BenevoleModel benevole)
        {
            if (_context.Benevoles == null)
            {
                throw new InvalidOperationException("Benevoles is null");
            }
            _context.Benevoles.Update(benevole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (_context.Benevoles == null)
            {
                throw new InvalidOperationException("Benevoles  null");
            }
            var benevole = await _context.Benevoles.FindAsync(id);
            if (benevole != null)
            {
                _context.Benevoles.Remove(benevole);
                await _context.SaveChangesAsync();
            }
        }
    }
}