using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region Declare
        ICustomerRepository _customerRepository;
        #endregion

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #endregion

        #region Method
        public override bool Validate(Customer t)
        {
            
            bool isValid = true;
            var isDuplicate = _customerRepository.GetByCustomerCode(t.CustomerCode);
            // Chuyển kiểu Guid của CustomerGroupId sang String
            var customerGroupId = t.CustomerGroupId.ToString();

            _serviceResult.devMsg = String.Empty;

            // Check CustomerCode không được trống
            if (String.IsNullOrEmpty(t.CustomerCode))
            {
                _serviceResult.devMsg += Resouces.Message.EmptyCustomerCode;
                isValid = false;
            }

            // Check xem trường CustomerGroupId không được trống
            if (String.IsNullOrEmpty(customerGroupId))
            {
                _serviceResult.devMsg += ", " + Resouces.Message.EmptyCustomerGroupId;
                isValid = false;
            }

            // Check trùng mã
            if (isDuplicate)
            {
                _serviceResult.devMsg += ", " + Resouces.Message.DuplicateCustomerCode;
                isValid = false;
            }
            return isValid;
        }

        public bool getCustomerByCode(string customerCode)
        {
            var res = _customerRepository.GetByCustomerCode(customerCode);
            return res;
        }

        #endregion
    }
}
