using Dapper;
using MISA.ApplicationCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRespository<T> : IBaseRespository<T>
    {
        #region DECLARE
        string _connectionString = "User Id=dev;" +
            "Password=12345678" +
            "Database = MF0_NVManh_CukCuk02" +
            "Host=47.241.69.179;" +
            "Character Set = utf8";

        protected IDbConnection _dbConnection;

        protected string _tableName;
        #endregion

        #region Constructor
        public BaseRespository()
        {
            _tableName = typeof(T).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public IEnumerable<T> Get()
        {
            var res = _dbConnection.Query<T>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            return res;
        }

        public T GetById(Guid id)
        {
            string _idName = _tableName + "id";
            var res = _dbConnection.Query<T>($"Proc_Get{_tableName}ById", new { _idName = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;

        }

        public int Add(T t)
        {
            throw new NotImplementedException();
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
