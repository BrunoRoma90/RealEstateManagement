using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory
{
    internal class Database
    {
        public List<Agent> Agents { get; set; }
        public List<Visit> Visits { get; set; }

        public List<Admin> Admins { get; set; }

        public List<Manager> Managers { get; set; }
        public List<AdministrativeUsers> AdministrativeUsers { get; set; }

        public List<Client> Clients { get; set; } 
        public Database()
        {
            Agents = new List<Agent>();
            Visits = new List<Visit>();
            Admins = new List<Admin>();
            Managers = new List<Manager>();
            Clients = new List<Client>();
            AdministrativeUsers = new List<AdministrativeUsers>();
        }        
    }
}
