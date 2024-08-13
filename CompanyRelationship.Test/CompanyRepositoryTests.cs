using CompanyRelationship.Data;
using CompanyRelationship.Interfaces;
using CompanyRelationship.Model;
using CompanyRelationship.Repository;
using CompanyRelationship.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Transactions;

namespace CompanyRelationship.Test
{
    public class CompanyRepositoryTests
    {
        private readonly ICompanyService _companyService;
      

        public CompanyRepositoryTests(ICompanyService companyService)
        {

            _companyService = companyService;

           
        }

        [Fact]
        public async Task GetCompanyByNameAsync_ReturnsCompany_WhenCompanyExists()
        {
            // Arrange
            var company = new Company { Name = "HCL" };
            await _companyService.GetCompanyByNameAsync(company.Name);
            //await _companyService.SaveChangesAsync();

            // Act
            var result = await _companyService.GetCompanyByNameAsync("HCL");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("HCL", result.Name);
        }

        [Fact]
        public async Task GetCompanyByNameAsync_ReturnsNull_WhenCompanyDoesNotExist()
        {
            // Act
            var result = await _companyService.GetCompanyByNameAsync("NonExistentCompany");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetCompanyByNameAsync_IncludesRelatedData()
        {
            // Arrange
            var parentCompany = new Company { Name = "Parent Company" };
            var siblingCompany = new Company { Name = "Sibling Company" };
            var childDept = new BranchOfficeDept { Name = "Child Dept" };

            var company = new Company
            {
                Name = "HCL",
                Parents = new List<BranchOffice> { new BranchOffice { Name = "Parent Office", Children = new List<BranchOfficeDept> { childDept } } },
                Siblings = new List<BranchOffice> { new BranchOffice { Name = "Sibling Office" } },
                Children = new List<BranchOfficeDept> { childDept }
            };

            await _companyService.CreateCompanyAsync(company);
            

            // Act
            var result = await _companyService.GetCompanyByNameAsync("HCL");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Parents);
            Assert.Single(result.Siblings);
            Assert.Single(result.Children);
        }
    }
}