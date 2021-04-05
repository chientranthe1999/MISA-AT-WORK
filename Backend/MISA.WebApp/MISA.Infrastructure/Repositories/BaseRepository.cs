using Dapper;
using MISA.Core.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        #region DECLARE
        string _connectionString = "User Id=dev;" +
            "Password=12345678;" +
            "Database = MF0_NVManh_CukCuk02;" +
            "Host=47.241.69.179;" +
            "Character Set = utf8";

        protected IDbConnection _dbConnection;

        protected string _tableName;
        #endregion

        #region Constructor
        public BaseRepository()
        {
            _tableName = typeof(T).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public IEnumerable<T> Get()
        {
            var res = _dbConnection.Query<T>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            //var res = _dbConnection.Query<T>("Select * from Customer", commandType: CommandType.Text);
            return res;
        }

        public T GetById(Guid id)
        {
            string _idName = _tableName + "id";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add(_idName, id);

            // Lấy dữ liệu từ database
            var res = _dbConnection.Query<T>($"Proc_Get{_tableName}ById", dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        public int Add(T t) { 
            var rowAffected = _dbConnection.Execute($"Proc_Insert{_tableName}", t, commandType: CommandType.StoredProcedure);
            return rowAffected;
        }

        public int Update(T t, Guid id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
