using CompanyRelationship.ExtensionClasses;
using CompanyRelationship.Model;

namespace CompanyRelationship.Interfaces
{
    public interface ICompanyRepository
    {
        //Company GetCompany();
        //Task AddCompanyAsync(Company company);
        //Task<Company?> GetCompanyByNameAsync(string name);
        //Task<PaginatedList<Company>> GetCompanyRelationsAsync(string name, int pageNumber, int pageSize);
        Company GetCompany();
        Company GetCompanybyName(string name);
        void AddBranchOffice(BranchOffice branchOffice);
    }
}
