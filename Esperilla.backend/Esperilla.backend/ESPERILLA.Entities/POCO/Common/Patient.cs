

using System.Net;

namespace ESPERILLA.Entities;

public class Patient:Base
{
    public Patient() { }

    public Patient( string name, string lastName, DateTime birthDate, string? address, string? phone)
    {
        Name = name;
        LastName = lastName;
        BirthDate = birthDate;
        Address = address;
        Phone = phone;
    }

    public Guid Id { get; internal set; }
    public string Name { get; internal set; }
    public string LastName { get; internal set; }
    public DateTime BirthDate { get; internal set; }
    public string? Address { get; internal set; }
    public string? Phone { get; internal set; }

    public void setName(string name)
    {
        Name = name;
    }
    public void setLastName(string lastName)
    {
        LastName = lastName;
    }
    public void setBirthDate(DateTime birthDate)
    {
        BirthDate = birthDate;
    }
    public void setAddress(string? address)
    {
        if (address != null)
        {
            Address = address;
        }
        
    }
    public void setPhone(string? phone)
    {
        if (phone != null)
        {
            Phone = phone;
        }
        
    }
}
