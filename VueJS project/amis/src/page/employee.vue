<template>
    <div>
        <Sidebar />
        <div class="right-swapper">
            <Header />
            <Content
                :dataBinding="this.employeeList"
                :isLoading="this.isLoading"
                :rowTitle="this.rowTitle"
                :reload="this.reload"
            />
        </div>
        <BaseSuccessMessage />
    </div>
</template>

<script>
    import { customerApi } from '@/api/customerApi';

    export default {
        name: 'Employee',
        data() {
            return {
                employeeList: [],

                isLoading: true,

                rowTitle: [
                    { titleCode: 'CustomerCode', title: 'Mã khách hàng' },
                    { titleCode: 'FullName', title: 'Họ tên' },
                    { titleCode: 'Gender', title: 'Giới tính' },
                    { titleCode: 'Email', title: 'Email' },
                    { titleCode: 'PhoneNumber', title: 'Số điện thoại' },
                    { titleCode: 'DateOfBirth', title: 'Ngày sinh' },
                    { titleCode: 'Address', title: 'Địa chỉ' },
                ],
            };
        },

        // Lấy dữ liệu khi component được tạo thành công (render ra DOM ảo)
        created() {
            this.getData();
        },

        methods: {
            /**
             * Reload lại dữ liệu khi nhấn nút reload
             * @version: 1.0
             * @author: Chiến Nobi
             */
            reload() {
                this.employeeList = [];
                this.isLoading = true;
                this.getData();
            },

            /**
             * Lấy dữ liệu từ api
             */
            getData() {
                customerApi
                    .getCustomers()
                    .then((res) => {
                        this.employeeList = res.data;
                        this.isLoading = false;
                    })
                    .catch((e) => {
                        console.log(e);
                    });
            },
        },
    };
</script>

<style lang="scss">
    .right-swapper {
        float: left;
        width: calc(100% - 221px);
    }
</style>
