using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Architect.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public abstract class BaseEntityController<T> : ControllerBase
    {
        #region Declare
        string _connectionString = "" +
                "User Id=dev;" +
                "Host=47.241.69.179;" +
                "Character Set=utf8;" +
                "Database=MF0_NVManh_CukCuk02;" +
                "Password=12345678";

        protected IDbConnection _dbConnection;
        protected string _tableName;
        #endregion

        #region Constructor
        public BaseEntityController()
        {
            _tableName = typeof(T).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Hàm lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>
        /// Trả về mã HTTP Code 200 và dữ liệu nếu lấy thành công, 204 nếu ko có dữ liệu, 400 nếu có lỗi request
        /// </returns>
        /// CreatedBy: Chiến Nobi (01/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            // Lấy dữ liệu từ database
            var customers = _dbConnection.Query<T>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);

            // Kiểm tra và trả kết quả về cho người dùng
            if (customers.Count() == 0)
            {
                return NoContent();
            }
            else return Ok(customers);

        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <returns>
        /// - Trả về mã HTTP Code 200 và dữ liệu nếu lấy thành công, 204 nếu ko có dữ liệu, 400 nếu có lỗi request
        /// </returns>
        /// CreatedBy: Chiến Nobi (01/04/2021)
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdInputParamName = $"{_tableName}Id";
            // Create Object with dynamic key {storeGetByIdInputParamName = id}
            dynamicParameters.Add(storeGetByIdInputParamName, id);

            //lấy dữ liệu từ database
            var res = _dbConnection.Query<T>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            // Trả về kết quả cho người dùng
            if (res == null)
            {
                return NoContent();
            }
            else return Ok(res);
        }
        #endregion
    }
}
