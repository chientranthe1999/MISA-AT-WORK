using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class CustomerGroup : BaseEntity
    {
        /// <summary>
        /// Khóa chính kiểu Guid
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên của nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        public string ParentId { get; set; }

        /// <summary>
        /// Mô tả chi tiết
        /// </summary>
        public string Description { get; set; }
    }
}
