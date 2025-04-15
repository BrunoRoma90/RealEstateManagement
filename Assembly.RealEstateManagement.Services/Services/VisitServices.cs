using System.Net;
using System.Security.Principal;
using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Client;
using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class VisitServices : IVisitServices
{
    private readonly IUnitOfWork _unitOfWork;

    public VisitServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<VisitDto> GetVisits()
    {
        var visits = new List<Visit>();

        visits = _unitOfWork.VisitRepository.GetAllVisitsWithClient();
        visits = _unitOfWork.VisitRepository.GetAllVisitsWithAgent();
        visits = _unitOfWork.VisitRepository.GetAllVisitsWithProperty();

        visits = _unitOfWork.VisitRepository.GetAll();

        return visits.Select(x => new VisitDto
        {

            ClientId = x.Client.Id,
            PropertyId = x.Property.Id,
            AgentId = x.Agent.Id,
            VisitDate = x.VisitDate,
            Notes = x.Notes,

        }).ToList();

        
    }
    public VisitDto GetVisitById(int id)
    {
        var visit = _unitOfWork.VisitRepository.GetById(id);
        var client = _unitOfWork.VisitRepository.GetClientByVisitId(id);
        var agent = _unitOfWork.VisitRepository.GetAgentByVisitId(id);
        var property = _unitOfWork.VisitRepository.GetPropertyByVisitId(id);
        
        if (visit is null)
        {
            throw new ArgumentNullException(nameof(visit), "visit id not found");
        }
        if (client is null)
        {
            throw new KeyNotFoundException($"Client with ID {id} not found.");
        }
        if (agent is null)
        {
            throw new KeyNotFoundException($"Agent account with ID {id} not found.");
        }
        if (property is null)
        {
            throw new KeyNotFoundException($"Property address ID {id} not found.");
        }

        return new VisitDto
        {
            ClientId = client.Id,
            PropertyId = property.Id,
            AgentId = agent.Id,
            VisitDate = visit.VisitDate,
            Notes = visit.Notes,
        };
    }

    public VisitDto Add(CreateVisitDto visit)
    {
        Visit addedVisit;
        var client = _unitOfWork.ClientRepository.GetById(visit.ClientId);
        var agent = _unitOfWork.AgentRepository.GetById(visit.AgentId);
        var property = _unitOfWork.PropertyRepository.GetById(visit.PropertyId);
        if (client == null)
        {
            throw new Exception("client not found.");
        }
        if (agent == null)
        {
            throw new Exception("agent not found.");
        }
        if (property == null)
        {
            throw new Exception("property not found.");
        }

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();

            Visit visitToAdd = Visit.Create(client, property, agent, visit.VisitDate, visit.Notes
            );

            addedVisit = _unitOfWork.VisitRepository.Add(visitToAdd);
            _unitOfWork.Commit();
        }

        var visitDto = new VisitDto
        {
            ClientId = visit.ClientId,
            PropertyId = visit.PropertyId,
            AgentId = visit.AgentId,
            VisitDate = visit.VisitDate,
            Notes = visit.Notes,
        };


        return visitDto;
    }

    public VisitDto Update(UpdateVisitDto visit)
    {
        var existingVisit = _unitOfWork.VisitRepository.GetById(visit.Id);
        var existingAgent = _unitOfWork.VisitRepository.GetAgentByVisitId(visit.Id);
        var existingClient = _unitOfWork.VisitRepository.GetClientByVisitId(visit.Id);
        var existingProperty = _unitOfWork.VisitRepository.GetPropertyByVisitId(visit.Id);

        if (existingVisit is null)
            throw new KeyNotFoundException("Visit not found.");

        if (existingAgent is null)
            throw new KeyNotFoundException("Agent account not found.");

        if (existingClient is null)
            throw new KeyNotFoundException("Client address not found.");

        if (existingProperty is null)
            throw new KeyNotFoundException("Property not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();

            string IsValidString(string? value, string current) =>
            string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;

            var newAgent = visit.AgentId.HasValue && visit.AgentId.Value != 0 && visit.AgentId.Value != existingAgent.Id
            ? _unitOfWork.AgentRepository.GetById(visit.AgentId.Value)
            : existingAgent;

            if (newAgent is null)
                throw new KeyNotFoundException("New agent not found.");

            var newClient = visit.ClientId.HasValue && visit.ClientId.Value != 0 && visit.ClientId.Value != existingClient.Id
            ? _unitOfWork.ClientRepository.GetById(visit.ClientId.Value)
            : existingClient;

            if (newClient is null)
                throw new KeyNotFoundException("New client not found.");

            var newProperty = visit.PropertyId.HasValue && visit.PropertyId.Value != 0 && visit.PropertyId.Value != existingProperty.Id
            ? _unitOfWork.PropertyRepository.GetById(visit.PropertyId.Value)
            : existingProperty;

            if (newProperty is null)
                throw new KeyNotFoundException("New property not found.");

            existingVisit.Update(
           existingVisit.Id,
           newClient,
           newProperty,
           newAgent,
           visit.VisitDate,
           IsValidString(visit.Notes, existingVisit.Notes)
           );

            _unitOfWork.VisitRepository.Update(existingVisit);
            _unitOfWork.Commit();



            var visitDto = new VisitDto
            {
                ClientId = existingVisit.Client.Id,
                PropertyId = existingVisit.Property.Id,
                AgentId = existingVisit.Agent.Id,
                VisitDate = existingVisit.VisitDate,
                Notes = existingVisit.Notes,
            };


            return visitDto;

        }

       

    }
}
