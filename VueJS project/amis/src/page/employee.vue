<template>
    <div>
        <Sidebar />
        <div class="right-swapper">
            <Header />
            <Content :dataBinding="this.employeeList" :isLoading="this.isLoading" :rowTitle="this.rowTitle" :reload="this.reload" />
        </div>
        <BaseDeleteWarning />
    </div>
</template>

<script>
    import Content from '../components/layout/Content';
    import Header from '../components/layout/Header';
    import Sidebar from '../components/layout/Sidebar';
    import BaseDeleteWarning from '../components/common/BaseDeleteWarning';
    import axios from 'axios';

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
        components: {
            Content,
            Header,
            Sidebar,
            BaseDeleteWarning,
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
                axios
                    .get('https://localhost:44388/api/v1/Customers')
                    .then((response) => {
                        this.employeeList = response.data;
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
