<template>
    <div class="combobox" :style="{ width: this.comboboxWidth, height: this.comboboxHeight, border: this.comboboxBorder }">
        <input
            type="text"
            :placeholder="this.placeholder"
            readonly="readonly"
            :value="inputValue"
            @keyup.13="changing"
            tabindex="1"
            :style="{ 'font-size': fontSize, 'font-weight': fontWeight, color: textColor }"
        />
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
                <span><i class="fas fa-check"></i></span>
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
                type: String,
                default: '',
            },

            comboboxHeight: {
                type: String,
                default: '50px',
            },

            comboboxWidth: {
                type: String,
                default: '250px',
            },

            comboboxBorder: {
                type: String,
                default: '1px solid #e5e5e5',
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

            /**
             * Function to set default value when props defaultValue is empty
             */
            checkingDefaultValue() {
                if (this.defaultValue == '' || this.defaultValue == null) {
                    return this.selectLists[0].value;
                }
            },
        },
    };
</script>

<style lang="scss" scope>
    @import '../../style/components/common/BaseCombobox';
</style>
