using System.Collections.Generic;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAdministrativeUserAllContactRepository : IRepository<AdministrativeUserAllContact, int>
{

    public List<AdministrativeUserAllContact> GetAdministrativeUserContacts(int administrativeUserId);


   
}
