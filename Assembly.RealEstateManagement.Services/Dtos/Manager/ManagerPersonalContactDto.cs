﻿namespace Assembly.RealEstateManagement.Services.Dtos.Manager;

public class ManagerPersonalContactDto
{
    public string ContactType { get; set; }
    public string Value { get; set; }

    public ManagerDto Manager { get; set; }
}
