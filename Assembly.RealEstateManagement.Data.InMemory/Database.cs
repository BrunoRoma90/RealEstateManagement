using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory
{
    internal class Database
    {
        public List<Agent> Agents { get; set; }
        public List<Visit> Visits { get; set; }
        public Database()
        {
            Agents = new List<Agent>();
            Visits = new List<Visit>();
        }        
    }
}
