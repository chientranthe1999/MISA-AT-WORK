<template>
    <!-- Content -->
    <div class="content">
        <!-- Content top -->
        <div class="content__top">
            <h3 class="content__top-header">Quản lý lao động</h3>
            <div class="content__top-btn">
                <div class="btn-syn btn">Đồng bộ từ HRM</div>
                <div class="btn-add btn" @click="showModal">
                    <span><i class="fas fa-user-plus"></i></span>
                    <span>Thêm lao động</span>
                </div>
            </div>
        </div>
        <!-- Content middle -->
        <div class="content__middle">
            <div class="content__middle-input">
                <input class="search-name search-bar" placeholder="Tìm kiếm theo mã nhân viên, họ tên" />
                <input class="search-department search-bar" placeholder="Chọn bộ phận phòng ban" />
                <input class="search-status search-bar" placeholder="Trạng thái tham gia bảo hiểm xã hội" />
            </div>

            <div class="content__middle-btn">
                <div class="btn-download btn">
                    <i class="fas fa-download"></i>
                </div>
                <div class="btn-reload btn" @click="this.reload">
                    <i class="fas fa-sync-alt"></i>
                </div>
            </div>
        </div>

        <!-- Content main -->
        <div class="content__main">
            <div class="loader" :class="{ active: isLoading }"></div>
            <!-- Table -->
            <table>
                <thead class="fixed-header">
                    <tr>
                        <th v-for="item in rowTitle" :key="item.titleCode" :fieldname="item.titleCode">
                            {{ item.title }}
                        </th>
                    </tr>
                </thead>

                <tbody>
                    <tr
                        v-for="customer in dataBinding"
                        :key="customer.CustomerId"
                        @dblclick="trOnClick(customer.CustomerId)"
                    >
                        <td>{{ customer.CustomerCode }}</td>
                        <td>{{ customer.FullName }}</td>
                        <td>{{ customer.Gender }}</td>
                        <td>{{ customer.Email }}</td>
                        <td>{{ customer.PhoneNumber }}</td>
                        <td>{{ formatDate(customer.DateOfBirth) }}</td>
                        <td style="max-width: 250px;">{{ customer.Address }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <!-- Content bottom -->
        <div class="content__bottom">
            <div class="text-left">Hiển thị <b>1-10/1000</b> nhân viên</div>
            <div class="pagination-bar">
                <span class="first-page move-btn"><i class="fas fa-angle-double-left"></i></span>
                <span class="pre-page move-btn"><i class="fas fa-angle-left"></i></span>

                <span class="pagination-number active">1</span>
                <span class="pagination-number">2</span>
                <span class="pagination-number">3</span>
                <span class="pagination-number">4</span>
                <span class="pagination-number">5</span>
                <span class="pagination-number">6</span>

                <span class="next-page move-btn"><i class="fas fa-angle-right"></i></span>
                <span class="last-page move-btn"><i class="fas fa-angle-double-right"></i></span>
            </div>
            <div class="text-right"><b>10</b> nhân viên/trang</div>
        </div>

        <EmployeePopupAdd
            :modalStatus="modalStatus"
            :customer="selectedCustomer"
            @closeModal="hideModal"
            @reload="reload"
        />
    </div>
    <!-- End content -->
</template>

<script>
    import { formatDate } from '@/helper/formatTable.js';
    import EmployeePopupAdd from '../popup/EmployeePopupAdd';
    import { customerApi } from '@/api/customerApi';

    export default {
        name: 'Content',

        data() {
            return {
                dataList: '',
                modalStatus: false,
                selectedCustomer: {},
            };
        },

        props: {
            dataBinding: Array,
            rowTitle: Array,
            isLoading: Boolean,
            reload: Function,
        },

        methods: {
            /**
             * Các hàm helper
             */
            formatDate,

            /**
             * Ẩn modal thêm khách hàng
             */
            hideModal() {
                this.modalStatus = false;
                this.selectedCustomer = {};
            },

            /**
             * Hiển thị modal Thêm khách hàng
             */
            showModal() {
                this.modalStatus = true;
            },

            /**
             * Khi click vào tr -> Hiển thị thông tin chi tiết khách hàng
             */
            trOnClick(customerId) {
                customerApi
                    .getCustomerById(customerId)
                    .then((res) => {
                        this.selectedCustomer = res.data;
                        this.showModal();
                    })
                    .catch((e) => {
                        console.log(e);
                    });
            },
        },
        components: {
            EmployeePopupAdd,
        },
    };
</script>

<style lang="scss" scoped>
    @import '../../style/layout/content.scss';
</style>
