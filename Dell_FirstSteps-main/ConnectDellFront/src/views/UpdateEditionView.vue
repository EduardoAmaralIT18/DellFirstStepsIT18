<script setup lang="ts">
  import UpdateEdition from '../components/UpdateEdition.vue';
  import NavBar from '../components/NavBar.vue';
  import SideBar from '../components/SideBar.vue';
  import { RouterView } from 'vue-router';
</script>

<template>

    <main>
      <NavBar></NavBar>
      <SideBar></SideBar>
      <UpdateEdition />
      <RouterView />
    </main>

</template>