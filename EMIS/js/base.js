class BaseJS {
    constructor() {
        this.getDataUrl;
        this.setGetDataUrl();
        this.loadData();
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
                    var data,
                        fieldname,
                        trs = "",
                        tds = "";
                    $.each(response, (index, item) => {
                        // reset tds
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
}
