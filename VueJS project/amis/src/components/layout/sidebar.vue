<template>
    <!-- Side Bar -->
    <div class="sidebar">
        <!-- Sidebar top  -->
        <div class="sidebar__top"></div>
        <!-- Sidebar main -->
        <div class="sidebar__main">
            <div class="sidebar__main-list">
                <div class="sidebar__main-list-img">
                    <i class="far fa-file-alt"></i>
                </div>
                <p class="sidebar__main-list-text">Lập hồ sơ điện tử</p>
            </div>

            <div class="sidebar__main-list">
                <div class="sidebar__main-list-img">
                    <i class="far fa-file-pdf"></i>
                </div>
                <p class="sidebar__main-list-text">Lập hồ sơ giấy</p>
            </div>

            <div class="sidebar__main-list">
                <div class="sidebar__main-list-img">
                    <i class="fas fa-signal"></i>
                </div>
                <p class="sidebar__main-list-text">Theo dõi chi</p>
            </div>

            <div class="sidebar__main-list">
                <div class="sidebar__main-list-img">
                    <i class="fas fa-chart-pie"></i>
                </div>
                <p class="sidebar__main-list-text">Theo dõi đóng</p>
            </div>

            <div class="sidebar__main-list active">
                <div class="sidebar__main-list-img">
                    <i class="fas fa-tasks"></i>
                </div>
                <p class="sidebar__main-list-text">Quản lý lao động</p>
            </div>

            <div class="sidebar__main-list">
                <div class="sidebar__main-list-img">
                    <i class="fas fa-cog"></i>
                </div>
                <p class="sidebar__main-list-text">Thiết lập</p>
            </div>
        </div>
    </div>
    <!-- End side bar -->
</template>

<script>
export default {
    name: "sidebar",
};
</script>

<style scoped lang="scss">
.sidebar {
    width: 220px;
    height: 100vh;
    background-color: #fff;
    border-right: 1px solid #e5e5e5;
    float: left;
    /*--------------- sidebar top ---------------*/
    &__top {
        height: 60px;
        background-color: grey;
    }
    /*--------------- sidebar main ---------------*/
    &__main {
        $height: 40px;
        &-list {
            height: $height;
            width: 100%;
            padding-left: 24px;
            color: rgba(0, 0, 0, 0.8);
            line-height: $height;
            font-size: 13px;
            cursor: pointer;
            display: flex;
            &-img {
                margin: auto 0;
                width: 20px;
                height: 20px;
                line-height: 20px;
            }
        }
        &-list:hover {
            background-color: #e5e5e5;
            color: #000;
        }

        &-list.active {
            background-color: #019160;
            color: #fff;
            i {
                color: #fff;
            }
        }
    }
}
</style>
