using CelilCavus.RestorantYonetimi.Model.Models;
using CelilCavus.RestorantYonetimi.Entites.Enums;
using Dapper;
using CelilCavus.RestorantYonetimi.Entites.Entites;
using CelilCavus.RestorantYonetimi.Model.Interface;

namespace CelilCavus.RestorantYonetimi.Model.Repository
{
    public class MenuRepository :BaseRepository<Menu>, IRepository<Menu>
    {
        private readonly TableName _name;
        public MenuRepository(TableName table) : base(table)
        {
            _name = table;
        }

        public async Task AddAsync(Menu item)
        {
            string query = @$"Insert into 
            {_name} 
            ({GetColumnName(_name)}) 
            values 
            ('{item.yemekAdi}','{item.yemekFiyati}','{item.yemekTarifi}',{item.yemekKategoriId})
            ";
            await DbContext.Context.ExecuteAsync(query);
        }


        public async Task UpdateAsync(Menu item, int id)
        {
            string query = @$"Update 
            {_name} set      
            yemekAdi = '{item.yemekAdi}' , 
            yemekFiyati = '{item.yemekFiyati}',
            yemekTarifi = '{item.yemekTarifi}',
            yemekKategoriId = {item.yemekKategoriId}
            where {GetColumnName(_name, 1)} = {id}";
            await DbContext.Context.ExecuteAsync(query);
        }
    }
}
