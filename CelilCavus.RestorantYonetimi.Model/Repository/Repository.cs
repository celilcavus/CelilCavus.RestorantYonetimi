using CelilCavus.RestorantYonetimi.Entites.Enums;
using CelilCavus.RestorantYonetimi.Model.Models;
using Dapper;

namespace CelilCavus.RestorantYonetimi.Model.Repository
{
    public abstract class Repository
    {
        public static string GetColumnName(TableName table)
        {
            var val = DbContext.Context.Query<string>(@$"
            select COLUMN_NAME
            from INFORMATION_SCHEMA.COLUMNS
            where TABLE_NAME= '{table}' and ORDINAL_POSITION >= 2").ToList();
            var s = string.Join(",", val);
            return s;
        }
        public static string GetColumnName(TableName table, int ORDINAL_POSITION = 1)
        {
            var val = DbContext.Context.Query<string>(@$"
            select COLUMN_NAME
            from INFORMATION_SCHEMA.COLUMNS
            where TABLE_NAME= '{table}' and ORDINAL_POSITION = {ORDINAL_POSITION}").ToList();
            var s = string.Join(",", val);
            return s;
        }
    }
}
