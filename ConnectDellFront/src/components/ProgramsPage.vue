<script setup lang="ts">
    import NavBar from '../components/NavBar.vue';
    import SideBar from '../components/SideBar.vue';
    import { RouterView } from 'vue-router';
</script>

<template>
  <main>
    <NavBar></NavBar>
    <SideBar view="home"></SideBar>
    <h2 class="h2">PROGRAMS PAGE</h2>
    <RouterView />
  </main>
</template>

<style>
    .h2 {
        margin-top: 200px;
    }
</style>