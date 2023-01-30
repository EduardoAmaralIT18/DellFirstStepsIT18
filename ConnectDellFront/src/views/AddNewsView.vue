<script setup lang="ts">
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { RouterView } from 'vue-router';
import AddNews from '@/components/AddNews.vue';
</script>
<template>
  <main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <AddNews />
    <RouterView />
  </main>

</template>