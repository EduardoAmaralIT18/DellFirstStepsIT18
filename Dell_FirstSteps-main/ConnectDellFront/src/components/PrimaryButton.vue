<template>
    <button class="dds__button dds__button--primary" type="button">{{ name }}</button>
</template>

<script setup lang="ts">
const props = defineProps({
  name: String
});

</script>

<style scoped>
</style>