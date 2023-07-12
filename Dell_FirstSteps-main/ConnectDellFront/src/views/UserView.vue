<script setup lang="ts">
import UserPage from '../components/UserPage.vue';
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { RouterView } from 'vue-router';
</script>
<template>
  <main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <UserPage />
    <RouterView />
  </main>

</template>