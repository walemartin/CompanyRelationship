using CompanyRelationship.Model;

namespace CompanyRelationship.Data
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(CompanyContext context)
        {
            // Check if the database is already seeded
            if (context.Companies.Any())
            {
                return; // DB has been seeded
            }

            // Seed data for BranchOfficeDept
            var dept1 = new BranchOfficeDept { Name = "HR Department" };
            var dept2 = new BranchOfficeDept { Name = "IT Department" };
            var dept3 = new BranchOfficeDept { Name = "Finance Department" };

            // Seed data for BranchOffice
            var branch1 = new BranchOffice
            {
                Name = "Main Office",
                Children = new List<BranchOfficeDept> { dept1, dept2 }
            };

            var branch2 = new BranchOffice
            {
                Name = "Satellite Office",
                Children = new List<BranchOfficeDept> { dept3 }
            };

            // Seed data for Company
            var company1 = new Company
            {
                Name = "Company A",
                Parents = new List<BranchOffice> { branch1 },
                Siblings = new List<BranchOffice> { branch2 },
                Children = new List<BranchOfficeDept> { dept1, dept2 }
            };

            var company2 = new Company
            {
                Name = "Company B",
                Parents = new List<BranchOffice> { branch2 },
                Siblings = new List<BranchOffice> { branch1 },
                Children = new List<BranchOfficeDept> { dept3 }
            };

            // Add companies to the context
            await context.Companies.AddRangeAsync(company1, company2);

            // Save changes to the database
            await context.SaveChangesAsync();
        }
    }

}
