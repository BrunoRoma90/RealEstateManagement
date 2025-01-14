using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories
{
    internal class AgentRepository : IAgentRepository
    {
        private readonly Database _db;

        public AgentRepository(Database database)
        {
            _db = database;
        }

        public Agent Add(Agent agent)
        {
            _db.Agents.Add(agent);
            return agent;
        }

        public Agent Delete(Agent agent)
        {
            return Delete(agent.Id);
        }

        public Agent Delete(int id)
        {
            Agent agentToDelete = null;
            foreach (var agent in _db.Agents)
            {
                if (agent.Id == id)
                {
                    agentToDelete = agent;
                    break;

                }
            }
            if
            (agentToDelete != null)
            {
                _db.Agents.Remove(agentToDelete);
            }

            return agentToDelete;
        }

        public List<Agent> GetAll()
        {
            return _db.Agents;
        }

        public Agent GetById(int id)
        {
            foreach (var agent in _db.Agents)
            {
                if (agent.Id == id)
                {
                    return agent;
                }
            }
            return null;
        }

        public List<Property> GetPropertiesByAgentId(int agentId)
        {
            throw new NotImplementedException();
        }

        public List<Visit> GetVisitsByAgentId(int agentId)
        {
            throw new NotImplementedException();
        }

        public Agent Update(Agent agent)
        {
            var existingAgent = GetById(agent.Id);
            if (existingAgent != null)
            {
                _db.Agents.Remove(existingAgent);
                _db.Agents.Add(agent);
                return agent;
            }
            return null;
        }
    }
}
