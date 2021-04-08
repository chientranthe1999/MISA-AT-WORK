import axios from "axios";

// eslint-disable-next-line no-unused-vars
var baseUrl = 'https://localhost:44388/api/v1/';

const getCustomers = async () => {
    var res = await axios.get(baseUrl + 'Customers');
    return res.data;
}

const checkExistCustomerCode = async (customerCode) => {
    var url = `${baseUrl}/Customers/${customerCode}`;
    var res = await axios.get(url);
    if (res.data == 1) {
        return true
    }
    else return false;
}

export {
    getCustomers,
    checkExistCustomerCode
}