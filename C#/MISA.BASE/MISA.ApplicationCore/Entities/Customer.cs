using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    public class Customer
    {
        #region Properties
        /// <summary>
        /// Primary Key ID của khách hàng
        /// </summary>
        /// In newer version of .NET -> Không phải chuyển kiểu Guid sang String 

        public String CustomerId { get; set; }

        public Guid CustomerGroupId { get; set; }

        public string CustomerCode { get; set; }

        public string FullName { get; set; }

        public string MemberCardCode { get; set; }

        public string? Address { get; set; }

        public string PhoneNumber { get; set; }

        /// <summary>
        /// Giới tính: Trả về 0: Nam, 1: Nũ, 2: Không xác định
        /// </summary>
        public int? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public string? Note { get; set; }

        public string? CompanyName { get; set; }

        public string? CompanyTaxCode { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        #endregion

    }
}
