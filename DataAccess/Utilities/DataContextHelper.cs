using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Dynamic;

namespace DataAccess.Utilities
{
    public static class DataContextHelper
    {
        private static Lazy<string> _ApplicationDatabaseConnectionString = new Lazy<string>(() => ConfigurationManager.ConnectionStrings["NubimetricsConnectionString"].ConnectionString);

        public static string ApplicationDatabaseConnectionString
        {
            get
            {
                return _ApplicationDatabaseConnectionString.Value;
            }
        }

        /// <summary>
        /// Create and return a new connection to the database
        /// </summary>
        /// <typeparam name="T"> T must be a dataContext</typeparam>

        public static T GetDataContext<T>()
                   where T : DataContext
        {
            T result;

            string connectionString = ApplicationDatabaseConnectionString;

            result = (T)Activator.CreateInstance(typeof(T), connectionString);

            return result;
        }

        /// <summary>
        /// Executes a stored procedure that contains a table as a parameter
        /// </summary>
        /// <param name="storedProcedureName"> name of the stored procedure</typeparam>
        /// <param name="tableParameterName"> table parameter name</typeparam>
        /// <param name="table"> table to be passed as a parameter</typeparam>
        /// <param name="tableTypeParameterName"> name of the type of table that will be passed as a parameter</typeparam>
        public static void ExecuteStoredProcedureWithTableValuedParameters (string storedProcedureName, string tableParameterName, DataTable table, string tableTypeParameterName)
        {

            if(string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentNullException("storedProcedureName empty");
            }
            else if(string.IsNullOrEmpty(tableParameterName))
            {
                throw new ArgumentNullException("tableName empty");
            }
            else if(string.IsNullOrEmpty(tableTypeParameterName))
            {
                throw new ArgumentNullException("parameterName empty");
            }
            else if(table == null)
            {
                throw new ArgumentNullException("table null");
            }

            var sqlConnection = new SqlConnection(ApplicationDatabaseConnectionString);
            sqlConnection.Open();

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = storedProcedureName;

                var sqlParameter = new SqlParameter(tableTypeParameterName, SqlDbType.Structured);
                sqlParameter.TypeName = tableParameterName;
                sqlParameter.Value = table;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.ExecuteReader();
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
