<script setup lang="ts">
import NewsPage from '../components/NewsPage.vue'
import { RouterView } from 'vue-router';
</script>
<template>
  <main>
    <NewsPage />
    <RouterView />
  </main>

</template>