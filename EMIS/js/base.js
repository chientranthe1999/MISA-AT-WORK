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
                        tds = "";
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
                        trs += `<tr>${tds}</tr>`;
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
                $("table tbody").html("");
                me.loadData();
            });

            /**
             * Đóng modal khi ấn nút close
             */
            $("#close-modal").click(() => {
                $("#employee-popup").hide();
            });

            /**
             * Hiện modal khi nhấn nút thêm nhân viên / thêm khách hàng
             */
            $("#show-modal").click(() => {
                $("#employee-popup").show();
            });

            /**
             *
             */
            $("#save-btn").click(() => {
                console.log("hihi");
                this.getDataForm();
            });
        } catch (e) {
            console.log(e);
        }
    }

    getDataForm() {
        var me = this;
        var sendForm = {
            CustomerCode: $("#customerCode").val(),
            FullName: $("#fullName").val(),
            DateOfBirth: $("#dateOfBirth").val(),
            Email: $("#email").val(),
            PhoneNumber: $("#phoneNumber").val(),
            // Gender: $('input[name="gender"]').val(),
            CustomerType: $("#customerType").val(),
        };
        this.validateForm(sendForm);
        debugger;
        $.ajax({
            type: "POST",
            url: this.getDataUrl,
            data: JSON.stringify(sendForm),
            contentType: "application/json",
            // xhrFields: {
            //     withCredentials: true,
            // },
            // headers: {
            //     "Access-Control-Allow-Origin": "*",
            // },
            success: function () {
                alert("add done");
                $("#employee-popup").hide();
                me.loadData();
            },

            error: function () {},
        });
    }

    validateForm(data) {
        if (data.FullName == "") {
            alert("Họ và tên không được để trống");
        }
        return true;
    }
}
