using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MdmApi.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;

namespace MdmApi.Repository
{
    public class DatabaseSecureConnectionHelperRepository : IDatabaseSecureConnectionHelperRepository
    {
        public readonly IConfiguration _configuration;
        public string ConnectionString { get; set; }

        public string AuthType { get; set; }


        public DatabaseSecureConnectionHelperRepository(IConfiguration configuration, ConnectionString connectionString)
        {
            _configuration = configuration;
            ConnectionString = /*"LocalConnection";*/ _configuration.GetConnectionString(connectionString.ToString());
            AuthType = _configuration.GetSection("AuthType").Value;
        }
        /// <summary>
        /// Execute as DataSet.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <returns>Object of DataSet.</returns>
        public DataSet ExecuteAsDataSet_bk(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                // conn.Close();
                DataSet dataSet = new DataSet();
                conn.Open();

                // Start a transaction as it is required to work with cursors in PostgreSQL
                NpgsqlTransaction tran = conn.BeginTransaction();

                // Define a command to call stored procedure show_cities_multiple
                NpgsqlCommand command = new NpgsqlCommand(storedProcedureName, conn);
                command.CommandType = CommandType.StoredProcedure;

                // Execute the stored procedure and obtain the first result set
                //  NpgsqlDataReader dr = command.ExecuteReader();

                // Output the rows of the first result set
                DataSet ds = new DataSet();
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    while (reader.Read())
                    {

                        command = new NpgsqlCommand("FETCH ALL IN " + "\"" + reader[0].ToString() + "\"", conn); //use plpgsql fetch command to get data back
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                        da.Fill(dt);
                        //  ds.Add(dt); //all the data will save in the List<DataTable> ,no matter the connection is closed or returned multiple refcursors
                    }


                }



                tran.Commit();
                conn.Close();

                return null;


            }
        }


        public DataSet ExecuteDataSet(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection)
        {
            DataSet ds = new DataSet();
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "call public.mdm_getlogincheck(@loginuserid,@password, @_result_one)";
                        cmd.CommandType = CommandType.Text;
                        for (int i = 0; i < parameterCollection.Count; i++)
                        {
                            NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                            sqlParaMeter.IsNullable = true;
                            sqlParaMeter.ParameterName = parameterCollection[i].Key;
                            sqlParaMeter.Value = parameterCollection[i].Value;
                            cmd.Parameters.Add(sqlParaMeter);
                        }
                        //cmd.Parameters.Add("@loginuserid", NpgsqlDbType.Varchar).Value = "santosh";
                        //cmd.Parameters.Add("@password", NpgsqlDbType.Varchar).Value = "QeuCXA1EI8s=";
                        cmd.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "@_result_one",
                            NpgsqlDbType = NpgsqlDbType.Refcursor,
                            Value = "rs_resultone",
                            Direction = System.Data.ParameterDirection.InputOutput
                        });

                        //cmd.Parameters.Add(new NpgsqlParameter()
                        //{
                        //    ParameterName = "@ref_cur2",
                        //    NpgsqlDbType = NpgsqlDbType.Refcursor,
                        //    Value = "ref_cur2",
                        //    Direction = System.Data.ParameterDirection.InputOutput
                        //});


                        string cursor1Name, cursor2Name;

                        using (var reader1 = cmd.ExecuteReader())
                        {
                            reader1.Read();
                            cursor1Name = reader1.GetString(0);
                            //reader1.Read();
                            //cursor2Name = reader1.GetString(0);
                        }


                        using (var resultSet1 = conn.CreateCommand())
                        {
                            resultSet1.CommandText = $@"FETCH ALL FROM ""{cursor1Name}""";
                            using (var reader2 = resultSet1.ExecuteReader())
                            {
                                DataTable dt = new DataTable();
                                // call load method of datatable to copy content of reader 
                                dt.Load(reader2);
                                ds.Tables.Add(dt);
                            }
                        }

                    }
                }
            }
            return ds;
        }

        public DataSet ExecuteDataSetforMultipleResults_bk(string storedProcedureName, string outResults, List<KeyValuePair<string, object>> parameterCollection)
        {
            DataSet ds = new DataSet();

            int outResult = Convert.ToInt32(outResults);
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "call Mdm_GetTopNavBar(@RoleId, @_result_one,@_result_two,@_result_three,@_result_four,@_result_five,@_result_six)";
                        //
                        cmd.CommandType = CommandType.Text;
                        for (int i = 0; i < parameterCollection.Count; i++)
                        {
                            NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                            sqlParaMeter.IsNullable = true;
                            sqlParaMeter.ParameterName = parameterCollection[i].Key;
                            sqlParaMeter.Value = parameterCollection[i].Value;
                            cmd.Parameters.Add(sqlParaMeter);
                        }
                        cmd.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "@_result_one",
                            NpgsqlDbType = NpgsqlDbType.Refcursor,
                            Value = "rs_resultone",
                            Direction = System.Data.ParameterDirection.InputOutput
                        });

                        cmd.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "@_result_two",
                            NpgsqlDbType = NpgsqlDbType.Refcursor,
                            Value = "rs_resulttwo",
                            Direction = System.Data.ParameterDirection.InputOutput
                        });
                        cmd.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "@_result_three",
                            NpgsqlDbType = NpgsqlDbType.Refcursor,
                            Value = "rs_resultthree",
                            Direction = System.Data.ParameterDirection.InputOutput
                        });
                        cmd.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "@_result_four",
                            NpgsqlDbType = NpgsqlDbType.Refcursor,
                            Value = "rs_resultfour",
                            Direction = System.Data.ParameterDirection.InputOutput
                        });
                        cmd.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "@_result_five",
                            NpgsqlDbType = NpgsqlDbType.Refcursor,
                            Value = "rs_resultfive",
                            Direction = System.Data.ParameterDirection.InputOutput
                        });
                        cmd.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "@_result_six",
                            NpgsqlDbType = NpgsqlDbType.Refcursor,
                            Value = "rs_resultsix",
                            Direction = System.Data.ParameterDirection.InputOutput
                        });


                        string cursor1Name, cursor2Name;

                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            cursor1Name = reader.GetString(0);
                            reader.Read();
                            cursor2Name = reader.GetString(1);
                        }


                        using (var resultSet1 = conn.CreateCommand())
                        {
                            resultSet1.CommandText = $@"FETCH ALL FROM ""{cursor1Name}""";
                            using (var reader2 = resultSet1.ExecuteReader())
                            {
                                DataTable dt = new DataTable();
                                // call load method of datatable to copy content of reader 
                                dt.Load(reader2);
                                ds.Tables.Add(dt);
                            }
                        }
                        using (var resultSet1 = conn.CreateCommand())
                        {
                            resultSet1.CommandText = $@"FETCH ALL FROM ""{cursor2Name}""";
                            using (var reader2 = resultSet1.ExecuteReader())
                            {
                                DataTable dt = new DataTable();
                                // call load method of datatable to copy content of reader 
                                dt.Load(reader2);
                                ds.Tables.Add(dt);
                            }
                        }

                    }
                }
            }
            return ds;
        }


        public DataSet ExecuteAsDataSet(string storedProcedureName, string outResults, List<KeyValuePair<string, object>> parameterCollection)
        {
            DataSet ds = new DataSet();

            int outResult = Convert.ToInt32(outResults);
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = storedProcedureName;
                        //
                        cmd.CommandType = CommandType.Text;
                        if (parameterCollection != null)
                        {
                            for (int i = 0; i < parameterCollection.Count; i++)
                            {
                                NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                                sqlParaMeter.IsNullable = true;
                                sqlParaMeter.ParameterName = parameterCollection[i].Key;
                                sqlParaMeter.Value = parameterCollection[i].Value;
                                cmd.Parameters.Add(sqlParaMeter);
                            }
                        }

                        string num;
                        for (int i = 1; i <= outResult; i++)
                        {
                            num = Numbers.numerals.FirstOrDefault(x => x.Key == i).Value;
                            cmd.Parameters.Add(new NpgsqlParameter()
                            {
                                ParameterName = "@_result_" + num + "",
                                NpgsqlDbType = NpgsqlDbType.Refcursor,
                                Value = "rs_result" + num + "",
                                Direction = System.Data.ParameterDirection.InputOutput
                            });
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                        }
                        for (int i = 1; i <= outResult; i++)
                        {
                            string cursorNum = Numbers.numerals.FirstOrDefault(x => x.Key == i).Value;
                            string cursorName = "rs_result" + cursorNum + "";
                            using (var resultSet1 = conn.CreateCommand())
                            {
                                resultSet1.CommandText = $@"FETCH ALL FROM ""{cursorName}""";
                                using (var reader2 = resultSet1.ExecuteReader())
                                {
                                    string tableindex = string.Empty;
                                    if (i == 1)
                                        tableindex = string.Empty;
                                    else
                                        tableindex = Convert.ToString(i - 1);
                                    DataTable dt = new DataTable("Table" + tableindex + "");
                                    // call load method of datatable to copy content of reader 
                                    dt.Load(reader2);
                                    ds.Tables.Add(dt);
                                }
                            }
                        }
                    }
                    trans.Commit();
                }
            }
            return ds;
        }

        public DataSet ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // Add parameters dynamically
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataSet);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }

            return dataSet;
        }

    }
}
