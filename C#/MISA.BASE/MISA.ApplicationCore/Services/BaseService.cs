using MISA.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Declare
        IBaseRespository<T> _baseRespository;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IBaseRespository<T> baseRespository)
        {
            _baseRespository = baseRespository;
            _serviceResult = new ServiceResult();
        }
        #endregion


        #region Method
        public ServiceResult Add(T t)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            return _baseRespository.Get();
        }

        public T GetById(Guid id)
        {
            return _baseRespository.GetById(id);
        }

        public ServiceResult Update(T t)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
