using System.Collections.Generic;
using System.Threading.Tasks;
using InvestApi.Models;

namespace InvestApi.Services
{
    public interface IInvestmentService
    {
        Task<IEnumerable<Investment>> GetAllInvestmentsAsync();
        Task<Investment> GetInvestmentByIdAsync(int id);
        Task<Investment> CreateInvestmentAsync(Investment investment);
        Task<Investment> UpdateInvestmentAsync(Investment investment);
        Task<bool> DeleteInvestmentAsync(int id);
    }
}
