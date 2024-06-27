using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Diagnostics.Contracts;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;


        //çağırdığımı context construct yazdık 
        //bağlantıyı getirdik
        public CategoryRepository(Context context) 
        {
            _context = context;
        }

        //interface olarak çağırdığımızın içine sorgumuzu yazıyoruz
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "SELECT * FROM Category";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        //interface olarak çağırdığımızın içine sorgumuzu yazıyoruz
        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "INSERT INTO Category (CategoryName,CategorStatus) values(@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters(); //parametre değişkenini oluşturduk
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                //ekleme ve silme için execute metodu kullanılılır
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "DELETE FROM Category WHERE CategoryID = @categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
                
        }

       

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "UPDATE Category SET CategoryName=@name , CategorStatus=@status WHERE CategoryID = @id";
            
            var parameters = new DynamicParameters();
            parameters.Add("@name", categoryDto.CategoryName);
            parameters.Add("@status", categoryDto.CategoryStatus);
            parameters.Add("@id", categoryDto.CategoryID);

            using(var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }

        }
    }
}
