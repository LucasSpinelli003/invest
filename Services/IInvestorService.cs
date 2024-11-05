using System.Collections.Generic;
using System.Threading.Tasks;
using InvestApi.Models;

namespace InvestApi.Services
{
    public interface IInvestorService
    {
        Task<IEnumerable<Investor>> GetAllInvestorsAsync();
        Task<Investor> GetInvestorByIdAsync(int id);
        Task<Investor> CreateInvestorAsync(Investor investor);
        Task<Investor> UpdateInvestorAsync(Investor investor);
        Task<bool> DeleteInvestorAsync(int id);
    }
}
