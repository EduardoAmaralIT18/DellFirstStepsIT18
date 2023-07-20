<script setup lang="ts">
const props = defineProps({
  name: String
});
</script>

<template>
    <button class="dds__button dds__button--primary" type="button">{{ name }}</button>
</template>

<style scoped>
</style>