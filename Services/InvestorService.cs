using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvestApi.Data;
using InvestApi.Models;

namespace InvestApi.Services
{
    public class InvestorService : IInvestorService
    {
        private readonly InvestDbContext _context;

        public InvestorService(InvestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Investor>> GetAllInvestorsAsync()
        {
            return await _context.Investors.ToListAsync();
        }

        public async Task<Investor> GetInvestorByIdAsync(int id)
        {
            return await _context.Investors.FindAsync(id);
        }

        public async Task<Investor> CreateInvestorAsync(Investor investor)
        {
            _context.Investors.Add(investor);
            await _context.SaveChangesAsync();
            return investor;
        }

        public async Task<Investor> UpdateInvestorAsync(Investor investor)
        {
            _context.Investors.Update(investor);
            await _context.SaveChangesAsync();
            return investor;
        }

        public async Task<bool> DeleteInvestorAsync(int id)
        {
            var investor = await GetInvestorByIdAsync(id);
            if (investor == null) return false;

            _context.Investors.Remove(investor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
