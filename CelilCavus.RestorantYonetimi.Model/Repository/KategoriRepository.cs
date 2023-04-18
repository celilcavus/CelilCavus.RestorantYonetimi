using CelilCavus.RestorantYonetimi.Entites.Entites;
using CelilCavus.RestorantYonetimi.Entites.Enums;
using CelilCavus.RestorantYonetimi.Model.Interface;
using CelilCavus.RestorantYonetimi.Model.Models;
using Dapper;

namespace CelilCavus.RestorantYonetimi.Model.Repository
{
    public class KategoriRepository : BaseRepository<YemekKategori>, IRepository<YemekKategori>
    {
        private readonly TableName _name;
        public KategoriRepository(TableName table) : base(table)
        {
            _name = TableName.YemekKategori;
        }

        public async Task AddAsync(YemekKategori item)
        {
            string InsertQuery = $@"Insert into {_name} ({GetColumnName(_name)}) values ('{item.KategoriAdi}')";

            await DbContext.Context.ExecuteAsync(InsertQuery);
        }

        public async Task UpdateAsync(YemekKategori item, int id)
        {
            string UpdateQuery = $@"UPDATE {_name} SET {GetColumnName(_name, 2)}='{item.KategoriAdi}' WHERE {GetColumnName(_name, 1)} = {id}";

            await DbContext.Context.ExecuteAsync(UpdateQuery);
        }
    }
}
