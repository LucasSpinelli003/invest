using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvestApi.Models;
using InvestApi.Services;

namespace InvestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentsController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var investments = await _investmentService.GetAllInvestmentsAsync();
            return Ok(investments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var investment = await _investmentService.GetInvestmentByIdAsync(id);
            if (investment == null) return NotFound();
            return Ok(investment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Investment investment)
        {
            var createdInvestment = await _investmentService.CreateInvestmentAsync(investment);
            return CreatedAtAction(nameof(GetById), new { id = createdInvestment.Id }, createdInvestment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Investment investment)
        {
            if (id != investment.Id) return BadRequest();

            var updatedInvestment = await _investmentService.UpdateInvestmentAsync(investment);
            return Ok(updatedInvestment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _investmentService.DeleteInvestmentAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
