<template>
    <div class="employee-popup" id="employee-popup" :class="{ active: modalStatus }">
        <BaseLoader :isShow="isShow" />
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
                                v-model="customer.CustomerCode"
                            />
                        </div>
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="fullName">Họ và tên (<span>*</span>)</p>
                            <input
                                class="input"
                                type="text"
                                id="fullName"
                                autocomplete="off"
                                v-model="customer.FullName"
                            />
                        </div>
                    </div>

                    <div class="flex-1 d-flex">
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="numberCode">Mã thẻ thành viên</p>
                            <input class="input" type="text" id="numberCode" v-model="customer.MemberCardCode" />
                        </div>
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="">Phân loại khách hàng (<span>*</span>)</p>
                            <BaseCombobox
                                :selectLists="selectLists"
                                comboboxPadding="0 0 0 20px"
                                comboboxWidth="100%"
                                fontSize="14px"
                            />
                        </div>
                    </div>

                    <div class="flex-1 d-flex">
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="dateOfBirth">Ngày sinh</p>
                            <input
                                class="input"
                                type="date"
                                id="dateOfBirth"
                                ref="dateOfBirth"
                                v-model="customer.DateOfBirth"
                            />
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
                            v-model="customer.Email"
                        />
                    </div>
                    <div class="flex-1 input-swaper">
                        <p class="input-title" for="">Số điện thoại (<span>*</span>)</p>
                        <input
                            class="input"
                            type="text"
                            placeholder=""
                            id="phoneNumber"
                            v-model="customer.PhoneNumber"
                        />
                    </div>
                </div>
                <div class="d-flex">
                    <div class="flex-2 input-swaper">
                        <p class="input-title" for="">Tên Công Ty</p>
                        <input class="input" type="text" placeholder="" />
                    </div>
                    <div class="flex-1 input-swaper">
                        <p class="input-title" for="">Mã số thuế</p>
                        <input
                            v-model="customer.CompanyTaxCode"
                            class="input"
                            type="text"
                            placeholder="Mã số thuế công ty"
                        />
                    </div>
                </div>
                <div class="flex-1 input-swaper">
                    <p class="input-title" for="">Địa chỉ</p>
                    <input v-model="customer.Address" class="input" type="text" placeholder="Địa chỉ" />
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

                // Cờ Update, Add
                formMode: 'add',
                // Ẩn hiện thanh loading
                isShow: false,
            };
        },

        // props
        props: {
            modalStatus: {
                type: Boolean,
                default: false,
            },
            customer: {
                type: Object,
                default() {
                    return {};
                },
            },
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
            /**
             * Validate CustomerCode
             * Không được empty
             * Không được phép trùng
             */
            validateCustomerCode(e) {
                var value = e.target.value;
                var parentNode = e.target.parentNode;
                var errorNode;

                // Kiểm tra rỗng lỗi
                if (Validator.validateEmpty(value)) {
                    // Xóa viền đỏ khi không rỗng
                    e.target.classList.remove('value-error');

                    // Kiểm tra customerCode đã tồn tại chưa
                    Validator.validateCustomerCode(value).then((res) => {
                        if (!res) {
                            errorNode = this.createErrorNode(ErrorMessage.duplicateCustomerCode);
                            parentNode.appendChild(errorNode);
                        }
                    });
                } else {
                    e.target.classList.add('value-error');
                    errorNode = this.createErrorNode(ErrorMessage.doNotEmpty('Mã khách hàng'));
                    parentNode.appendChild(errorNode);
                }
            },

            /**
             * Validate số điện thoại
             * Có 10 hoặc 11 số
             * Không được có chữ
             */

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
                e.target.classList.remove('value-error');
                var errorNode = parentNode.querySelector('.data-append');
                if (errorNode != null) {
                    parentNode.removeChild(errorNode);
                }
            },

            // Xóa thông báo lỗi khi đóng cửa sổ
            deleteErrorWhenClose() {
                this.$emit('closeModal');

                var errorNodes = document.querySelectorAll('.data-append');
                var inputs = document.querySelectorAll('input');
                // Xóa Node thông báo lỗi
                errorNodes.forEach((item) => {
                    item.remove();
                });

                // Xóa viền lỗi
                inputs.forEach((item) => {
                    item.classList.remove('value-error');
                });
            },

            // Thêm mới người dùng khi nhấn Save
            async createNewCustomer() {
                try {
                    this.isShow = true;
                    this.customer.CustomerGroupId = '19165ed7-212e-21c4-0428-030d4265475f';
                    var res = await axios.post('https://localhost:44388/api/v1/Customers', this.customer);
                    this.isShow = false;
                    // Nếu trả về 201 thì thông báo cho người dùng thêm thành công
                    if (res.status == 201) {
                        this.$emit('closeModal');
                        this.$emit('reload');
                    }
                } catch (error) {
                    console.log(error);
                }
            },
        },

        updated() {
            this.count++;
            // Mở lần đầu tiên thì focus vào input đầu tiên
            // Update lần đầu tiên khi gọi xong API getCustomerGroup
            // Update lần 2 khi modal status prop thay đổi
            if (this.count == 2) {
                document.querySelector('#customerCode').focus();
            }
            console.log(this.customer.DateOfBith);
        },

        created() {
            this.getCustomerGroup();
        },
    };
</script>

<style lang="scss">
    @import '../../style/layout/EmployeePopUpAdd';
</style>
