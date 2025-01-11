// See https://aka.ms/new-console-template for more information
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;

Console.WriteLine("Hello, World!");


var name = Name.CreateName("John", new string[] { "Paul" }, "Doe");
var account = Account.Create("john.doe@example.com", "Password123!");
var contact = Contact.CreateContact(ContactType.Email, "john.doe@example.com");

var client = Client.CreateClient(name, account, contact);

Console.WriteLine("Client created successfully.");
Console.WriteLine($"Name: {client.Name.FullName}"); 
Console.WriteLine($"Email: {client.Account.Email}");
Console.WriteLine($"Contact: {client.Contact.Value}");