using Project5_DapperNorthwind.Dtos.CategoryDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project5_DapperNorthwind.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();

        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

        Task DeleteCategoryAsync(int id);

        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);
    }
}