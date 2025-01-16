﻿
using Assembly.RealEstateManagement.ConsoleApp.UserInterface;
using Assembly.RealEstateManagement.IoC;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");


//var name = Name.CreateName("John", new string[] { "Paul" }, "Doe");
//var account = Account.Create("john.doe@example.com", "Password123!");
//var contact = Contact.CreateContact(ContactType.Email, "john.doe@example.com");

//var client = Client.CreateClient(name, account, contact);

//Console.WriteLine("Client created successfully.");
//Console.WriteLine($"Name: {client.Name.FullName}"); 
//Console.WriteLine($"Email: {client.Account.Email}");
//Console.WriteLine($"Contact: {client.Contact.Value}");

var services = new ServiceCollection();

services.AddServices();
services.AddSingleton<Start>();

using var serviceProvider = services.BuildServiceProvider();

var start = serviceProvider.GetService<Start>();

start.Create();
start.GetAll();

start.AddVisit(1);
start.GetMyVisits(1);