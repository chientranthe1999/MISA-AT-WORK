import axios from 'axios';

// eslint-disable-next-line no-unused-vars
var baseUrl = 'https://localhost:44388/api/v1/Customers';

/**
 * Đối tượng thực thi các API với khách hàng
 */
const customerApi = {
    // Lấy danh sách khách hàng
    getCustomers: async() => {
        var res = await axios.get(baseUrl);
        return res;
    },

    // Check trùng mã khách hàng
    checkExistCustomerCode: async(customerCode) => {
        var url = `${baseUrl}/by?code=${customerCode}`;
        var res = await axios.get(url);
        return res;
    },

    // Thêm mới khách hàng
    addNewCustomer: async(body) => {
        var res = await axios.post(baseUrl, body);
        return res;
    },

    // Get khách hàng by customerID
    getCustomerById: async(customerId) => {
        var url = baseUrl + '/' + customerId;
        var res = await axios.get(url);
        return res;
    },
    // Sửa thông tin khách hàng

    // Xóa khách hàng

    // Xóa nhiều khách hàng
};

export { customerApi };