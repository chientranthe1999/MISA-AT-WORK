<template>
    <!-- Header -->
    <div class="header">
        <div class="header__left">
            <BaseCombobox placeholder="Nhập vào xe của bạn" :selectLists="selectLists" />
        </div>
        <div class="header__right">
            <div class="user-avt"></div>
            <div class="user-name">GC hihi</div>
            <div class="user-action"><i class="fas fa-ellipsis-h"></i></div>
        </div>
    </div>
    <!-- End header  -->
</template>

<script>
    import BaseCombobox from '../common/BaseCombobox';
    export default {
        name: 'Header',

        data() {
            return {
                selectLists: [
                    { key: 1, value: 'GC Corporation' },
                    { key: 2, value: 'Nhà hàng biển đông' },
                ],
            };
        },

        components: {
            BaseCombobox,
        },
    };
</script>

<style lang="scss" scoped>
    .header {
        height: 60px;
        width: 100%;
        border-bottom: 1px solid #e5e5e5;
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 0 20px;

        &__left {
            select {
                font-size: 20px;
                font-weight: 600;
                width: auto;
                padding-right: 10px;
                margin-left: -5px;
            }
        }

        &__right {
            height: 40px;
            max-width: 200px;
            margin: auto 0;
            display: flex;
            align-items: center;

            .user-avt {
                width: 40px;
                height: 40px;
                border-radius: 50%;
                background-image: url('../../assets/img/avt.png');
                background-repeat: no-repeat;
                background-size: cover;
                border: 1px solid #e5e5e5;
            }

            .user-name {
                text-align: center;
                flex: 1;
                text-overflow: ellipsis;
                white-space: nowrap;
                overflow: hidden;
                margin: 0 10px;
            }

            .user-action {
                $kt: 40px;
                width: $kt;
                height: $kt;
                line-height: $kt;
                text-align: center;
                font-size: 20px;
                color: rgba(0, 0, 0, 0.5);
                cursor: pointer;
            }
        }
    }
</style>
