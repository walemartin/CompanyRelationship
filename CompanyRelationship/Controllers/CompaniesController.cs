using CompanyRelationship.Interfaces;
using CompanyRelationship.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyRelationship.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/company?pageNumber=1&pageSize=10
        [HttpGet()]
        public async Task<IActionResult> GetAllCompanyRelationships(int pageNumber, int pageSize)
        {
            var company = await _companyService.GetCompanyChildrenAsync(pageNumber, pageSize);
            if (company == null)
            {
                return NotFound($"No records found");
            }
            

            return Ok(company);
        }
        // GET: api/company/{name}?pageNumber=1&pageSize=100

//        REST API endpoint that returns relations of one company(queried by name). All company
//children, siblings and parents.Companies are ordered by name and one page may return 100
//rows at max with pagination support.For example if you query relations for organization “ HCL
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCompanyByName(string name, int pageNumber = 1, int pageSize = 100)
        {
            var company = await _companyService.GetCompanyByNameAsync(name);

            if (company == null)
            {
                return NotFound($"Company with name '{name}' not found.");
            }

            var pagedChildren = await _companyService.GetPagedChildrenAsync(name, pageNumber, pageSize);
           
            // Overwrite the full list with the paginated list
            company.Children = pagedChildren.ToList();

            return Ok(company);
        }

        // POST: api/company
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }
            if (await _companyService.GetCompanyByNameAsync(company.Name) != null)
            {
                return BadRequest("Company name must be unique.");
            }

            await _companyService.CreateCompanyAsync(company);

            return CreatedAtAction(nameof(GetCompanyByName), new { name = company.Name }, company);
        }
    }

}
