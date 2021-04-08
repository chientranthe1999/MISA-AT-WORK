const ErrorMessage = {
    // Lỗi không được để trống
    doNotEmpty: (title) => {
        return `${title} không được để trống`;
    },

    // Email không đúng định dạng
    errorEmailFormat: 'Email không đúng định dạng',

    // Sai định dạng số điệnt thoại
    errorPhoneNumberFormat: 'Sai định dạng số điện thoại'
}

export { ErrorMessage };