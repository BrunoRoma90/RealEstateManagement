using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Property;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class PropertyServices : IPropertyServices
{
    private readonly IUnitOfWork _unitOfWork;

    public PropertyServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<PropertyDto> GetProperties()
    {
        var properties = new List<Property>();
        properties = _unitOfWork.PropertyRepository.GetAllPropertiesWithAddress();
        properties = _unitOfWork.PropertyRepository.GetAllPropertiesWithAgent();


        return properties.Select(p => new PropertyDto
        {
            Id = p.Id,
            Agent = new AgentDto
            {

                EmployeeNumber = p.Agent.EmployeeNumber,
                AgentNumber = p.Agent.AgentNumber,
                FirstName = p.Agent.Name.FirstName,
                LastName = p.Agent.Name.LastName,
                Email = p.Agent.Account.Email,
            },
            PropertyType = p.PropertyType,
            Price = p.Price,
            PriceBySquareMeter = p.PriceBySquareMeter,
            SizeBySquareMeters = p.SizeBySquareMeters,
            Description = p.Description,
            Address = new AddressDto
            {
                Street = p.Address.Street,
                Number = p.Address.Number,
                PostalCode = p.Address.PostalCode,
                City = p.Address.City,
                Country = p.Address.Country
            },
            TransactionType = p.TransactionType,
            Availability = p.Availability,
            Rooms = _unitOfWork.PropertyRepository.GetRoomsByPropertyId(p.Id)
            .Select(r => new RoomDto
            {
                
                RoomType = r.RoomType,
                Size = r.Size
            }).ToList(),

            PropertyImages = _unitOfWork.PropertyRepository.GetPropertyImagesByPropertyId(p.Id)
            .Select(img => new PropertyImageDto
            {
                
                ImageUrl = img.ImageUrl,
                Description = img.Description
            }).ToList()

        }).ToList();


        
    }

    public PropertyDto GetPropertyById(int id)
    {
        var property = _unitOfWork.PropertyRepository.GetById(id);
        var agent = _unitOfWork.PropertyRepository.GetAgentByPropertyId(id);
        var address = _unitOfWork.PropertyRepository.GetPropertyAddress(id);

        if (property is null)
        {
            throw new ArgumentNullException(nameof(property), "property id not found");
        }
        if (agent is null)
        {
            throw new ArgumentNullException(nameof(property), "agent id not found");
        }
        if (address is null)
        {
            throw new ArgumentNullException(nameof(property), "address id not found");
        }

        return new PropertyDto
        {
            Id = property.Id,
            Agent = new AgentDto
            {

                EmployeeNumber = agent.EmployeeNumber,
                AgentNumber = agent.AgentNumber,
                FirstName = agent.Name.FirstName,
                LastName = agent.Name.LastName,
                Email = agent.Account.Email,
            },
            PropertyType = property.PropertyType,
            Price = property.Price,
            PriceBySquareMeter = property.PriceBySquareMeter,
            SizeBySquareMeters = property.SizeBySquareMeters,
            Description = property.Description,
            Address = new AddressDto
            {
                Street = address.Street,
                Number = address.Number,
                PostalCode = address.PostalCode,
                City = address.City,
                Country = address.Country
            },
            TransactionType = property.TransactionType,
            Availability = property.Availability,
            Rooms = _unitOfWork.PropertyRepository.GetRoomsByPropertyId(property.Id)
            .Select(r => new RoomDto
            {
                
                RoomType = r.RoomType,
                Size = r.Size
            }).ToList(),

            PropertyImages = _unitOfWork.PropertyRepository.GetPropertyImagesByPropertyId(property.Id)
            .Select(img => new PropertyImageDto
            {
                
                ImageUrl = img.ImageUrl,
                Description = img.Description
            }).ToList()
        };
    }
    public PropertyDto Add(CreatePropertyDto property)
    {
        Property addedProperty;

        using (_unitOfWork)
        {

            _unitOfWork.BeginTransaction();

            var agent = _unitOfWork.AgentRepository.GetById(property.Agent.Id);
            var account = _unitOfWork.AgentRepository.GetAgentAccount(property.Agent.Id);
            if (agent == null)
            {
                throw new Exception("Agent not found.");
            }
            if (!Enum.IsDefined(typeof(PropertyType), property.PropertyType))
            {
                throw new ArgumentException("Invalid property type.");
            }
            if (!Enum.IsDefined(typeof(TransactionType), property.TransactionType))
            {
                throw new ArgumentException("Invalid transaction type.");
            }
            if (!Enum.IsDefined(typeof(Availability), property.Availability))
            {
                throw new ArgumentException("Invalid availability type.");
            }
            var rooms = property.Rooms?.Select(roomDto => Room.Create(roomDto.RoomType, roomDto.Size)).ToList() ?? new List<Room>();
            var propertyImages = property.PropertyImages?.Select(imgDto => PropertyImage.Create(imgDto.ImageUrl, imgDto.Description)).ToList() ?? new List<PropertyImage>();


            Property propertyToAdd = Property.Create(agent,
                property.PropertyType,
                property.Price,
                property.PriceBySquareMeter,
                property.SizeBySquareMeters,
                property.Description,
                Address.Create(property.Address.Street, property.Address.Number, property.Address.PostalCode, property.Address.City, property.Address.Country),
                property.TransactionType, property.Availability,
                rooms,
                propertyImages
                );

            //rooms.ForEach(room =>
            //propertyToAdd.AddRoom(Room.Create(room.RoomType, room.Size))
            //);

            //propertyImages.ForEach(img =>
            //    propertyToAdd.AddPropertyImage(PropertyImage.Create(img.ImageUrl, img.Description))
            //);





            addedProperty = _unitOfWork.PropertyRepository.Add(propertyToAdd);
            _unitOfWork.Commit();
        }

        var propertyDto = new PropertyDto
        {
            Id = addedProperty.Id,
            Agent = new AgentDto 
            {
                EmployeeNumber = addedProperty.Agent.EmployeeNumber,
                AgentNumber = addedProperty.Agent.AgentNumber,
                FirstName = addedProperty.Agent.Name.FirstName,
                LastName = addedProperty.Agent.Name.LastName,
                Email = addedProperty.Agent.Account.Email,
            },
            PropertyType = addedProperty.PropertyType,
            Price = addedProperty.Price,
            PriceBySquareMeter = addedProperty.PriceBySquareMeter,
            SizeBySquareMeters = addedProperty.SizeBySquareMeters,
            Description = addedProperty.Description,
            Address = new AddressDto
            {
                Street = addedProperty.Address.Street,
                Number = addedProperty.Address.Number,
                PostalCode = addedProperty.Address.PostalCode,
                City = addedProperty.Address.City,
                Country = addedProperty.Address.Country,

            },
            TransactionType = addedProperty.TransactionType,
            Availability = addedProperty.Availability,

        };

        return propertyDto;
    }

    public PropertyDto Update(UpdatePropertyDto property)
    {
        var existingProperty = _unitOfWork.PropertyRepository.GetById(property.Id);
        var existingAddress = _unitOfWork.PropertyRepository.GetPropertyAddress(property.Id);
        var existingAgent = _unitOfWork.PropertyRepository.GetAgentByPropertyId(property.Id);
      

        if (existingProperty is null)
            throw new KeyNotFoundException("Property not found.");

        if (existingAddress is null)
            throw new KeyNotFoundException("Property address not found.");

        if (existingAgent is null)
            throw new KeyNotFoundException("Property Agent not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();


            string IsValidString(string? value, string current) =>
            string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;

            T IsValidEnum<T>(T value, T current) where T : Enum =>
            EqualityComparer<T>.Default.Equals(value, default(T)) ? current : value;

            existingProperty.Address.UpdateAddress(
                IsValidString(property.Address?.Street, existingProperty.Address.Street),
                property.Address?.Number == 0 ? existingProperty.Address.Number : property.Address.Number,
                IsValidString(property.Address?.PostalCode, existingProperty.Address.PostalCode),
                IsValidString(property.Address?.City, existingProperty.Address.City),
                IsValidString(property.Address?.Country, existingProperty.Address.Country)
            );

            var newAgent = property.AgentId.HasValue && property.AgentId.Value != 0 && property.AgentId.Value != existingProperty.Id
            ? _unitOfWork.AgentRepository.GetById(property.AgentId.Value)
            : existingAgent;

            if (newAgent is null)
                throw new KeyNotFoundException("New manager not found.");


            existingProperty.Update(
                existingProperty.Id,
                newAgent,
                IsValidEnum(property.PropertyType, existingProperty.PropertyType),
                property.Price == 0 ? existingProperty.Price : property.Price,
                property.PriceBySquareMeter == 0 ? existingProperty.PriceBySquareMeter : property.PriceBySquareMeter,
                property.SizeBySquareMeters == 0 ? existingProperty.SizeBySquareMeters : property.SizeBySquareMeters,
                IsValidString(property.Description, existingProperty.Description),
                existingProperty.Address,
                IsValidEnum(property.TransactionType, existingProperty.TransactionType),
                IsValidEnum(property.Availability, existingProperty.Availability),
                new List<Room>(),
                new List<PropertyImage>()
            );


            _unitOfWork.PropertyRepository.Update(existingProperty);
            _unitOfWork.Commit();


            var propertyDto = new PropertyDto
            {
                Id = existingProperty.Id,
                Agent = new AgentDto
                {
                    EmployeeNumber = existingProperty.Agent.EmployeeNumber,
                    AgentNumber = existingProperty.Agent.AgentNumber,
                    FirstName = existingProperty.Agent.Name.FirstName,
                    LastName = existingProperty.Agent.Name.LastName,
                    Email = existingProperty.Agent.Account.Email,
                },
                PropertyType = existingProperty.PropertyType,
                Price = existingProperty.Price,
                PriceBySquareMeter = existingProperty.PriceBySquareMeter,
                SizeBySquareMeters = existingProperty.SizeBySquareMeters,
                Description = existingProperty.Description,
                Address = new AddressDto
                {
                    Street = existingProperty.Address.Street,
                    Number = existingProperty.Address.Number,
                    PostalCode = existingProperty.Address.PostalCode,
                    City = existingProperty.Address.City,
                    Country = existingProperty.Address.Country,

                },
                TransactionType = existingProperty.TransactionType,
                Availability = existingProperty.Availability,

            };

            return propertyDto;
        }
    }
}
