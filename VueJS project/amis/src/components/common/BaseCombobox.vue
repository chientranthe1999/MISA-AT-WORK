<template>
    <div class="combobox" :style="{ width: comboboxWidth, height: comboboxHeight, border: comboboxBorder, padding: comboboxPadding }">
        <input
            type="text"
            :placeholder="placeholder"
            readonly="readonly"
            :value="inputValue"
            @keyup.13="changing"
            tabindex="1"
            :style="{ 'font-size': fontSize, 'font-weight': fontWeight, color: textColor }"
        />
        <div @click="changingArrowDirection" tabindex="1" @keyup.13="changingArrowDirection" :style="{ transform: 'rotate(' + rotate + 'deg)' }">
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
                <span>{{ item.value }}</span>
                <span v-if="item.value == inputValue"><i class="fas fa-check"></i></span>
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

                inputValue: this.checkingDefaultValue(),
            };
        },

        props: {
            selectLists: Array,

            placeholder: {
                type: String,
                default: '',
            },

            defaultValue: {
                type: Object,
                default() {
                    return {
                        key: '-1',
                        value: '',
                    };
                },
            },

            comboboxHeight: {
                type: String,
                default: '40px',
            },

            comboboxWidth: {
                type: String,
                default: '250px',
            },

            comboboxBorder: {
                type: String,
                default: '1px solid #bbb',
            },

            textColor: {
                type: String,
                default: 'black',
            },

            fontSize: {
                type: String,
                default: '16px',
            },

            fontWeight: {
                type: String,
                default: '100',
            },

            comboboxPadding: {
                type: String,
                default: '0',
            },
        },

        // When the component rendered call this function
        mounted() {
            this.checkingDefaultValue();
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
            changingArrowDirection() {
                this.rotate = this.rotate == 0 ? 180 : 0;
            },

            /**
             * Changing current value when click into item
             */
            setValue(value) {
                this.inputValue = value;
                this.rotate = this.rotate == 0 ? 180 : 0;
            },

            /**
             * Function to set default value when props defaultValue is empty
             */
            checkingDefaultValue() {
                if (this.defaultValue.value == '' || this.defaultValue.value == null) {
                    return this.selectLists[0].value;
                } else return this.defaultValue.value;
            },
        },
    };
</script>

<style lang="scss" scope>
    @import '../../style/components/common/BaseCombobox';
</style>
