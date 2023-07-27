<template>
    <button class="dds__button dds__button--secondary" type="button" @click="sendClickToParent" :disabled="isDisabled">{{
        buttonName }}</button>
</template>

<script setup lang="ts">
defineProps({
    buttonName: String,
    isDisabled: Boolean
});

const emits = defineEmits({
    clicked: Boolean
})

function sendClickToParent() {
    emits('clicked', true);
}
</script>