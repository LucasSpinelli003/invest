using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvestApi.Models;
using InvestApi.Services;

namespace InvestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestorsController : ControllerBase
    {
        private readonly IInvestorService _investorService;

        public InvestorsController(IInvestorService investorService)
        {
            _investorService = investorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var investors = await _investorService.GetAllInvestorsAsync();
            return Ok(investors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var investor = await _investorService.GetInvestorByIdAsync(id);
            if (investor == null) return NotFound();
            return Ok(investor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Investor investor)
        {
            var createdInvestor = await _investorService.CreateInvestorAsync(investor);
            return CreatedAtAction(nameof(GetById), new { id = createdInvestor.Id }, createdInvestor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Investor investor)
        {
            if (id != investor.Id) return BadRequest();

            var updatedInvestor = await _investorService.UpdateInvestorAsync(investor);
            return Ok(updatedInvestor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _investorService.DeleteInvestorAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
