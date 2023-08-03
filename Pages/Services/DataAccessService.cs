using System;
using System.Data.SqlTypes;
using System.Linq;
using Dapper;
using D2R_Items.Models;

namespace D2R_Items.Services;

public class DataAccessService
{
    public IEnumerable<Weapon>? Query(string query)
    {
        // string sql = "SELECT TOP 10 * FROM OrderDetails";

        // using (var connection = new SqlConnection(FiddleHelper.GetConnectionStringSqlServerW3Schools()))
        // {
        //     var orderDetail = connection.Query(sql).FirstOrDefault();

        //     FiddleHelper.WriteTable(orderDetail);
        // }
        // return null;
    }
}