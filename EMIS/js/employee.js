/**
 * @author: Chiến Nobi (5/3/2021)
 */

$(document).ready(function () {
    new EmployeeJS();
});

/**
 * Class quản lý các sự kiện cho trang Employee
 * @author: Chiến Nobi (5/3/2021)
 */

class EmployeeJS extends BaseJS {
    constructor() {
        super();
        this.setGetDataUrl();
    }
    /**
     * Overide setGetDataUrl()
     */
    setGetDataUrl() {
        this.getDataUrl = "http://api.manhnv.net/api/employees";
    }
}
