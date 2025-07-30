using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MdmApi.Repository
{
    public interface IDatabaseSecureConnectionHelperRepository
    {
        string ConnectionString { get; set; }
       
     
        DataSet ExecuteAsDataSet_bk(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection);
        //List<DataTable> GetRefCursorData(string FunctionName, List<object> Parameters);
        DataSet ExecuteDataSet(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection);
        DataSet ExecuteAsDataSet(string storedProcedureName,string outResults, List<KeyValuePair<string, object>> parameterCollection);
        DataSet ExecuteQuery(string query, Dictionary<string, object> parameters);
    }
}
 