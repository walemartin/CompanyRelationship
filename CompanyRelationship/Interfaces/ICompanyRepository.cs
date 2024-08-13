using CompanyRelationship.ExtensionClasses;
using CompanyRelationship.Model;

namespace CompanyRelationship.Interfaces
{
    public interface ICompanyRepository
    {
        // Retrieve a company by its name
        Task<Company?> GetCompanyByNameAsync(string name);

        // Retrieve all companies
        Task<IEnumerable<Company>> GetAllAsync();

        // Add a new company
        Task AddAsync(Company company);

        // Save changes to the database
        Task SaveChangesAsync();

        // Retrieve paginated children of a specific company
        Task<IEnumerable<BranchOfficeDept>> GetPagedChildrenAsync(string companyName, int pageNumber, int pageSize);
        // Retrieve paginated companies and child
        Task<IEnumerable<Company>> GetCompanyChildrenAsync(int pageNumber, int pageSize);
    }
}
