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
    $green: #019160;
    $hdark: #e5e5e5;
    .content {
        height: calc(100vh - 61px);
        width: 100%;
        padding: 0 20px;
        /*------------------ Content top ------------------*/
        &__top {
            $height: 80px;
            display: flex;
            justify-content: space-between;
            height: 80px;
            align-items: center;

            &-header {
                font-size: 25px;
            }

            &-btn {
                display: flex;

                .btn {
                    padding: 10px 15px;
                    font-size: 18px;
                }

                .btn-syn {
                    color: $green;
                    margin-right: 10px;
                }

                .btn-add {
                    background-color: $green;
                    color: white;

                    span:first-child {
                        margin-right: 3px;
                    }
                }
            }
        }

        /*------------------ Content middle ------------------*/
        &__middle {
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
            &-input {
                flex: 9;
                display: flex;
                flex-wrap: nowrap;

                .search-bar {
                    height: 40px;
                    border: 1px solid #bbbbbb;
                    padding: 10px 16px;
                    border-radius: 4px;
                    font-size: 16px;
                    margin-right: 20px;
                }

                .search-bar:focus {
                    border-color: $green;
                    outline: $green;
                }

                .search-name {
                    min-width: 370px;
                    flex: 2;
                    padding-left: 40px;
                    background-image: url('../../assets/icon/search-icon.png');
                    background-position: 10px;
                    background-repeat: no-repeat;
                    background-size: 20px;
                }

                .search-department {
                    width: 300px;
                    flex: 1.5;
                }

                .search-status {
                    flex: 1.5;
                }
            }

            &-btn {
                flex: 1;
                display: flex;
                justify-content: flex-end;
                .btn {
                    width: 40px;
                    height: 40px;
                    line-height: 30px;
                    text-align: center;
                }
                .btn-download {
                    margin-right: 10px;
                }
            }
        }

        /*------------------ Content main ------------------*/
        &__main {
            height: calc(100vh - 261px);
            overflow: auto;
            position: relative;
        }

        /*------------------ Content bottom ------------------*/
        &__bottom {
            height: 60px;
            display: flex;
            padding: 15px 15px 0 15px;

            .text-left {
                flex: 0.8;
            }

            .text-right {
                flex: 0.8;
                text-align: right;
            }

            .pagination-bar {
                flex: 1;
                text-align: center;
                min-width: 360px;

                > span {
                    display: inline-block;
                    cursor: pointer;
                }

                .pagination-number {
                    $hw: 30px;
                    width: $hw;
                    height: $hw;
                    border-radius: 50%;
                    background-color: #e5e5e5;
                    border: 1px solid #bbbbbb;
                    text-align: center;
                    line-height: $hw;
                    margin: 0 4px;
                }

                .pagination-number.active {
                    background-color: $green;
                    color: #fff;
                    font-weight: 600;
                }

                .move-btn {
                    font-size: 20px;
                    margin: 0 10px;
                }
            }
        }
    }
    // Loading icon CSS
    .loader {
        width: 300px;
        height: 300px;
        background-image: url(../../assets/icon/loading-icon.gif);
        background-size: cover;
        position: absolute;
        right: 50%;
        top: 50%;
        transform: translate(50%, -50%);
        display: none;
    }

    .active {
        display: block;
    }
</style>
