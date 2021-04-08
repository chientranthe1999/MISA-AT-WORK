<template>
    <div class="employee-popup" id="employee-popup" :class="{ active: modalStatus }">
        <div class="popup__content">
            <div id="close-btn" @click="deleteErrorWhenClose"><i class="fas fa-times"></i></div>
            <h3 class="popup__title">Thông tin khách hàng</h3>
            <!-- Popup top -->
            <div class="popup__content-top d-flex">
                <div class="customer-avt flex-1">
                    <div></div>
                    <p>Thêm ảnh ở đây nheeee....</p>
                </div>
                <div class="flex-2">
                    <div class="flex-1 d-flex">
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="customerCode">Mã khách hàng (<span>*</span>)</p>
                            <input
                                class="input"
                                type="text"
                                id="customerCode"
                                value-required
                                @blur="validateCustomerCode"
                                @focus="deleteErrorWhenFocus"
                                autocomplete="off"
                                v-model="Customer.CustomerCode"
                            />
                        </div>
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="fullName">Họ và tên (<span>*</span>)</p>
                            <input class="input" type="text" id="fullName" autocomplete="off" v-model="Customer.FullName" />
                        </div>
                    </div>

                    <div class="flex-1 d-flex">
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="numberCode">Mã thẻ thành viên</p>
                            <input class="input" type="text" id="numberCode" />
                        </div>
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="">Phân loại khách hàng (<span>*</span>)</p>
                            <BaseCombobox :selectLists="selectLists" comboboxPadding="0 0 0 20px" comboboxWidth="100%" fontSize="14px" />
                        </div>
                    </div>

                    <div class="flex-1 d-flex">
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="dateOfBirth">Ngày sinh</p>
                            <input class="input" type="date" id="dateOfBirth" v-model="Customer.DateOfBirth" />
                        </div>
                        <div class="flex-1 input-swaper input-gender">
                            <p class="input-title" for="">Giới tính (<span>*</span>)</p>
                            <div class="radio-swapper d-flex">
                                <BaseRatio value="1" name="gender" :isChecked="true">Nam</BaseRatio>
                                <BaseRatio value="0" name="gender">Nữ</BaseRatio>
                                <BaseRatio value="2" name="gender">Khác</BaseRatio>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Popup middle -->
            <div class="popup__content-middle">
                <div class="d-flex">
                    <div class="flex-2 input-swaper">
                        <p class="input-title" for="email">Email (<span>*</span>)</p>
                        <input
                            class="input"
                            type="text"
                            placeholder="example@domain.com"
                            id="email"
                            value-required
                            @blur="validateEmail"
                            @focus="deleteErrorWhenFocus"
                            ref="email"
                            v-model="Customer.Email"
                        />
                    </div>
                    <div class="flex-1 input-swaper">
                        <p class="input-title" for="">Số điện thoại (<span>*</span>)</p>
                        <input class="input" type="text" placeholder="" id="phoneNumber" v-model="Customer.PhoneNumber" />
                    </div>
                </div>
                <div class="d-flex">
                    <div class="flex-2 input-swaper">
                        <p class="input-title" for="">Tên Công Ty</p>
                        <input class="input" type="text" placeholder="" />
                    </div>
                    <div class="flex-1 input-swaper">
                        <p class="input-title" for="">Mã số thuế</p>
                        <input v-model="Customer.CompanyTaxCode" class="input" type="text" placeholder="Mã số thuế công ty" />
                    </div>
                </div>
                <div class="flex-1 input-swaper">
                    <p class="input-title" for="">Địa chỉ</p>
                    <input v-model="Customer.Address" class="input" type="text" placeholder="Địa chỉ" />
                </div>
            </div>

            <!-- Popup bottom -->
            <div class="popup__content-bottom d-flex">
                <div id="cancel-btn" class="btn">Hủy</div>
                <div id="delete-btn" class="btn" data-id="">Xóa</div>
                <div id="save-btn" class="btn d-flex" data-id="" @click="createNewCustomer">
                    <span><i class="far fa-save"></i></span> Save
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import BaseCombobox from '../common/BaseCombobox';
    import BaseRatio from '../common/BaseRatio';
    import { ErrorMessage } from '@/environment/message';
    import axios from 'axios';
    import { Validator } from '@/helper/validate';

    export default {
        name: 'EmployeePopupAdd',

        // data
        data() {
            return {
                selectLists: [],
                // Cờ validate
                hasError: false,

                // Cờ focus
                count: 0,

                // Đối tượng customer
                Customer: {
                    CustomerCode: '',
                    FullName: '',
                    DateOfBirth: '',
                    Gender: 1,
                    Address: '',
                    CustomerGroupId: '3631011e-4559-4ad8-b0ad-cb989f2177da',
                    CompanyName: '',
                    CompanyTaxCode: '',
                    PhoneNumber: '',
                    Email: '',
                    CreatedDate: '',
                },
            };
        },

        // props
        props: {
            modalStatus: {
                type: Boolean,
                default: false,
            },

            changeModalStatus: Function,
        },

        components: {
            BaseCombobox,
            BaseRatio,
        },

        methods: {
            // /**
            //  * Kiểm tra xem trường dữ liệu có trống ko
            //  * @param {Object} selectedDom: item
            //  * @author: Chiến Nobi 07/04/2021
            //  */
            // checkEmpty(selectedDom) {
            //     var mustRequired = selectedDom.hasAttribute('value-required');
            //     if (selectedDom.value == '' && mustRequired) {
            //         selectedDom.classList.add('value-error');
            //     } else selectedDom.classList.remove('value-error');
            // },

            /**
             * Lấy danh sách nhóm khách hàng
             */
            async getCustomerGroup() {
                var response = [];
                var res = await axios.get('https://localhost:44388/api/v1/CustomerGroups');

                res.data.forEach((element) => {
                    response.push({ key: element.CustomerGroupId, value: element.CustomerGroupName });
                });

                this.selectLists = [...response];
            },

            test() {
                console.log(this.Customer);
            },

            /**
             * Validate Email
             */
            validateEmail(e) {
                var value = e.target.value;
                var parentNode = e.target.parentNode;
                var errorNode;
                // Kiểm tra email có rỗng không
                // Nếu không rỗng, kiểm tra định dạnh Email

                if (Validator.validateEmpty(value)) {
                    // Xóa viền đỏ khi không rỗng
                    e.target.classList.remove('value-error');
                    // Kiểm tra định dạng email
                    if (!Validator.validateEmailFormat(value)) {
                        errorNode = this.createErrorNode(ErrorMessage.errorEmailFormat);
                        parentNode.appendChild(errorNode);
                    }
                } else {
                    e.target.classList.add('value-error');
                    errorNode = this.createErrorNode(ErrorMessage.doNotEmpty('Email'));
                    parentNode.appendChild(errorNode);
                }
            },

            validateCustomerCode(e) {
                var value = e.target.value;
                var parentNode = e.target.parentNode;
                var errorNode;

                // Kiểm tra rỗng lỗi
                if (Validator.validateEmpty(value)) {
                    // Xóa viền đỏ khi không rỗng
                    e.target.classList.remove('value-error');

                    // // Kiểm tra customerCode đã tồn tại chưa
                    // if (!Validator.validateEmailFormat(value)) {
                    //     errorNode = this.createErrorNode(ErrorMessage.errorEmailFormat);
                    //     parentNode.appendChild(errorNode);
                    // }
                } else {
                    e.target.classList.add('value-error');
                    errorNode = this.createErrorNode(ErrorMessage.doNotEmpty('Mã khách hàng'));
                    parentNode.appendChild(errorNode);
                }
            },

            // helper _methods
            /**
             * Tạo ra thông báo lỗi
             */
            createErrorNode(msg) {
                var errorNode = document.createElement('div');
                errorNode.className = 'data-append';
                errorNode.innerHTML = msg;
                return errorNode;
            },

            // Xóa thông báo lỗi khi focus
            deleteErrorWhenFocus(e) {
                var parentNode = e.target.parentNode;

                var errorNode = parentNode.querySelector('.data-append');
                if (errorNode != null) {
                    parentNode.removeChild(errorNode);
                }
            },

            deleteErrorWhenClose() {
                this.changeModalStatus();
                var errorNodes = document.querySelectorAll('.data-append');
                var inputs = document.querySelectorAll('input');
                errorNodes.forEach((item) => {
                    item.remove();
                });

                inputs.forEach((item) => {
                    item.classList.remove('value-error');
                });
            },

            async createNewCustomer() {
                try {
                    var body = {
                        CustomerCode: this.Customer.CustomerCode,
                        CustomerGroupId: this.Customer.CustomerGroupId,
                        PhoneNumber: this.Customer.PhoneNumber,
                        FullName: this.Customer.FullName,
                        Email: this.Customer.Email,
                    };
                    var res = await axios.post('https://localhost:44388/api/v1/Customers', body);
                    console.log(res);
                } catch (error) {
                    console.log(error);
                }
            },
        },

        updated() {
            this.firstOpen++;
            if (this.count == 1) {
                document.querySelector('#customerCode').focus();
            }
            // if (this.modalStatus) {
            //     var inputs = document.querySelectorAll('input[type="text"]');
            //     inputs.forEach((item) => item.addEventListener('blur', () => this.checkEmpty(item)));
            // }
        },
        // destroyed() {
        //     var inputs = document.querySelectorAll('input[type="text"]');

        //     // remove event listener
        //     inputs.forEach((item) => item.removeEventListener('blur', () => this.checkEmpty(item)));
        // },

        created() {
            this.getCustomerGroup();
        },
    };
</script>

<style lang="scss">
    @import '../../style/layout/EmployeePopUpAdd';
</style>
