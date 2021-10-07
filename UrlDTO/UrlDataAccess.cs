using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using URLConverter.Models;

namespace URLConverter.UrlDTO
{
    public class UrlDataAccess
    {
        //Load All the Convert URL from the Database table [dbo].[URL]
        public static List<URLConverterModel> LoaduRLConverters()
        {
            string sql = @"select * from [dbo].[URL]";
            using var conn = DB.GetConnection();
            return conn.Query<URLConverterModel>(sql).ToList();
        }

        public static URLConverterModel LoadSelectUrl(string hashURL)
        {
            string sql = @"select * from [dbo].[URL] where NewUrl = @hashURL order by [createDate] desc";
            using var conn = DB.GetConnection();
            return conn.QueryFirstOrDefault<URLConverterModel>(sql, new { hashURL });
        }

        //Insert the the Original URL and the NewURL 
        public static int InsertQuery(URLConverterModel model)
        {
            string sql = @"INSERT INTO [dbo].[URL](UrlOriginal,NewUrl,createDate)
                           OUTPUT INSERTED.URLid
                           VALUES(@UrlOriginal,@NewUrl,GETDATE())";
            var data = new
            {
                model.UrlOriginal,
                model.NewUrl
            };

            using var conn = DB.GetConnection();
            int id = conn.QuerySingle<int>(sql, data);
            return id;
        }
    }
}
