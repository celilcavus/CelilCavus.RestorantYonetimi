namespace CelilCavus.RestorantYonetimi.Model.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task DeleteAsync(int id);
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(int id);
    }
}