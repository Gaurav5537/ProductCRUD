using ProductCRUD.Models;

namespace ProductCRUD.Repository
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> Get();
        //Task<Product> FindById(Guid ProductId);
        Task<Product> FindById(int ProductId);

        Task<Product> Add(Product product);

        Task<Product> Update(Product product);

        Task<Product> Delete(Product product);
    }
}
