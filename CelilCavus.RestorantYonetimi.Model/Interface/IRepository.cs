using CelilCavus.RestorantYonetimi.Entites.Enums;

namespace CelilCavus.RestorantYonetimi.Model.Interface
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T item);
        Task UpdateAsync(T item, int id);

    }
}
