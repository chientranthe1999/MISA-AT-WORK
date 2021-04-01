using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Architect.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Architect.Controllers
{
    /// <summary>
    /// Api cho đối tượng khách hàng
    /// </summary>
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : BaseEntityController<Customer>
    {
        /// <summary>
        /// Thêm dữ liệu mới
        /// </summary>
        /// <returns>
        /// - Trả về mã HTTP Code 200 và dữ liệu nếu lấy thành công, 204 nếu ko có dữ liệu, 400 nếu có lỗi request
        /// </returns>
        /// CreatedBy: Chiến Nobi (01/04/2021)
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            // Khởi tạo kết nối
            // Check trùng mã khách hàng CustomerCode
            var sqlCheckExistCode = $"Select CustomerCode From Customer Where CustomerCode = \"{customer.CustomerCode}\"";
            var customerCodeExist = _dbConnection.Query<Customer>(sqlCheckExistCode, commandType: CommandType.Text);

            if (customerCodeExist.Count() == 0)
            {
                var storeName = "Proc_InsertCustomer";
                var rowAffects = _dbConnection.Execute(storeName, param: customer, commandType: CommandType.StoredProcedure);

                return Ok(rowAffects);
            }
            else return BadRequest();

        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <returns>
        /// - Trả về mã HTTP Code 200 và dữ liệu nếu lấy thành công, 204 nếu ko có dữ liệu, 400 nếu có lỗi request
        /// </returns>
        /// CreatedBy: Chiến Nobi (01/04/2021)
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <returns>
        /// - Trả về mã HTTP Code 200 
        /// </returns>
        /// CreatedBy: Chiến Nobi (01/04/2021)
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
