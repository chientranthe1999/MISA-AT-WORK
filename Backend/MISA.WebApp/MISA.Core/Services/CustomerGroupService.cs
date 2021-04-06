using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        #region Declare
        ICustomerGroupRepository _customerGroupRepository;
        #endregion

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository) : base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
    }
}
