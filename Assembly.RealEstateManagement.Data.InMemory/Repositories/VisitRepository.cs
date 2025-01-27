using System.Runtime.InteropServices;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class VisitRepository : IVisitRepository
{
    private readonly Database _db;

    public VisitRepository(Database database)
    {
        _db = database;

    }

    public Visit Add(Visit visit)
    {
        _db.Visits.Add(visit);
        return visit;
    }
    public Visit GetById(int id)
    {
        foreach (var visit in _db.Visits)
        {
            if (visit.Id == id)
            {
                return visit;

            }
        }
        throw new KeyNotFoundException($"Visit with ID {id} was not found.");
    }
    public List<Visit> GetAll()
    {
        var allVisits = new List<Visit>();
        foreach (var visit in _db.Visits)
        {
            allVisits.Add(visit);
        }
        return allVisits;
    }

    public Visit Delete(Visit visit)
    {
        var allVisits = _db.Visits.ToList();
        foreach (var existingVisit in allVisits)
        {
            if (existingVisit.Id == visit.Id)
            {
                _db.Visits.Remove(existingVisit);
            }
        }
        throw new KeyNotFoundException($"Visit was not found.");
    }

    public Visit Delete(int id)
    {
        var allVisits = _db.Visits.ToList();
        foreach (var existingVisit in allVisits)
        {
            if (existingVisit.Id == id)
            {
                _db.Visits.Remove(existingVisit);

            }
        }
        throw new KeyNotFoundException($"Visit with ID {id} was not found.");
    }

  


    public Visit Update(Visit visit)
    {
        var allVisits = _db.Visits.ToList();
        foreach (var existingVisit in allVisits)
        {
            if (existingVisit.Id == visit.Id)
            {
                existingVisit.UpdateVisit(visit.Property, visit.Client, visit.Agent, visit.VisitDate, visit.Notes);
                return existingVisit;
            }
        }
        throw new KeyNotFoundException($"Admin was not found.");
    }

    public List<Visit> GetAllVisitByAngentId(int angentId)
    {
        var visitsByAgent = new List<Visit>();
        foreach (var visit in _db.Visits)
        {
            if (visit.Agent.Id == angentId)
            {
                visitsByAgent.Add(visit);
            }
        }
        return visitsByAgent;
    }

    public List<Visit> GetAllVisitByClientId(int clientId)
    {
        var visitsByClient = new List<Visit>();
        foreach (var visit in _db.Visits)
        {
            if (visit.Client.Id == clientId)
            {
                visitsByClient.Add(visit);
            }
        }
        return visitsByClient;
    }

    public List<Visit> GetAllVisitByPropertyId(int propertyId)
    {
        var visitsByProperty = new List<Visit>();
        foreach (var visit in _db.Visits)
        {
            if (visit.Property.Id == propertyId)
            {
                visitsByProperty.Add(visit);
            }
        }
        return visitsByProperty;
    }



    public Visit GetVisitByAgentId(int agentId)
    {
        foreach (var visit in _db.Visits)
        {
            if (visit.Agent.Id == agentId)
            { 
                return visit;
            }
        }
        throw new KeyNotFoundException($"Visit with Agent ID {agentId} was not found.");
    }

    public Visit GetVisitByClientId(int clientId)
    {
        foreach (var visit in _db.Visits)
        {
            if (visit.Client.Id == clientId)
            {
                return visit;
            }
        }
        throw new KeyNotFoundException($"Visit with Client ID {clientId} was not found.");
    }

    public Visit GetVisitByProperty(int propertyId)
    {
        foreach (var visit in _db.Visits)
        {
            if (visit.Property.Id == propertyId)
            {
                return visit;
            }
        }
        throw new KeyNotFoundException($"Visit with Property ID {propertyId} was not found.");
    }

    public void AddVisitToAgent(Visit visit)
    {
        _db.Agent.Visits.Add(visit);

    }

    public void AddVisitToClient(Visit visit)
    {
        _db.Client.Visits.Add(visit);
    }

    public void AddNotes(int visitId, string notes)
    {
        var visit = GetById(visitId);
        if (visit == null)
        {
            throw new KeyNotFoundException($"Visit with ID {visitId} was not found.");
        }

        visit.AddNotes(notes);
     

    }
}
