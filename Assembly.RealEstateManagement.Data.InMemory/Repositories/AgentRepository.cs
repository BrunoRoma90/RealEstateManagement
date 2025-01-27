using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories
{
    internal class AgentRepository : IAgentRepository
    {
        private readonly Database _db;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IVisitRepository _visitRepository;

        public AgentRepository(Database database, IPropertyRepository propertyRepository, IVisitRepository visitRepository)
        {
            _db = database;
            _propertyRepository = propertyRepository;
            _visitRepository = visitRepository;
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
            var allAgent = new List<Agent>();
            foreach (var agent in _db.Agents)
            {
                allAgent.Add(agent);
            }
            return allAgent;
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

        public List<Agent> GetAgentsByManagerId(int managerId)
        {
            var agentsByManager = new List<Agent>();
            foreach (var agent in _db.Agents)
            {
                if (agent.Manager.Id == managerId)
                {
                    agentsByManager.Add(agent);
                }
            }
            return agentsByManager;
        }


        public List<Property> GetPropertiesByAgentId(int agentId)
        {
            throw new NotImplementedException();
        }

       
        public List<Visit> GetVisitsByAgentId(int agentId)
        {
            var visits = new List<Visit>();

            foreach (var agent in _db.Agents)
            {
                if(agent.Id == agentId)
                {
                    visits.AddRange(agent.Visits);
                    break;
                }
            }
            return visits;
        }

        public List<Contact> GetMyContacts(int agentId)
        {
            var contacts = new List<Contact>();

            foreach (var agent in _db.Agents)
            {
                if (agent.Id == agentId)
                {
                    contacts.AddRange(agent.Contacts);
                    break;
                }
            }
            return contacts;
        }


        public void AddNotes(int visitId, string notes)
        {
            _visitRepository.AddNotes(visitId, notes);
        }

        public void AddContactToMyList(int agentId, Contact contact)
        {
            var existingAgent = GetById(agentId);

            foreach (var agent in _db.Agents)
            {
                if (agent.Id == agentId)
                {
                    existingAgent = agent;
                    break;
                }
            }

            existingAgent.AddContact(contact);
        }

        public void RemoveContactFromMyList(int agentId, Contact contact)
        {
            Agent existingAgent = GetById(agentId);

            foreach (var agent in _db.Agents)
            {
                if (existingAgent.Id == agentId)
                {
                    existingAgent = agent;
                }
            }
            bool contactExists = false;
            foreach (var existingContact in existingAgent.Contacts)
            {
                if (existingContact.Id == contact.Id)
                {
                    contactExists = true;
                    break;
                }
            }
            if (!contactExists)
            {
                throw new InvalidOperationException("The contact does not exist in the contacts.");
            }

            existingAgent.DeleteContactToMyList(contact);
        }


        public Property GetPropertyById(int propertyId)
        {
            return _propertyRepository.GetById(propertyId);
        }

        public Property CreateProperty(Property property)
        {
            return _propertyRepository.Add(property);
        }

        public void DeleteProperty(int propertyId)
        {
            _propertyRepository.Delete(propertyId);
        }

        public void DeleteProperty(Property property)
        {
             _propertyRepository.Delete(property);
        }

        public Property UpdateProperty(Property property)
        {
           return _propertyRepository.Update(property);
        }

        public void AddPropertyToMyList(int agentId,Property property)
        {
            Agent existingAgent = GetById(agentId);

            foreach (var agent in _db.Agents)
            {
                if(agent.Id == agentId)
                {
                    existingAgent = agent;
                    break;
                }
            }

            foreach (var existingProperty in _db.Agent.ManagedProperties)
            {
                if (existingProperty.Id == property.Id) 
                {
                    throw new InvalidOperationException("The property already exists in the agent's managed properties.");
                }
            }

            existingAgent.AddProperty(property);
        }

        public void RemovePropertyFromAgent(int agentId, Property property)
        {
            Agent existingAgent = GetById(agentId);

            foreach (var agent in _db.Agents)
            {
                if(existingAgent.Id == agentId)
                {
                    existingAgent = agent;
                }
            }

            bool propertyExists = false;
            foreach (var existingProperty in existingAgent.ManagedProperties)
            {
                if (existingProperty.Id == property.Id)
                {
                    propertyExists = true;
                    break;
                }
            }
            if (!propertyExists)
            {
                throw new InvalidOperationException("The property does not exist in the agent's managed properties.");
            }

            existingAgent.DeleteProperty(property);
        }

        public void RemoveVisitToMyList(int agentId, Visit visit)
        {
            Agent existingAgent = GetById(agentId);

            foreach (var agent in _db.Agents)
            {
                if (existingAgent.Id == agentId)
                {
                    existingAgent = agent;
                }
            }
            bool visitExists = false;
            foreach (var existingVisit in existingAgent.Visits)
            {
                if (existingVisit.Id == visit.Id)
                {
                    visitExists = true;
                    break;
                }
            }
            if (!visitExists)
            {
                throw new InvalidOperationException("The property does not exist in the agent's managed properties.");
            }

            existingAgent.DeleteVisitToMyList(visit);

        }
        public void AddVisitToMyList(int agentId,Visit visit)
        {
            Agent existingAgent = GetById(agentId);

            foreach (var agent in _db.Agents)
            {
                if (agent.Id == agentId)
                {
                    existingAgent = agent;
                    break;
                }
            }
            _visitRepository.AddVisitToAgent(visit);
        }

     
    }
}
