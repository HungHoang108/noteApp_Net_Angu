using AutoMapper;
using backend.Repositories.BaseRepo;

namespace backend.Services.BaseService
{
    public class BaseService<T, TCreateDto, TReadDto, TUpdateDto>
        : IBaseService<T, TCreateDto, TReadDto, TUpdateDto>
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseRepo<T> _repo;
        protected readonly ILogger<BaseService<T, TCreateDto, TReadDto, TUpdateDto>> _logger;

        public BaseService(IMapper mapper, IBaseRepo<T> repo, ILogger<BaseService<T, TCreateDto, TReadDto, TUpdateDto>> logger)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }

        public async Task<TReadDto> CreateAsync(TCreateDto create)
        {
            var entity = _mapper.Map<T>(create);
            var result = await _repo.CreateAsync(entity);
            if (result is null)
            {
                throw new ArgumentNullException(nameof(result), "Argument cannot be null.");
            }
            return _mapper.Map<T, TReadDto>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            if (item is null)
            {
                return false;
            }
            var result = await _repo.DeleteAsync(id);
            return result;
        }

        public virtual async Task<ICollection<TReadDto>> GetAllAsync(QueryOptions options)
        {
            var data = await _repo.GetAllAsync(options);
            return _mapper.Map<ICollection<TReadDto>>(data);
        }

        public async Task<TReadDto?> GetAsync(int id)
        {
            var entity = await _repo.GetAsync(id);
            if (entity is null)
            {
                throw new Exception("Not found");
            }
            return _mapper.Map<T, TReadDto>(entity);
        }

        public virtual async Task<TReadDto> UpdateAsync(int id, TUpdateDto update)
        {
            var item = await GetAsync(id);
            if (item is null)
            {
                throw new Exception("Not found");
            }
            var updateData = _mapper.Map<T>(update);
            var result = await _repo.UpdateAsync(id, updateData);

            return _mapper.Map<T, TReadDto>(result);
        }
    }
}
