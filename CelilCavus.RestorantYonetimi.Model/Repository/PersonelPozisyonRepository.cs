using CelilCavus.RestorantYonetimi.Entites.Entites;
using CelilCavus.RestorantYonetimi.Entites.Enums;
using CelilCavus.RestorantYonetimi.Model.Interface;
using CelilCavus.RestorantYonetimi.Model.Models;
using Dapper;

namespace CelilCavus.RestorantYonetimi.Model.Repository
{
    public class PersonelPozisyonRepository : BaseRepository<PersonelPozisyon>, IRepository<PersonelPozisyon>
    {
        private readonly TableName _name;
        public PersonelPozisyonRepository(TableName table) : base(table)
        {
            _name = table;
        }

        public async Task AddAsync(PersonelPozisyon item)
        {
            string InsertQuery = $@"insert into {_name} ({GetColumnName(_name)}) values ('{item.persPozisyonAdi}')";
            await DbContext.Context.ExecuteAsync(InsertQuery);
        }

        public async Task UpdateAsync(PersonelPozisyon item, int id)
        {
            string UpdateQuery = $@"UPDATE {_name} SET 
            {GetColumnName(_name, 2)} = '{item.persPozisyonAdi}' 
            WHERE  {GetColumnName(_name, 1)} = {id}";
            await DbContext.Context.ExecuteAsync(UpdateQuery);
        }
    }
}
