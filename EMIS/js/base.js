class BaseJS {
    constructor() {
        this.getDataUrl;
        this.setGetDataUrl();
        this.loadData();
        this.initEvent();
    }

    /**
     * Funtion to set URL for getting data from API
     */

    setGetDataUrl() {}

    /**
     * Funtion lấy dữ liệu từ API và bind vào Frontend
     * @author: Chiến Nobi (5/3/2021)
     */
    loadData() {
        try {
            // Làm rỗng bảng
            $("table tbody").html("");
            // Ẩn loading khi load xong dữ liệu
            $(document).ajaxComplete(() => {
                $(".loader").css("display", "none");
            });

            // Hiện loading khi đang load dữ liệu
            $(document).ajaxStart(() => {
                $(".loader").css("display", "block");
            });
            var ths = $("th");

            // Lấy dữ liệu từ API và bind vào frontend
            $.ajax({
                type: "GET",
                url: this.getDataUrl,
                success: function (response) {
                    var fieldname,
                        trs = "",
                        tds = "",
                        idProp = Object.keys(response[0])[0];

                    $.each(response, (index, item) => {
                        /**
                         * trs lưu trữ các dòng tr
                         * tds lưu trữ các td của 1 tr
                         * Cộng hết các chuỗi với sau đó gán vào bảng
                         */
                        tds = "";
                        $.each(ths, (key, value) => {
                            fieldname = $(value).attr("fieldname");
                            switch (fieldname) {
                                case "Address":
                                    tds += `<td style="max-width: 150px;">${item[fieldname]}</td>`;
                                    break;
                                case "DateOfBirth":
                                    let phoneNumber = formatDate(
                                        item[fieldname]
                                    );
                                    tds += `<td ">${phoneNumber}</td>`;
                                    break;
                                case "Salary":
                                    let salary = formatSalary(item[fieldname]);
                                    tds += `<td style="text-align: right;">${salary}</td>`;
                                    break;
                                default:
                                    tds += `<td>${item[fieldname]}</td>`;
                                    break;
                            }
                        });
                        //Tạo ra các tr
                        trs += `<tr data-id="${item[idProp]}">${tds}</tr>`;
                    });
                    $("table tbody").append(trs);
                },
                error: function (error) {
                    console.log(error);
                },
            });
        } catch (e) {
            console.log(e);
        }
    }

    /**
     * Funtion để reload lại dữ liệu gửi về từ api
     * @author: Chiến Nobi (12/3/2021)
     */

    initEvent() {
        try {
            var me = this;
            /**
             * Load lại dữ liệu khi bấm nút reload
             */
            $(".btn-reload").click(function () {
                me.loadData();
            });

            /**
             * Đóng modal khi ấn nút close
             */
            $("#close-btn").click(() => {
                $("#employee-popup").hide();
                // reset toàn bộ ô input
                $("#customerCode").val("");
                $("#fullName").val("");
                $("#dateOfBirth").val("");
                $("#email").val("");
                $("#phoneNumber").val("");
                $('input[name="gender"]').val("");
                $("#customerType").val("");
                // Chỉ hiện nút delete khi vào chế độ sửa
                $("#delete-btn").hide();
            });

            /**
             * Hiện modal thêm khi nhấn nút thêm nhân viên / thêm khách hàng
             */
            $("#show-modal").click(() => {
                $("#employee-popup").show();
            });

            /**
             * Lưu lại dữ liệu khi ấn nút save
             */
            $("#save-btn").click(() => {
                if ($("#save-btn").attr("data-id") == "") {
                    console.log("lalal");
                    this.addNewData();
                } else {
                    this.editData();
                }
            });

            /**
             * Sự kiện ấn vào các row để sửa và xóa
             */

            $("tbody").on("dblclick", "tr", function () {
                /**
                 * Hàm sửa dữ liệu
                 * hàm click() ko gắn với các element động -> dùng hàm on()
                 * Khi dblclick vào 1 row -> cho phép sửa nội dung của row đó
                 * dblclick -> mở modal -> sử dụng id -> gọi ajax để lấy thông tin nhân viên -> điền vào chỗ trống -> thêm các id vào nút sửa và xóa
                 * Khi đóng thì reset dữ liệu của tất cả các trường
                 * @version: 1.0
                 * @author: Chiến Nobi (17/3/2021)
                 */
                var deleteBtn = $("#delete-btn");
                $(deleteBtn).show();
                var dataId = $(this).attr("data-id");
                var inputObject = {
                    CustomerCode: $("#customerCode"),
                    FullName: $("#fullName"),
                    DateOfBirth: $("#dateOfBirth"),
                    Email: $("#email"),
                    PhoneNumber: $("#phoneNumber"),
                };
                $.ajax({
                    // tạo ra đường dẫn
                    url: me.getDataUrl + "/" + dataId,
                    method: "GET",
                    success: (response) => {
                        $("#save-btn").attr("data-id", response.CustomerId);
                        $(deleteBtn).attr("data-id", response.CustomerId);
                        /**
                         * format dữ liệu ngày sinh để bind vào trường input
                         * Value của trường input type=date có dạng yyyy-mm-dd
                         */
                        var dateTime = new Date(response.DateOfBirth);
                        let year = dateTime.getFullYear();
                        let month = dateTime.getMonth() + 1;
                        // Định dạng month theo kiểu mm
                        month = month < 10 ? "0" + month : month;
                        let date = dateTime.getDate();
                        // Định dáng date theo kiểu dd
                        date = date < 10 ? "0" + date : date;
                        response.DateOfBirth = year + "-" + month + "-" + date;

                        // binding 1 số trường dữ liệu ko cần chuyển đổi
                        $.each(inputObject, (key, item) => {
                            $(item).val(response[key]);
                        });

                        // Binding dữ liệu trường giới tính
                        if (response.Gender == null || response.Gender == "3") {
                            $('input[value="3"]').prop("checked", true);
                        } else
                            $(`input[value=${response.Gender}]`).prop(
                                "checked",
                                true
                            );

                        // binding dữ liệu vào trường nhóm khách hàng
                        $(
                            `#customerType option[value=${response.CusTomerGroupName}]`
                        ).prop("selected", true);
                        // Mở popup
                        $("#employee-popup").show();
                    },
                    error: function (e) {
                        console.log(e);
                    },
                });
            });

            $("#delete-btn").click(() => {
                $.ajax({
                    method: "DELETE",
                    url:
                        this.getDataUrl +
                        "/" +
                        $("#delete-btn").attr("data-id"),
                    success: function (response) {
                        alert("delete done");
                        $("#employee-popup").hide();
                        me.loadData();
                    },
                });
            });
        } catch (e) {
            console.log(e);
        }
    }

    /**
     * Hàm tạo ra người dùng mới
     * @version: 1.0
     * @author: Chiến Nobi (15/3/2021)
     */

    addNewData() {
        var me = this;
        var sendForm = {
            CustomerCode: $("#customerCode").val(),
            FullName: $("#fullName").val(),
            DateOfBirth: $("#dateOfBirth").val(),
            Email: $("#email").val(),
            PhoneNumber: $("#phoneNumber").val(),
            Gender: $('input[name="gender"]').val(),
            CustomerType: $("#customerType").val(),
        };
        this.validateForm(sendForm);

        /**
         * Gửi dữ liệu lên server
         */
        $.ajax({
            type: "POST",
            url: this.getDataUrl,
            data: JSON.stringify(sendForm),
            contentType: "application/json",
            /**
             * Nhận dữ liệu thành công -> thông báo load dữ liệu thành công
             * Load lại dữ liệu
             */
            success: function () {
                alert("add done");
                $("#employee-popup").hide();
                me.loadData();
            },

            error: function () {},
        });
    }

    /**
     * Hàm validate dữ liệu của form
     * @param {*} data dữ liệu đầu vào: là giá trị của ô input
     * @returns
     * @author: Chiến Nobi (15/3/2021)
     */

    validateForm(data) {
        if (data.FullName == "") {
            alert("Họ và tên không được để trống");
            $("#customerCode").focus();
        }
        return true;
    }

    /**
     * Hàm sửa và gửi dữ liệu sửa lên server
     */
    editData() {
        var me = this;
        var sendForm = {
            CustomerCode: $("#customerCode").val(),
            FullName: $("#fullName").val(),
            DateOfBirth: $("#dateOfBirth").val(),
            Email: $("#email").val(),
            PhoneNumber: $("#phoneNumber").val(),
            Gender: $('input[name="gender"]').val(),
            CustomerType: $("#customerType").val(),
            CustomerId: $("#save-btn").attr("data-id"),
        };
        // this.validateForm(sendForm);

        /**
         * Gửi dữ liệu lên server
         */
        $.ajax({
            type: "PUT",
            url: this.getDataUrl + "/" + $("#save-btn").attr("data-id"),
            data: JSON.stringify(sendForm),
            contentType: "application/json",
            /**
             * Nhận dữ liệu thành công -> thông báo load dữ liệu thành công
             * Load lại dữ liệu
             */
            success: function () {
                alert("Sửa thành công");
                $("#employee-popup").hide();
                me.loadData();
            },

            error: function () {},
        });
    }
}
