namespace Service_Provider.Controllers.Models.Requests;

public class ServiceRequest : IRequest
{
    public string name { get; set; }
    public decimal price { get; set; }
}

