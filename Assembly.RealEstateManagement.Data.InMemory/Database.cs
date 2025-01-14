using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory
{
    internal class Database
    {
        public List<Agent> Agents { get; set; }

        public Database()
        {
            Agents = new List<Agent>();
        }        
    }
}
