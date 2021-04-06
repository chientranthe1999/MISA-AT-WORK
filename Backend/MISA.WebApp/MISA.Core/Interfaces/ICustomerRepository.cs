using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Hàm tìm khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>
        /// - True nếu tìm thấy
        /// - False nếu không tìm thấy
        /// </returns>
        /// CreatedBy: Chiến Nobi (05/04/2021)
        public bool GetByCustomerCode(string customerCode);
    }
}
