using CompanyRelationship.Data;
using CompanyRelationship.Interfaces;
using CompanyRelationship.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyRelationship.Repository
{
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        private readonly CompanyContext _context;

        public BranchOfficeRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BranchOffice>> GetAllAsync()
        {
            return await _context.BranchOffices.ToListAsync();
        }
    }
}
