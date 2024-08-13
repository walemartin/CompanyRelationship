using CompanyRelationship.Model;

namespace CompanyRelationship.Interfaces
{
    public interface ICompanyService
    {
        Task<Company?> GetCompanyByNameAsync(string name);
        Task<IEnumerable<Company>> GetCompanyChildrenAsync(int pageNumber, int pageSize);
        Task<IEnumerable<BranchOfficeDept>> GetPagedChildrenAsync(string companyName, int pageNumber, int pageSize);
        Task CreateCompanyAsync(Company company);
    }
}

