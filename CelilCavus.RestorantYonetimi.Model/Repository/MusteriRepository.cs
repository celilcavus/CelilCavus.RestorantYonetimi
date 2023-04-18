using CelilCavus.RestorantYonetimi.Entites.Entites;
using CelilCavus.RestorantYonetimi.Entites.Enums;
using CelilCavus.RestorantYonetimi.Model.Interface;
using CelilCavus.RestorantYonetimi.Model.Models;
using Dapper;

namespace CelilCavus.RestorantYonetimi.Model.Repository
{
    public class MusteriRepository : BaseRepository<Musteri>, IRepository<Musteri>
    {
        private readonly TableName _name;
        public MusteriRepository(TableName table) : base(table)
        {
            _name = table;
        }

        public async Task AddAsync(Musteri item)
        {
            string InsertQuery = @$"Insert into {_name} ({GetColumnName(_name)}) values ('{item.MusteriAdi}','{item.MusteriSoyadi}','{item.MusteriAdres}','{item.MusteriTel}')";

            await DbContext.Context.ExecuteAsync(InsertQuery);
        }

        public async Task UpdateAsync(Musteri item, int id)
        {
            string UpdateQuery = @$"UPDATE {_name} SET 
            {GetColumnName(_name, 2)} = '{item.MusteriAdi}',
            {GetColumnName(_name, 3)} = '{item.MusteriSoyadi}',
            {GetColumnName(_name, 4)} = '{item.MusteriTel}',
            {GetColumnName(_name, 5)} = '{item.MusteriAdres}' 
            WHERE {GetColumnName(_name, 1)} = {id}";

            await DbContext.Context.ExecuteAsync(UpdateQuery);
        }
    }
}
