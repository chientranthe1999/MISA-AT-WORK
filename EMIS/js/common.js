/**
 * Funtion định dạng ngày tháng theo kiểu mm/dd/yyyy
 * @param {any} date bất kì dữ liệu gì
 * @author: Chiến Nobi (5/3/2021)
 */
function formatDate(date) {
    try {
        let dateObject = new Date(date);
        // Kiểm tra isValid Day
        if (!Number.isNaN(dateObject.getTime)) {
            let day = dateObject.getDate(),
                month = dateObject.getMonth() + 1,
                year = dateObject.getFullYear();

            // Adding number 0 to the day and month has one letter
            day = day < 10 ? "0" + day : day;
            month = month < 10 ? "0" + month : month;
            return day + "/" + month + "/" + year;
        } else return "";
    } catch (e) {
        console.log(e);
    }
}

/**
 * Function định dạng hiển thị tiền lương
 * @param {Number} salary số tiền
 * @author: Chiến Nobi (5/3/2021)
 */

function formatSalary(salary) {
    try {
        if (Number.isInteger(salary)) {
            return salary.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
        }
        return "";
    } catch (e) {
        console.log(e);
    }
}

/**
 * Hàm validate dữ liệu của form
 * @param {*} data dữ liệu đầu vào: là giá trị của ô input có các trường như sau: FullName, Email, PhoneNumber, FullName
 * @version: 1.1
 * @author: Chiến Nobi (17/3/2021)
 */

function validateForm(data) {
    if (data.FullName == "") {
        alert("Họ và tên không được để trống");
        $("#customerCode").addClass("error");
        $("#customerCode").focus();
    }
    return true;
}
