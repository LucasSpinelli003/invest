using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvestApi.Data;
using InvestApi.Models;

namespace InvestApi.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly InvestDbContext _context;

        public InvestmentService(InvestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Investment>> GetAllInvestmentsAsync()
        {
            return await _context.Investments.Include(i => i.Investor).Include(i => i.Company).ToListAsync();
        }

        public async Task<Investment> GetInvestmentByIdAsync(int id)
        {
            return await _context.Investments.Include(i => i.Investor).Include(i => i.Company).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Investment> CreateInvestmentAsync(Investment investment)
        {
            _context.Investments.Add(investment);
            await _context.SaveChangesAsync();
            return investment;
        }

        public async Task<Investment> UpdateInvestmentAsync(Investment investment)
        {
            _context.Investments.Update(investment);
            await _context.SaveChangesAsync();
            return investment;
        }

        public async Task<bool> DeleteInvestmentAsync(int id)
        {
            var investment = await GetInvestmentByIdAsync(id);
            if (investment == null) return false;

            _context.Investments.Remove(investment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
