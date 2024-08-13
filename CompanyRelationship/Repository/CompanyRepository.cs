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
        private readonly Company _company;

        public CompanyRepository(CompanyContext context)
        {
            _context = context;
        }
        //REST API endpoint that would allow to Get many Company with relations
        public Company GetCompany()
        {
            return new Company
            {
                Name = "Global Company",
                Parents = new List<BranchOffice>
                {
                    new BranchOffice
                    {
                        Name = "Branch Office 1",
                        Children = new List<BranchOfficeDept>
                        {
                            new BranchOfficeDept { Name = "Dept 1" },
                            new BranchOfficeDept { Name = "Dept 2" }
                        }
                    },
                    new BranchOffice
                    {
                        Name = "Branch Office 2",
                        Children = new List<BranchOfficeDept>
                        {
                            new BranchOfficeDept { Name = "Dept 3" }
                        }
                    }
                }
            };
        }

        //REST API endpoinnt that returns relations of one company(queried by name)
        public Company OneCompany()
        {
            return new Company
            {
                Name = "HCL developer",
                Parents = new List<BranchOffice>
                {
                    new BranchOffice { Name = "HCL DE" },
                    new BranchOffice { Name = "HCL NL" }
                },
                Siblings = new List<BranchOffice>
                {
                    new BranchOffice { Name = "HCL admin" },
                    new BranchOffice { Name = "HCL support" },
                    new BranchOffice { Name = "HCL management" }
                },
                Children = new List<BranchOfficeDept>
                {
                    new BranchOfficeDept { Name = "HCL qa" }
                }
            };
        }

        public void AddBranchOffice(BranchOffice branchOffice)
        {
            _company.Parents.Add(branchOffice);
        }
    }
}
