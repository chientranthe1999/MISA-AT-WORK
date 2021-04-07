using MISA.Core.Entities;
using MISA.Core.Interfaces;


namespace MISA.WebApp.Controllers
{
    /// <summary>
    /// API Danh mục Nhóm khách hàng
    /// </summary>
    /// CretedBy: Chiến Nobi (07/04/2021)
    public class CustomerGroupController : BaseEntityController<CustomerGroup>
    {
        #region Declare
        ICustomerGroupService _customerGroupService;
        #endregion

        #region Constructor
        public CustomerGroupController(ICustomerGroupService customerGroupService) : base(customerGroupService)
        {
            _customerGroupService = customerGroupService;
        }
        #endregion
    }
}
