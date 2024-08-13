using CompanyRelationship.Data;
using CompanyRelationship.Interfaces;
using CompanyRelationship.Model;
using CompanyRelationship.Repository;
using Microsoft.EntityFrameworkCore;

namespace CompanyRelationship.Test
{
    public class CompanyRepositoryTests
    {
        private readonly ICompanyRepository _repository;
        private readonly CompanyContext _context;

        

        //[Fact]
        //public async Task AddCompanyAsync_ShouldAddCompany()
        //{
        //    var company = new Company { Name = "TestCompany" };

        //    await _repository.AddCompanyAsync(company);

        //    var result = await _context.Companies.FirstOrDefaultAsync(c => c.Name == "TestCompany");
        //    Assert.NotNull(result);
        //}

        //[Fact]
        //public async Task GetCompanyByNameAsync_ShouldReturnCompanyWithRelations()
        //{
        //    var parentCompany = new Company { Name = "ParentCompany" };
        //    var childCompany = new Company { Name = "ChildCompany", Parents = new List<Company> { parentCompany } };

        //    await _repository.AddCompanyAsync(childCompany);

        //    var result = await _repository.GetCompanyByNameAsync("ChildCompany");
        //    Assert.NotNull(result);
        //    Assert.Single(result.Parents);
        //    Assert.Equal("ParentCompany", result.Parents.First().Name);
        //}
    }

}