﻿using MISA.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Trả về danh sách đối tượng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: Chiến Nobi (05/04/2021)
        IEnumerable<T> Get();

        /// <summary>
        /// Trả về đối tượng có ID tương ứng
        /// </summary>
        /// <param name="id">ID của đối tượng</param>
        /// <returns>
        /// - null nếu không tìm thấy, 
        /// - Trả về đối tượng đó nếu được tìm thấy
        /// </returns>
        /// CreatedBy: Chiến Nobi (05/04/2021)
        T GetById(Guid id);

        /// <summary>
        /// Thêm đối tượng mới
        /// </summary>
        /// <param name="t">Đối tượng t</param>
        /// <returns>Số dòng bị ảnh hưởng trong database</returns>
        /// CreatedBy: Chiến Nobi (05/04/2021) 
        int Add(T t);

        /// <summary>
        /// Xóa đối tượng bằng ID
        /// </summary>
        /// <param name="id">ID của đối tượng</param>
        /// <returns>Số dòng bị ảnh hưởng trong database</returns>
        /// CreatedBy: Chiến Nobi (05/04/2021)
        int Delete(Guid id);

        /// <summary>
        /// Sửa đối tượng theo ID
        /// </summary>
        /// <param name="t">Đối tượng truyền vào</param>
        /// <param name="id">ID của đối tượng</param>
        /// <returns>Số dòng bị ảnh hưởng trong database</returns>
        /// CreatedBy: Chiến Nobi (05/04/2021)
        int Update(T t, Guid id);

    }
}
