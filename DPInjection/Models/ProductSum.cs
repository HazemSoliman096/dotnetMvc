namespace DPInjection.Models
{
  public class ProductSum
  {
    public IRepository Repository { get; set; }

    public ProductSum(IRepository repository)
    {
      Repository = repository;
    }

    public decimal total => Repository.Products.Sum(p => p.Price);
  }
}