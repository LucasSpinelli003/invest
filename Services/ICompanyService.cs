using System.Collections.Generic;
using System.Threading.Tasks;
using InvestApi.Models;

namespace InvestApi.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task<bool> DeleteCompanyAsync(int id);
    }
}
