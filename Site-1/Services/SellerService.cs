using Microsoft.EntityFrameworkCore;
using Site_1.Data;
using Site_1.Models;
using Site_1.Services.Exceptions;

namespace Site_1.Services
{
    public class SellerService
    {
        private readonly Site_1Context _context;
        public SellerService( Site_1Context context) {
        _context = context;
        }  
        public async Task<List<Seller>> GetSellersAsync() { 
        return await _context.Sellers.ToListAsync();
        }
        public async Task<List<Departament>> GetDepartamentsAsync() {
            return await _context.Departament.ToListAsync();
            
        }
        public async Task<Seller> FindByIdAsync(int? id) {
            return await _context.Sellers.Include(obj => obj.Departament).FirstOrDefaultAsync(o => o.Id == id); 
        }
        public async Task RemoverAsync(int id) {
            try
            {
                var obj = await _context.Sellers.FindAsync(id);
                _context.Sellers.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegretyException(e.Message);
            }
        }
        public async Task UpdateAsync(Seller obj)
        {
            if (!await _context.Sellers.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
           catch (DbConcurrencyExceptions ex) {
                throw new DbConcurrencyExceptions(ex.Message);
            }
        }
        
    }
}
