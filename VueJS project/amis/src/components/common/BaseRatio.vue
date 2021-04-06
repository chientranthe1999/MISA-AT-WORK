<template>
    <label :for="keyID">
        <input :id="keyID" type="radio" :value="value" :name="name" :checked="isChecked" />
        <span class="circle"></span>
        <span><slot></slot></span>
    </label>
</template>

<script>
    export default {
        name: 'BaseRatio',

        data() {
            return {
                keyID: Date.now().toString() + this.value,
            };
        },

        props: {
            name: {
                type: String,
                default: 'ratio',
            },

            value: {
                type: String,
            },

            title: {
                type: String,
                default: '',
            },

            isChecked: {
                type: Boolean,
                default: false,
            },
        },
    };
</script>

<style scoped>
    label {
        display: flex;
        align-items: center;
        margin-right: 8px;
    }

    input[type='radio'] {
        display: none;
    }

    .circle {
        width: 20px;
        height: 20px;
        border: 1px solid #bbb;
        display: inline-block;
        border-radius: 50%;
        position: relative;
        margin-right: 2px;
    }

    input:checked + .circle {
        border-color: #019160;
    }

    input:checked + .circle::after {
        content: '';
        display: inline-block;
        width: 12px;
        height: 12px;
        border-radius: 50%;
        background-color: #019160;
        position: absolute;
        right: 50%;
        top: 50%;
        transform: translate(50%, -50%);
    }
</style>
