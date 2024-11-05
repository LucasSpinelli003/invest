using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvestApi.Models;
using InvestApi.Services;

namespace InvestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            var createdCompany = await _companyService.CreateCompanyAsync(company);
            return CreatedAtAction(nameof(GetById), new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Company company)
        {
            if (id != company.Id) return BadRequest();

            var updatedCompany = await _companyService.UpdateCompanyAsync(company);
            return Ok(updatedCompany);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _companyService.DeleteCompanyAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
