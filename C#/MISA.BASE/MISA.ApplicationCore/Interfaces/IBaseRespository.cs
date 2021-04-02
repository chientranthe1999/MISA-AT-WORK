using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public interface IBaseRespository<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Lấy dữ liệu bằng ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dữ liệu tìm thấy</returns>
        T GetById(Guid id);

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="t">Dữ liệu để thêm vào</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        int Add(T t);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(string id);

    }
}
