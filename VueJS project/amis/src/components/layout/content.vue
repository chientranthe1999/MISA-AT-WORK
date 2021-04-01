<template>
    <!-- Content -->
    <div class="content">
        <!-- Content top -->
        <div class="content__top">
            <h3 class="content__top-header">Quản lý lao động</h3>
            <div class="content__top-btn">
                <div class="btn-syn btn">Đồng bộ từ HRM</div>
                <div class="btn-add btn" @click="this.changeModalStatus">
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

                <tbody v-html="dataList"></tbody>
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

        <EmployeePopupAdd :modalStatus="this.modalStatus" :changeModalStatus="this.changeModalStatus" />
    </div>
    <!-- End content -->
</template>

<script>
    import { formatSalary, formatDate } from '../../helper/formatTable.js';
    import EmployeePopupAdd from '../popup/EmployeePopupAdd';
    export default {
        name: 'Content',

        data() {
            return {
                dataList: '',
                modalStatus: false,
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
            formatSalary,
            formatDate,

            /**
             * Hàm binding dữ liệu vào table
             * @version: 1.0
             * @author: Chiến Nobi (19/03/2021)
             */
            bindingDataToTable() {
                document.getElementsByTagName('tbody').value = '';
                var ths = document.querySelectorAll('th');
                var fieldname,
                    trs = '',
                    tds = '';
                this.dataBinding.forEach((item) => {
                    // reset tds for new row
                    tds = '';
                    ths.forEach((attr) => {
                        fieldname = attr.attributes[1].value;
                        switch (fieldname) {
                            case 'Address': {
                                tds += `<td style="max-width: 150px;">${item[fieldname]}</td>`;
                                break;
                            }
                            // format Date
                            case 'DateOfBirth': {
                                let phoneNumber = this.formatDate(item[fieldname]);
                                tds += `<td ">${phoneNumber}</td>`;
                                break;
                            }
                            // format Salary
                            case 'Salary': {
                                let salary = this.formatSalary(item[fieldname]);
                                tds += `<td style="text-align: right;">${salary}</td>`;
                                break;
                            }
                            default:
                                tds += `<td>${item[fieldname]}</td>`;
                                break;
                        }
                    });
                    trs += `<tr>${tds}</tr>`;
                });
                this.dataList = trs;
            },

            /**
             * Hàm chuyển trạng thái của Modal
             */
            changeModalStatus() {
                this.modalStatus = !this.modalStatus;
            },
        },

        // Run when props changed
        updated() {
            /**
             * Gán dữ liệu vào front end
             * Khi đang load dữ liệu thì bảng phải rỗng -> dataList = ""
             * Sau khi load xong dữ liệu từ API thì gọi hàm gán dữ liệu vào bảng
             */
            if (!this.isLoading) {
                this.bindingDataToTable();
            } else {
                this.dataList = '';
            }
        },

        components: {
            EmployeePopupAdd,
        },
    };
</script>

<style lang="scss" scoped>
    @import '../../style/layout/content.scss';
</style>
