using CompanyRelationship.Interfaces;
using CompanyRelationship.Model;

namespace CompanyRelationship.Services
{
    // Services/CompanyService.cs
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company?> GetCompanyByNameAsync(string name)
        {
            // Retrieve the company by name from the repository
            return await _companyRepository.GetCompanyByNameAsync(name);
        }

        public async Task<IEnumerable<BranchOfficeDept>> GetPagedChildrenAsync(string companyName, int pageNumber, int pageSize)
        {
            // Get the company by name
            var company = await _companyRepository.GetCompanyByNameAsync(companyName);

            if (company == null)
            {
                return Enumerable.Empty<BranchOfficeDept>();
            }

            // Apply pagination to the company's children
            var pagedChildren = company.Children
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return pagedChildren;
        }

        public async Task CreateCompanyAsync(Company company)
        {
            // Add the company to the repository
            await _companyRepository.AddAsync(company);

            // Save changes to the database
            await _companyRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetCompanyChildrenAsync(int pageNumber, int pageSize)
        {
            // Get the company by name
            var company = await _companyRepository.GetCompanyChildrenAsync(pageNumber,pageSize);

            

            // Apply pagination to the company's children
            var pagedChildren = company
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return pagedChildren;
        }
    }


}
