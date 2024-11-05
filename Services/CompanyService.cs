using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvestApi.Data;
using InvestApi.Models;

namespace InvestApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly InvestDbContext _context;

        public CompanyService(InvestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var company = await GetCompanyByIdAsync(id);
            if (company == null) return false;

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
