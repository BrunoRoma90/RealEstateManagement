
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

    public Visit Add(Visit obj)
    {
        throw new NotImplementedException();
    }
    public Visit GetById(int id)
    {
        throw new NotImplementedException();
    }
    public List<Visit> GetAll()
    {
        throw new NotImplementedException();
    }

    public Visit Delete(Visit obj)
    {
        throw new NotImplementedException();
    }

    public Visit Delete(int id)
    {
        throw new NotImplementedException();
    }

  


    public Visit Update(Visit obj)
    {
        throw new NotImplementedException();
    }

    public List<Visit> GetAllVisitByAngentId(int angentId)
    {
        throw new NotImplementedException();
    }

    public List<Visit> GetAllVisitByClientId(int clientId)
    {
        throw new NotImplementedException();
    }

    public List<Visit> GetAllVisitByPropertyId(int propertyId)
    {
        throw new NotImplementedException();
    }



    public Agent GetPorpertyByAgentId(int AngentId)
    {
        throw new NotImplementedException();
    }

    public Client GetVisitByClientId(int clientId)
    {
        throw new NotImplementedException();
    }

    public Property GetVisitByProperty(int propertyId)
    {
        throw new NotImplementedException();
    }

}
