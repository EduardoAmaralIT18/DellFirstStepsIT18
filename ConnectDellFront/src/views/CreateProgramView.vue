<script setup lang="ts">
  import CreateProgram from '../components/CreateProgram.vue';
  import NavBar from '../components/NavBar.vue';
  import SideBar from '../components/SideBar.vue';
  import { RouterView } from 'vue-router';
</script>
<template>
  
  <main>
    <NavBar></NavBar>
    <SideBar view="home"></SideBar>
    <CreateProgram />
    <RouterView />
  </main>

</template>