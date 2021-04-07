using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WebApp.Controllers
{
    /// <summary>
    /// Api danh muc khach hang
    /// CreatedBy: Chiến Nobi (05/04/2021)
    /// </summary>
    public class CustomerController : BaseEntityController<Customer>
    {
        #region Declare
        ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomerController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
        #endregion

    }
}
