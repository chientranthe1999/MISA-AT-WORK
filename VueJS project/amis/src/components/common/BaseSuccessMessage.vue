<template>
    <div class="success-message d-flex">
        <div class="success-message-icon"><i class="far fa-check-circle"></i></div>
        <div>
            <p>Success</p>
            <p>Thêm dữ liệu thành công</p>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'BaseSuccessMessage',
    };
</script>

<style lang="scss" scoped>
    $greenColor: #01b075;
    .success-message {
        position: fixed;
        right: 0;
        bottom: 100px;
        padding: 10px 20px;
        background-color: #01b075;
        border-radius: 4px;
        color: white;
        align-items: center;
        justify-content: center;
        // display: none;
        box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px;
        animation: flashMessage 2s linear;

        .success-message-icon {
            margin-right: 5px;
            font-size: 60px;
        }
        p {
            margin: 2px 2px;
        }

        @keyframes flashMessage {
            0% {
                opacity: 1;
                display: block;
                right: 0;
            }

            100% {
                opacity: 0;
                display: none;
                right: -100%;
            }
        }
    }
</style>
