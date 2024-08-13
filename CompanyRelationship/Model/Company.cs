namespace CompanyRelationship.Model
{
  
    
    //public class Company
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; } = string.Empty;

    //    // Recursive relations
    //    public ICollection<Company> Parents { get; set; } = [];
    //    public ICollection<Company> Children { get; set; } = [];
    //}
    public class BranchOfficeDept
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class BranchOffice
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BranchOfficeDept> Children { get; set; }

        public BranchOffice()
        {
            Children = new List<BranchOfficeDept>();
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BranchOffice> Parents { get; set; }
        public List<BranchOffice> Siblings { get; set; }
        public List<BranchOfficeDept> Children { get; set; }

        public Company()
        {
            Parents = new List<BranchOffice>();
            Siblings = new List<BranchOffice>();
            Children = new List<BranchOfficeDept>();
        }
    }

}
