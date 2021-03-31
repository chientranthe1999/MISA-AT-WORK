using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            // connection string
            var connectionString = "User Id=dev;Host=47.241.69.179;Character Set=utf8; Password=12345678; Database=MF0_NVManh_CukCuk02";
            // Khởi tạo kết nối tới Database
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Thực hiện truy vấn đến Database
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);

            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

            // validate id
            // connection string
            var connectionString = "User Id=dev;Host=47.241.69.179;Character Set=utf8; Password=12345678; Database=MF0_NVManh_CukCuk02";
            // Khởi tạo kết nối tới Database
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Thực hiện truy vấn đến Database
            var customer = dbConnection.Query<Customer>("Proc_GetCustomers", new { customerId = id } ,commandType: CommandType.StoredProcedure).FirstOrDefault();

            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            // check trùng mã customer code

            // connection string
            var connectionString = "User Id=dev;Host=47.241.69.179;Character Set=utf8; Password=12345678; Database=MF0_NVManh_CukCuk02";
            // Khởi tạo kết nối tới Database
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Thực hiện truy vấn đến Database
            var rowEffect = dbConnection.Execute("Proc_InsertCustomer", customer, commandType: CommandType.StoredProcedure);

            return Created("done", rowEffect);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Customer customer)
        {

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
