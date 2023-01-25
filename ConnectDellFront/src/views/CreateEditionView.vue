<script setup lang="ts">
  import CreateEdition from '../components/CreateEdition.vue';
  import NavBar from '../components/NavBar.vue';
  import SideBar from '../components/SideBar.vue';
  import { RouterView } from 'vue-router';
</script>

<template>
  
    <main>
      <NavBar></NavBar>
      <SideBar view="home"></SideBar>
      <CreateEdition />
      <RouterView />
    </main>

</template>