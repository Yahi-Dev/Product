using AutoMapper;
using Product.Core.Application.Interfaces.Repositories;
using Product.Core.Application.Interfaces.Services;


namespace Product.Core.Application.Services
{
    public class GenericService<SaveDto, BaseDto, Model> : IGenericService<SaveDto, BaseDto, Model>
           where SaveDto : class
           where BaseDto : class
           where Model : class
    {
        private readonly IGenericRepository<Model> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Model> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task Update(SaveDto viewModel, int id)
        {
            Model entity = _mapper.Map<Model>(viewModel);
            await _repository.UpdateAsync(entity, id);
        }

        public virtual async Task<List<BaseDto>> GetAllViewModel()
        {
            var entitylist = await _repository.GetAllAsync();

            return _mapper.Map<List<BaseDto>>(entitylist);
        }

        public virtual async Task<SaveDto> Add(SaveDto viewModel)
        {
            Model entity = _mapper.Map<Model>(viewModel);
            entity = await _repository.AddAsync(entity);
            SaveDto Savevm = _mapper.Map<SaveDto>(entity);
            return Savevm;
        }


        public virtual async Task<SaveDto> GetByIdSaveViewModel(int id)
        {
            Model entity = await _repository.GetEntityByIdAsync(id);

            SaveDto Savevm = _mapper.Map<SaveDto>(entity);
            return Savevm;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _repository.GetEntityByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
