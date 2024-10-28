
namespace Product.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveDto, BaseDto, Model>
        where SaveDto : class
        where BaseDto : class
        where Model : class
    {
        Task Update(SaveDto viewModel, int id);
        Task<SaveDto> Add(SaveDto viewModel);
        Task Delete(int id);
        Task<SaveDto> GetByIdSaveViewModel(int id);
        Task<List<BaseDto>> GetAllViewModel();
    }
}
