<template>
    <div class="combobox">
        <input type="text" :placeholder="this.placeholder" readonly="readonly" value="Lala" />
        <div @click="this.changing">
            <span :style="{ transform: 'rotate(' + rotate + 'deg)' }">
                <i class="fas fa-chevron-down"></i>
            </span>
        </div>

        <div class="combobox-list">
            <div class="combobox-list-items" v-for="item in selectList" :key="item.key">
                {{ item.value }}
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'BaseCombobox',
        data() {
            return {
                rotate: true,
            };
        },

        props: {
            selectList: Array,
            placeholder: {
                type: String,
                default: '',
            },
        },

        computed: {},

        methods: {
            changing() {
                this.rotate = this.rotate == 0 ? 180 : 0;
                console.log(this.rotate);
            },
        },
    };
</script>

<style lang="scss" scope>
    .combobox {
        float: left;
        position: relative;
        width: 200px;
        input {
            height: 40px;
            border-radius: 4px;
            border: 1px solid #bbb;
            padding: 5px 10px;
            width: 100%;
            color: #bbb;
        }

        input:focus {
            border-color: #01b075;
        }

        input + div {
            position: absolute;
            top: 0;
            right: 0;
            height: 40px;
            width: 40px;
            line-height: 40px;
            text-align: center;
            cursor: pointer;

            > span {
                display: block;
            }
        }

        &-list {
            position: absolute;
            background-color: #bbb;
            /* height: 40px; */
            width: 100%;
            border-radius: 4px;
            bottom: px;
            top: 45px;

            &-items {
                height: 40px;
                cursor: pointer;
                line-height: 40px;
                padding: 0 24px;
            }
        }
    }
</style>
