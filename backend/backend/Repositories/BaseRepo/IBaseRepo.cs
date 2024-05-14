namespace backend.Repositories.BaseRepo
{
    public interface IBaseRepo<T>
    {
        Task<ICollection<T>> GetAllAsync(QueryOptions options);
        Task<T?> GetAsync(int id);
        Task<T> UpdateAsync(int id, T request);
        Task<bool> DeleteAsync(int id);
        Task<T?> CreateAsync(T request);
    }

    public class QueryOptions
    {
        public string Sort { get; set; } = string.Empty;
        public string Search { get; set; } = string.Empty;
        public SortBy SortBy { get; set; }
        public int Limit { get; set; } = 30;
        public int Skip { get; set; } = 0;
    }

    public enum SortBy
    {
        ASC,
        DESC
    }

}
