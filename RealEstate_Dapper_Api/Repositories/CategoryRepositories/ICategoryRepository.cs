using RealEstate_Dapper_Api.Dtos.CategoryDtos;
namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void DeleteCategory(int id); //sileceğimiz kategorinin id'yi aldık

        void UpdateCategory(UpdateCategoryDto categoryDto);
    }
}
