<template>
    <RouterLink :to="`${path}`" class="goBack"> &larr; Go back</RouterLink>
</template>

<script setup lang="ts">
const props = defineProps({
    path: String
});
</script>

<style scoped>
.goBack {
  text-decoration: none;
}
</style>