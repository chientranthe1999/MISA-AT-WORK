import { customerApi } from '../api/customerApi';

const Validator = {
    /**
     * Hàm check định dạng Email
     * @param {String} value: Check Email Format xxx@xxx.xxx
     * @returns true or false
     * @author: Chiến Nobi (5/4/2021)
     */
    validateEmailFormat: (value) => {
        var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(value);
    },

    /**
     * Hàm check không được để trống
     * @param {String} value Giá trị truyền vào để validate
     * @returns true nếu pass validate, false nếu ko pass
     */
    validateEmpty: (value) => {
        if (value == '' || value == undefined) return false;
        else return true;
    },

    /**
     *
     * @param {*} customerCode
     * @returns
     */

    validateCustomerCode: async(customerCode) => {
        var res = await customerApi.checkExistCustomerCode(customerCode);
        if (res.data) return false;
        else return true;
    },
};

export { Validator };