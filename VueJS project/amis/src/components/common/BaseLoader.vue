<template>
    <div class="loading-indicator" v-if="isShow == true">
        <div class="loading-icon"></div>
    </div>
</template>

<script>
    export default {
        name: 'BaseLoader',

        props: {
            isShow: {
                type: Boolean,
                default: false,
            },
        },
    };
</script>

<style scoped lang="scss">
    .loading-indicator {
        position: absolute;
        top: 0;
        right: 0;
        left: 0;
        bottom: 0;
        display: flex;
        align-items: center;
        justify-content: center;
        background-color: rgba(0, 0, 0, 0.2);
        z-index: 90;

        .loading-icon {
            width: 150px;
            height: 150px;
            background-image: url(../../assets/icon/loading-icon-3.gif);
            background-size: cover;
        }
    }
</style>
