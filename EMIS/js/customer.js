/**
 * @author: Chiến Nobi (8/3/2021)
 */

$(document).ready(function () {
    new CustomerJS();
});

/**
 * Class quản lý các sự kiện cho trang Customer
 * @author: Chiến Nobi (8/3/2021)
 */

class CustomerJS extends BaseJS {
    constructor() {
        super();
        this.setGetDataUrl();
    }
    /**
     * Overide setGetDataUrl()
     */
    setGetDataUrl() {
        this.getDataUrl = "http://api.manhnv.net/api/customers";
    }
}
