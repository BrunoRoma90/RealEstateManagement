﻿namespace Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;

public class AdministrativeUserPersonalContactDto
{
    public string ContactType { get; set; }
    public string Value { get; set; }

    public AdministrativeUserDto AdministrativeUser { get; set; }

}
