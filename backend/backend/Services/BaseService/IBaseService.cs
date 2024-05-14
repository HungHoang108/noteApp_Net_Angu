using backend.Repositories.BaseRepo;

namespace backend.Services.BaseService
{
    public interface IBaseService<T, TCreateDto, TReadDto, TUpdateDto>
    {
        Task<ICollection<TReadDto>> GetAllAsync(QueryOptions options);
        Task<TReadDto?> GetAsync(int id);
        Task<TReadDto> UpdateAsync(int id, TUpdateDto update);
        Task<bool> DeleteAsync(int id);
        Task<TReadDto> CreateAsync(TCreateDto create);
    }
}
