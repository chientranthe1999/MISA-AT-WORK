using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Architect.Model
{
    /// <summary>
    /// Thông tin khách hàng
    /// </summary>
    /// CreatedBy: Chiến Nobi (01/04/2021)
    public class Customer : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid? CustomerGroupId { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Note { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string MemberCardCode { get; set; }
        public string Email { get; set; }
        public string CompanyTaxCode { get; set; }
    }
}
