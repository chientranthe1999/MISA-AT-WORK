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
                            <BaseCombobox :selectLists="selectLists" :comboboxPadding="comboboxPadding" comboboxWidth="100%" :fontSize="fontSize" />
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
                    <div class="flex-2">
                        <p class="input-title" for="email">Email (<span>*</span>)</p>
                        <input class="input" type="text" placeholder="example@domain.com" id="email" />
                    </div>
                    <div class="flex-1">
                        <p class="input-title" for="">Số điện thoại (<span>*</span>)</p>
                        <input class="input" type="text" placeholder="" id="phoneNumber" value-required />
                    </div>
                </div>
                <div class="d-flex">
                    <div class="flex-2">
                        <p class="input-title" for="">Tên Công Ty</p>
                        <input class="input" type="text" placeholder="" />
                    </div>
                    <div class="flex-1">
                        <p class="input-title" for="">Mã số thuế</p>
                        <input class="input" type="text" placeholder="Mã số thuế công ty" />
                    </div>
                </div>
                <div class="flex-1">
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

    export default {
        name: 'EmployeePopupAdd',

        // data
        data() {
            return {
                selectLists: [
                    { key: 1, value: 'Nhóm khách hàng MISA' },
                    { key: 2, value: 'Khách VIP' },
                ],

                comboboxPadding: '0 0 0 20px',

                fontSize: '14px',
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

        mounted() {},

        methods: {
            /**
             *
             * @param {Object} selectedDom: element
             * @
             */
            checkEmpty(selectedDom) {
                var mustRequired = selectedDom.hasAttribute('value-required');
                if (selectedDom.value == '' && mustRequired) {
                    selectedDom.classList.add('value-error');
                } else selectedDom.classList.remove('value-error');
            },
        },

        updated() {
            document.querySelector('#customerCode').focus();
            if (this.modalStatus) {
                var inputs = document.querySelectorAll('input[type="text"]');
                inputs.forEach((item) => item.addEventListener('blur', () => this.checkEmpty(item)));
                // inputs.forEach((item) =>
                //     item.addEventListener('blur', () => {
                //         var mustRequired = item.hasAttribute('value-required');
                //         if (item.value == '' && mustRequired) {
                //             item.classList.add('value-error');
                //         } else item.classList.remove('value-error');
                //     })
                // );
            }
        },
        destroyed() {
            var inputs = document.querySelectorAll('input[type="text"]');

            // remove event listener
            inputs.forEach((element) => element.removeEventListener('blur', this.checkEmpty(element)));
        },
    };
</script>

<style scoped lang="scss">
    @import '../../style/layout/EmployeePopUpAdd';
</style>
