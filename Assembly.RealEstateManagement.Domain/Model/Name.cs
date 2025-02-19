namespace Assembly.RealEstateManagement.Domain.Model;

public class Name
{

    public string FirstName { get; private set; }

    public string[] MiddleNames { get; private set; }
    public string LastName { get; private set; }

    public string FullName => GetFormattedName();


    private Name()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        MiddleNames = Array.Empty<string>();
    }

    

    private Name(string firstName, string lastName) : this()
    {
        ValidateName(firstName, lastName);
        FirstName = firstName;
        LastName = lastName;
    }

    private Name(string firstName, string[] middleNames, string lastName) : this(firstName, lastName)
    {
        ValidateMiddleNames(middleNames);
        MiddleNames = middleNames ?? Array.Empty<string>();
    }

    public static Name Create(string firstName, string[] middleNames, string lastName)
    {
        
        return new Name(firstName, middleNames, lastName);

    }
    public static Name UpdateName(string firstName, string[] middleNames, string lastName)
    {
        
        return new Name(firstName, middleNames, lastName);
    }


    private void ValidateName(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentNullException("First name is required");
        }
        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentNullException("Last name is required");
        }
        if (firstName.Length > 15 || firstName.Length <= 2)
        {
            throw new ArgumentException("First name cannot be longer than 50 characters and short or equal than 2");
        }
        if (lastName.Length > 15 || lastName.Length <= 2)
        {
            throw new ArgumentException("Last name cannot be longer than 50 characters and short or equal than 2");
        }
    }

    private void ValidateMiddleNames(string[] middleNames)
    {
        if (middleNames != null)
        {
            foreach (var middleName in middleNames)
            {
                if (middleName.Length > 15 || middleName.Length <= 2)
                {
                    throw new ArgumentException("Middle name cannot be longer than 50 characters and short or equal than 2");
                }
            }
        }
    }

    private string GetFormattedName() 
    {
        return $"{FirstName} {string.Join(" ", MiddleNames)} {LastName}";
    }
}
