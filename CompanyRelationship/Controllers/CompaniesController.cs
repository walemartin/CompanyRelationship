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
        private readonly ICompanyRepository _repository;

        public CompaniesController(ICompanyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Company> GetCompany()
        {
            return _repository.GetCompany();
        }

        [HttpPost]
        public IActionResult AddBranchOffice([FromBody] BranchOffice branchOffice)
        {
            if (branchOffice == null)
            {
                return BadRequest();
            }

            _repository.AddBranchOffice(branchOffice);
            return CreatedAtAction(nameof(GetCompany), new { id = branchOffice.Name }, branchOffice);
        }
    }

}
