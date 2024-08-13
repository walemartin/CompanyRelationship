using CompanyRelationship.Data;
using CompanyRelationship.Interfaces;
using CompanyRelationship.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyRelationship.Repository
{
    public class BranchOfficeDeptRepository : IBranchOfficeDeptRepository
    {
        private readonly CompanyContext _context;

        public BranchOfficeDeptRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BranchOfficeDept>> GetAllAsync()
        {
            return await _context.BranchOfficeDepts.ToListAsync();
        }
    }
}
