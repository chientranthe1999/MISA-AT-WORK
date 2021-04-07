using MISA.Core.Entities;
using MISA.Core.Interfaces;


namespace MISA.Core.Services
{
    /// <summary>
    /// Service xử lý các nghiệp vụ liên quan tới CustomerGroup
    /// </summary>
    /// CreatedBy: Chiến Nobi (07/04/2021)
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
