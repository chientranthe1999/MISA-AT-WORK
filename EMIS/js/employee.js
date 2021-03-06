/**
 * Author: Chiến Nobi (5/3/2021)
 */

$(document).ready(function () {
    new EmployeeJS();
});

/**
 * Class quản lý các sự kiện cho trang Employee
 * Author: Chiến Nobi (3/5/2021)
 */

class EmployeeJS {
    constructor() {
        this.loadData();
    }

    /**
     * Funtion lấy dữ liệu từ API và bind vào Frontend
     * Author: Chiến Nobi (5/3/2021)
     */

    loadData() {
        try {
            // Ẩn loading khi load xong dữ liệu
            $(document).ajaxComplete(() => {
                $(".loader").css("display", "none");
            });

            // Hiện loading khi đang load dữ liệu
            $(document).ajaxStart(() => {
                $(".loader").css("display", "block");
            });

            // Lấy dữ liệu từ API và bind vào frontend
            $.ajax({
                type: "GET",
                url: "http://api.manhnv.net/api/employees",
                success: function (response) {
                    var data;
                    $.each(response, (index, item) => {
                        data = $(`<tr>
                        <td fieldname="">${index + 1}</td>
                        <td fieldname="EmployeeCode">${item.EmployeeCode}</td>
                        <td fieldname="FullName">${item.FullName}</td>
                        <td fieldname="GenderName">${item.GenderName}</td>
                        <td fieldname="Email">${item.Email}</td>
                        <td fieldname="PhoneNumber">${item.PhoneNumber}</td>
                        <td fieldname="DateOfBirth" class="text-align-center">${formatDate(
                            item.DateOfBirth
                        )}</td>
                        <td fieldname="DepartmentName">${item.DepartmentName
                            }</td>
                        <td fieldname="Salary" class="text-align-right">${formatSalary(
                                item.Salary
                            )}</td>
                        <td fieldname="WorkStatusName">${item.WorkStatusName
                            }</td>
                        <td fieldname="Address" style="max-width: 150px;">${item.Address
                            }</td>
                    </tr>`);
                        $("table tbody").append(data);
                    });
                },
                error: function (error) {
                    alert(error);
                },
            });
        } catch (e) {
            console.log(e);
        }
    }
}

/**
 * Format dữ liệu -> ngày/tháng/năm
 * @param {any} date bất kì dữ liệu gì
 * Author: Chiến Nobi (5/3/2021)
 */
function formatDate(date) {
    let dateObject = new Date(date);
    // Kiểm tra isValid Day
    if (!Number.isNaN(dateObject.getTime)) {
        let day = dateObject.getDate(),
            month = dateObject.getMonth() + 1,
            year = dateObject.getFullYear();

        day = day < 10 ? "0" + day : day;
        month = month < 10 ? "0" + month : month;
        return day + "/" + month + "/" + year;
    } else return "";
}

/**
 * Function định dạng hiển thị tiền lương
 * @param {Number} salary số tiền
 * Author: Chiến Nobi (5/3/2021)
 */

function formatSalary(salary) {
    if (Number.isInteger(salary)) {
        return salary.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
    }
    return "";
}
