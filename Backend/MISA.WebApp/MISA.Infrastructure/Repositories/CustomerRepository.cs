using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// CreatedBy: Chiến Nobi (05/04/2021)
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public bool GetByCustomerCode(string customerCode)
        {
            var sqlQuery = $"Select CustomerCode from Customer Where CustomerCode = \"{customerCode}\"";

            var res = _dbConnection.Query<Customer>(sqlQuery, commandType: CommandType.Text).FirstOrDefault();

            if (res != null) return true;

            else return false;
        }
    }
}
