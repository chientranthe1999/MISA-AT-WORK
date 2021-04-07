<template>
    <div class="employee-popup" id="employee-popup" :class="{ active: modalStatus }">
        <div class="popup__content">
            <div id="close-btn" @click="this.changeModalStatus"><i class="fas fa-times"></i></div>
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
                            <input class="input" type="text" id="customerCode" value-required />
                        </div>
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="fullName">Họ và tên (<span>*</span>)</p>
                            <input class="input" type="text" id="fullName" value-required />
                        </div>
                    </div>

                    <div class="flex-1 d-flex">
                        <div class="flex-1 input-swaper">
                            <p class="input-title" for="numberCode">Mã thẻ thành viên (<span>*</span>)</p>
                            <input class="input" type="text" id="numberCode" />
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
                            <input class="input" type="date" id="dateOfBirth" />
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
                            @focus="deleteError"
                        />
                    </div>
                    <div class="flex-1 input-swaper">
                        <p class="input-title" for="">Số điện thoại (<span>*</span>)</p>
                        <input class="input" type="text" placeholder="" id="phoneNumber" value-required />
                    </div>
                </div>
                <div class="d-flex">
                    <div class="flex-2 input-swaper">
                        <p class="input-title" for="">Tên Công Ty</p>
                        <input class="input" type="text" placeholder="" />
                    </div>
                    <div class="flex-1 input-swaper">
                        <p class="input-title" for="">Mã số thuế</p>
                        <input class="input" type="text" placeholder="Mã số thuế công ty" />
                    </div>
                </div>
                <div class="flex-1 input-swaper">
                    <p class="input-title" for="">Địa chỉ</p>
                    <input class="input" type="text" placeholder="Địa chỉ" />
                </div>
            </div>

            <!-- Popup bottom -->
            <div class="popup__content-bottom d-flex">
                <div id="cancel-btn" class="btn">Hủy</div>
                <div id="delete-btn" class="btn" data-id="">Xóa</div>
                <div id="save-btn" class="btn d-flex" data-id="">
                    <span><i class="far fa-save"></i></span> Save
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import BaseCombobox from '../common/BaseCombobox';
    import BaseRatio from '../common/BaseRatio';
    import axios from 'axios';
    import { validateEmailFormat, validateEmpty } from '../../helper/validate';

    export default {
        name: 'EmployeePopupAdd',

        // data
        data() {
            return {
                selectLists: [],
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

            /**
             * Validate Email
             */
            validateEmail(e) {
                var value = e.target.value;
                var parentNode = e.target.parentNode;
                if (validateEmailFormat(value) && validateEmpty(value)) {
                    e.target.classList.remove('value-error');
                    parentNode.removeChild(parentNode.lastChild);
                } else {
                    e.target.classList.add('value-error');
                    var errorNode = document.createElement('div');
                    errorNode.className = 'data-append';
                    errorNode.innerHTML = 'Dữ liệu không được để trống';
                    parentNode.appendChild(errorNode);
                    console.log(errorNode);
                }
            },

            deleteError(e) {
                var parentNode = e.target.parentNode;
                var errorNode = document.querySelector('.data-append');
                if (errorNode != null) {
                    parentNode.removeChild(errorNode);
                }
                console.log(errorNode);
            },
        },

        updated() {
            document.querySelector('#customerCode').focus();
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
