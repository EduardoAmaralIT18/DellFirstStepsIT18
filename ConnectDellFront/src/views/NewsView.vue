<script setup lang="ts">
import NewsPage from '../components/NewsPage.vue';
import NavBar from './components/NavBar.vue';
import SideBar from './components/SideBar.vue';
import { RouterView } from 'vue-router';
</script>
<template>
  <main>
    <NavBar></NavBar>
    <SideBar view="home"></SideBar>
    <NewsPage />
    <RouterView />
  </main>

</template>