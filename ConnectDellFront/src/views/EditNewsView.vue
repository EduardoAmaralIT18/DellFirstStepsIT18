<script setup lang="ts">
import EditNews from '../components/EditNews.vue';
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { RouterView } from 'vue-router';

</script>
<template>
  <main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <EditNews />
    <RouterView />
  </main>

</template>