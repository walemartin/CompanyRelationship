using CompanyRelationship.Data;
using CompanyRelationship.ExtensionClasses;
using CompanyRelationship.Interfaces;
using CompanyRelationship.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyRelationship.Repository
{
    
    public class CompanyRepository : ICompanyRepository
    {
      
        private readonly CompanyContext _context;

        public CompanyRepository(CompanyContext context)
        {
            _context = context;
        }

        // Retrieve a company by its name, including related data
        public async Task<Company?> GetCompanyByNameAsync(string name)
        {
            return await _context.Companies
                .Include(c => c.Parents).ThenInclude(g=>g.Children)
                .Include(c => c.Siblings)
                .Include(c => c.Children)
                .FirstOrDefaultAsync(c => c.Name.Contains(name));
        }

        // Retrieve all companies
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies
                .Include(c => c.Parents).ThenInclude(g => g.Children)
                .Include(c => c.Siblings)
                .Include(c => c.Children)
                .ToListAsync();
        }

        // Add a new company to the database
        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

       

        // Retrieve a paginated list of children for a specific company
        public async Task<IEnumerable<BranchOfficeDept>> GetPagedChildrenAsync(string companyName, int pageNumber, int pageSize=100)
        {
            var company = await _context.Companies
                .Include(c => c.Children)
                .FirstOrDefaultAsync(c => c.Name == companyName);

            if (company == null)
            {
                return Enumerable.Empty<BranchOfficeDept>();
            }

            return company.Children
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        // Retrieve a paginated list of companies and children
        public async Task<IEnumerable<Company>> GetCompanyChildrenAsync(int pageNumber, int pageSize=100)
        {
            var company = await GetAllAsync();
            return company.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        // Save changes to the database
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
