using CompanyRelationship.Model;

namespace CompanyRelationship.Interfaces
{
    public interface IBranchOfficeDeptRepository
    {
        Task<IEnumerable<BranchOfficeDept>> GetAllAsync();
    }
}
