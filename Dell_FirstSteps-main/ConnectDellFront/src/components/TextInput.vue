<script setup>
import "@dds/components/src/scss/dds-fonts.scss";
import { ref, defineProps, defineEmits } from 'vue';

const props = defineProps(['value']); 

const inputValue = ref(props.value)

const { emit } = defineEmits()

const handleInput = (event) => { 
    inputValue.value = event.target.value
    emit('input', inputValue.value)
};

</script>

<template>
    <div id="text-input-216225955" class="dds__input-text__container">
        <label id="text-input-label-647192958" for="text-input-control-647192958" class="dds__label dds__label--required">{{
            boxName }}</label>
        <div class="dds__input-text__wrapper">
            <input type="text" class="dds__input-text" name="text-input-control-name-647192958"
                id="text-input-control-647192958" required="true"
                aria-labelledby="text-input-label-647192958 text-input-helper-647192958"/>
            <small id="text-input-helper-647192958" class="dds__input-text__helper"></small>
            <div id="text-input-error-647192958" class="dds__invalid-feedback">Error text</div>
        </div>
    </div>
</template>


<style scoped></style>