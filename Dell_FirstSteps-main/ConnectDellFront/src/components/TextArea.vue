<script setup lang="ts">
import { ref } from 'vue';

const props = defineProps({
    boxName: String,
    minlength: String,
    maxlength: String,
    helperText: String,
    errorText: String,
    required: Boolean,
    initialValue: String
});

const info = ref(`${props.initialValue ? props.initialValue : ''}`);

const emits = defineEmits({
    descriptionText: String
})

function sendTextToParent() {
    emits('descriptionText', info);
}
</script>

<template>
    <div id="text-area-container-502168065" class="dds__text-area__container" data-dds="text-area">
        <div class="dds__text-area__header">
            <label v-if="required" id="text-area-label-867784391" for="text-area-control-867784391"
                class="dds__label dds__label--required">{{ boxName }}</label>
            <label v-else id="text-area-label-867784391" for="text-area-control-867784391" class="dds__label dds__label">{{
                boxName }}</label>
        </div>
        <div class="dds__text-area__wrapper">
            <textarea class="dds__text-area" name="text-area-control-name-867784391" id="text-area-control-867784391"
                aria-required="true" aria-labelledby="text-area-label-867784391 text-area-helper-867784391" required
                v-model="info" :minlength="`${minlength}`" :maxlength="`${maxlength}`" @input="sendTextToParent"></textarea>
            <small id="text-area-helper-359524269" class="dds__input-text__helper">{{ helperText }}</small>
            <small id="text-area-error-867784391" class="dds__invalid-feedback">{{ errorText }}</small>
        </div>
    </div>
</template>