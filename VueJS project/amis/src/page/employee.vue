<template>
    <div>
        <Sidebar />
        <div class="right-swapper">
            <Header />
            <Content :dataBinding="this.employeeList" :isLoading="this.isLoading" :rowTitle="this.rowTitle" :reload="this.reload" />
        </div>
    </div>
</template>

<script>
    import Content from '../components/layout/Content';
    import Header from '../components/layout/Header';
    import Sidebar from '../components/layout/Sidebar';
    import axios from 'axios';

    export default {
        name: 'Employee',
        data() {
            return {
                employeeList: [],

                isLoading: true,

                rowTitle: [
                    { titleCode: 'EmployeeCode', title: 'Mã Nhân Viên' },
                    { titleCode: 'FullName', title: 'Họ tên' },
                    { titleCode: 'GenderName', title: 'Giới tính' },
                    { titleCode: 'Email', title: 'Email' },
                    { titleCode: 'PhoneNumber', title: 'Số điện thoại' },
                    { titleCode: 'DateOfBirth', title: 'Ngày sinh' },
                    { titleCode: 'DepartmentName', title: 'Bộ phận/phòng ban' },
                    { titleCode: 'Salary', title: 'Lương' },
                    { titleCode: 'WorkStatusName', title: 'Trạng thái' },
                    { titleCode: 'Address', title: 'Địa chỉ' },
                ],

                selectList: [
                    { key: 1, value: 'Mecerdes' },
                    { key: 2, value: 'Ferari' },
                    { key: 3, value: 'Lamborghini' },
                    { key: 4, value: 'Xe máy' },
                    { key: 5, value: 'Xe đạp' },
                ],
            };
        },
        components: {
            Content,
            Header,
            Sidebar,
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
             * Lấy dữ liệu từ api sau đó bind vào frontend
             */

            getData() {
                axios
                    .get('http://api.manhnv.net/api/employees')
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
