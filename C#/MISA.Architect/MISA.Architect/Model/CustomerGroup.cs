using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Architect.Model
{
    public class CustomerGroup
    {
        /// <summary>
        /// Khóa chính của bảng
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string Description { get; set; }
        public string ParentId { get; set; }


    }
}
