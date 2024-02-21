using Microsoft.EntityFrameworkCore;
using Site_1.Data;
using Site_1.Models;

namespace Site_1.Services
{
    public class DepartamentService
    {
        private readonly Site_1Context _context;
        public DepartamentService(Site_1Context context)
        {
            _context = context;
        }
        public async Task<List<Departament>> FindAllAsync() {
            return await _context.Departament.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
