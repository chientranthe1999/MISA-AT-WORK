<template>
    <div class="combobox" :style="{ width: this.comboxStyle.width, height: this.comboxStyle.height, border: this.comboxStyle.border }">
        <input type="text" :placeholder="this.placeholder" readonly="readonly" :value="inputValue" @keyup.13="changing" tabindex="1" />
        <div @click="changing" tabindex="1" @keyup.13="changing" :style="{ transform: 'rotate(' + rotate + 'deg)' }">
            <i class="fas fa-chevron-down"></i>
        </div>

        <div class="combobox-list" :class="{ active: showList }">
            <div
                class="combobox-list-items"
                v-for="item in selectLists"
                :key="item.key"
                @click="setValue(item.value)"
                tabindex="1"
                @keyup.13="setValue(item.value)"
            >
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
                rotate: 0,

                inputValue: this.defaultValue,
            };
        },

        props: {
            selectLists: Array,

            placeholder: {
                type: String,
                default: '',
            },

            defaultValue: {
                type: String,
                default: 'Chiến Nobi',
            },

            comboxStyle: {
                type: Object,
                // Object or array defaults must be returned from a factory function
                default: function() {
                    return {
                        backgroundColorHover: '#bbb',
                        width: '250px',
                        height: '40px',
                        border: 'none',
                    };
                },
            },

            textColor: {
                type: String,
                default: '#000000',
            },
        },

        computed: {
            showList: function() {
                if (this.rotate == 0) {
                    return false;
                } else return true;
            },
        },

        methods: {
            /**
             * Change arrow direction when click
             */
            changing() {
                this.rotate = this.rotate == 0 ? 180 : 0;
            },

            /**
             * Changing current value when click into item
             */
            setValue(value) {
                this.inputValue = value;
                this.rotate = this.rotate == 0 ? 180 : 0;
            },
        },
    };
</script>

<style lang="scss" scope>
    .combobox {
        position: relative;
        display: flex;
        border-radius: 4px;

        input {
            height: 100%;
            padding-left: 16px;
            flex: 1;
            font-size: 16px;
        }

        input:focus {
            border-color: #01b075;
        }

        input + div {
            height: 40px;
            width: 40px;
            line-height: 40px;
            text-align: center;
            cursor: pointer;
            border-radius: 4px;
            overflow: hidden;
            z-index: 1;
            transition: transform 0.2s ease-in;
        }

        input + div:focus {
            outline: none;
            // border: 1px solid #e5e5e5;
        }

        &-list {
            position: absolute;
            background-color: #fff;
            border: 1px solid #bbb;
            width: 100%;
            border-radius: 4px;
            top: 45px;
            display: none;
            visibility: hidden;
            max-height: 160px;
            overflow: auto;

            &-items {
                height: 40px;
                cursor: pointer;
                line-height: 40px;
                padding: 0 24px;
            }

            &-items:hover {
                background-color: #bbb;
            }

            &-items:focus {
                background-color: #bbb;
                outline: none;
                border: none;
            }
        }

        &-list.active {
            display: block;
            visibility: visible;
            z-index: 1;
        }
    }
</style>
