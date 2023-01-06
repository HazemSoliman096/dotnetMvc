namespace DPInjection.Models
{
  public class Repository : IRepository
  {
    private Dictionary<string, Product> products;

    public Repository()
    {
      products = new();
      new List<Product> {
        new Product {Name = "p1", Price = 99},
        new Product {Name = "p2", Price = 29},
        new Product {Name = "p3", Price = 19},
      }.ForEach(p => AddProduct(p));
    }

    public IEnumerable<Product> Products => products.Values;
    public Product this[string name] => products[name];
    public void AddProduct(Product product) => products[product.Name] = product;
    public void DeleteProduct(Product product) => products.Remove(product.Name);
  }
}
