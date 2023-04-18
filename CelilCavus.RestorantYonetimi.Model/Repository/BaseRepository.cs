using CelilCavus.RestorantYonetimi.Entites.Enums;
using CelilCavus.RestorantYonetimi.Model.Interface;
using CelilCavus.RestorantYonetimi.Model.Models;
using Dapper;

namespace CelilCavus.RestorantYonetimi.Model.Repository
{
    public class BaseRepository<T> : Repository,IBaseRepository<T> where T : class
    {
        private readonly TableName _name;

        public BaseRepository(TableName table)
        {
            _name = table;
        }
        public async Task DeleteAsync(int id)
        {
            await DbContext.Context.ExecuteAsync(@$"Delete from {_name} where 
            {GetColumnName(_name, 1)} = {id}");
        }

        public async Task<T> GetByIdAsync(int id)
        {
            string query = @$"Select * from {_name} where {GetColumnName(_name,1)} = {id}";

            var val = await DbContext.Context.QueryAsync<T>(query);
            return val.FirstOrDefault();
        }

        public async Task<List<T>> GetListAsync()
        {
            var val = await DbContext.Context.QueryAsync<T>($"select * from {_name}");
            return val.ToList();
        }

    }
}
