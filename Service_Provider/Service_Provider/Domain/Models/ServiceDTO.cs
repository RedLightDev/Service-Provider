namespace Service_Provider.Domain.Models;

public class ServiceDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ServiceDTO(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public ServiceDTO(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

