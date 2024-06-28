using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;


        //çağırdığımı context constructın içine yazdık 
        //bağlantıyı getirdik
        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            string query = "SELECT * FROM Product";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDtocs>> GetAllProductsWithCategoryAsync()
        {
            string query = "SELECT ProductID,Title,Price,City,District,CategoryName FROM Product INNER JOIN Category ON Product.ProductCategory = Category.CategoryID";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDtocs>(query);
                return values.ToList();
            }
        }
    }
}
