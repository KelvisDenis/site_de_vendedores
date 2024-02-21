using Microsoft.EntityFrameworkCore;
using Site_1.Data;
using Site_1.Models;

namespace Site_1.Services
{
    public class SallesRecordsService
    {
        private readonly Site_1Context _context;
        public SallesRecordsService(Site_1Context context)
        {
            _context = context;
        }
        public async Task<List<SellesRecord>> FindByDateAsync(DateTime? min, DateTime? max)
        {
            var result = from obj in _context.SellesRecords select obj;
            if (min.HasValue) {
                result = result.Where(x => x.Date >= min.Value);
            }
            if (max.HasValue)
            {
                result = result.Where(x => x.Date <= max.Value);
            }
            return await result.Include(x => x.Seller).Include(x => x.Seller.Departament)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
        public async Task<List<IGrouping<Departament, SellesRecord>>> FindByDateGroupingAsync(DateTime? min, DateTime? max)
        {
            var result = from obj in _context.SellesRecords select obj;
            if (min.HasValue)
            {
                result = result.Where(x => x.Date >= min.Value);
            }
            if (max.HasValue)
            {
                result = result.Where(x => x.Date <= max.Value);
            }
            return await result.Include(x => x.Seller).Include(x => x.Seller.Departament)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Departament)   
                .ToListAsync();
        }
    }
}
