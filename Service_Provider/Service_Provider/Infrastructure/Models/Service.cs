
namespace Service_Provider.Infrastructure.Entity
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set;}

        public Service()
        {

        }
        public Service(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
