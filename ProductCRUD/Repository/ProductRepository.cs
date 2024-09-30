using Dapper;
using Microsoft.Data.SqlClient;
using ProductCRUD.Data;
using ProductCRUD.Models;

namespace ProductCRUD.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<Product> Add(Product product)
        {
            product.CreatedTime = DateTime.Now;

            var strSql = @"Insert into Product(ProductName, ProductDesc, CreatedTime) " +
                "values (@ProductName, @ProductDesc, @CreatedTime)";
            
            using (var connection = _appDbContext.CreateConnection())
            {
                int affectedRow = await connection.ExecuteAsync(strSql, product);

                return product;
            }
        }

        public async Task<Product> Delete(Product product)
        {
            var strSql = @"DELETE FROM Product WHERE ID = @id";
            
            using (var connection = _appDbContext.CreateConnection())
            {
                int affectedRow = await connection.ExecuteAsync(strSql, product);

                return product;
            }
        }

        public async Task<Product> FindById(int ProductId)
        {
            string strSql = @"SELECT * FROM Product WHERE id=@id";
            using (var connection = _appDbContext.CreateConnection())
            {
                Product? product = await connection.QueryFirstOrDefaultAsync<Product>(strSql, new { id = ProductId });
                
                return product;
            }
        }

        public async Task<IEnumerable<Product>> Get()
        {
            string strSql = @"SELECT * FROM Product";
            using var connection = _appDbContext.CreateConnection();
            return await connection.QueryAsync<Product>(strSql);
        }

        public async Task<Product> Update(Product product)
        {
            product.CreatedTime = DateTime.Now;
            var strSql = @"Update Product SET ProductName=@ProductName, ProductDesc=@ProductDesc, 
                               CreatedTime=@CreatedTime WHERE ID = @id";

            using (var connection = _appDbContext.CreateConnection())
            {
                int affectedRow = await connection.ExecuteAsync(strSql, product);

                return product;
            }
        }
    }
}
