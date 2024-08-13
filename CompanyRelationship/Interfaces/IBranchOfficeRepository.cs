using CompanyRelationship.Model;

namespace CompanyRelationship.Interfaces
{
    public interface IBranchOfficeRepository
    {
        Task<IEnumerable<BranchOffice>> GetAllAsync();
    }
}
