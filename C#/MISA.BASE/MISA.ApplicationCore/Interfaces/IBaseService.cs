using MISA.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public interface IBaseService<T>
    {
        IEnumerable<T> Get();
        T GetById(Guid id);
        ServiceResult Add(T t);
        ServiceResult Delete(Guid id);
        ServiceResult Update(T t);

    }
}
