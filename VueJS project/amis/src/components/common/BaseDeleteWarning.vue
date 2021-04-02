<template>
    <div class="dialog-swapper">
        <div class="dialog">
            <div id="close-btn"><i class="fas fa-times"></i></div>
            <div class="dialog__close"></div>
            <div class="dialog__header">
                Xóa bản ghi 101
            </div>
            <div class="dialog__infor">
                <div class="dialog__infor-icon"></div>
                <p>Bạn có chắc muốn xóa bản ghi này Chiến Nobi kjdf mandkjhsdf áhldkfuhlsdku</p>
            </div>
            <div class="dialog__footer">
                <div class="dialog__footer-cancel">Hủy</div>
                <div class="dialog__footer-agree">Đồng ý</div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {};
</script>

<style scoped lang="scss">
    .dialog-swapper {
        position: fixed;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
        background-color: rgba(0, 0, 0, 0.5);
        font-size: 13px;
        z-index: 3;
    }

    .dialog {
        position: absolute;
        right: 50%;
        top: 50%;
        transform: translate(50%, -50%);
        background-color: white;
        width: fit-content;
        border-radius: 4px;
        padding-top: 24px;
        overflow: hidden;
        width: 350px;

        &__infor {
            padding: 0 24px;
        }

        &__header {
            padding: 0 24px;
            margin-bottom: 24px;
            color: #000;
            font-weight: bold;
            font-size: 15px;
        }

        &__infor {
            display: flex;

            &-icon {
                margin-right: 10px;
                height: 50px;
                width: 50px;
                background-color: #e5e5e5;
            }
            padding: 0 24px;
            margin-bottom: 24px;
        }

        &__footer {
            padding: 0 24px;
            display: flex;
            align-items: center;
            justify-content: flex-end;
            height: 60px;
            background-color: #e9ebee;

            > div {
                height: 40px;
                border-radius: 4px;
                line-height: 40px;
                cursor: pointer;
                width: 100px;
                text-align: center;
                font-size: 13px;
                user-select: none;
            }

            &-cancel {
                margin-right: 16px;
                color: #000;
            }

            &-agree {
                background-color: #019160;
                color: #fff;
            }

            &-cancel:hover {
                background-color: #bbbbbb;
            }

            &-agree:hover {
                background-color: #01b075;
            }
        }
    }

    #close-btn {
        height: 40px;
        width: 40px;
        text-align: center;
        line-height: 40px;
        font-size: 18px;
        position: absolute;
        right: 0;
        top: 0;
    }

    #close-btn:hover {
        background-color: #e5e5e5;
        border-radius: 4px;
        cursor: pointer;
    }
</style>
