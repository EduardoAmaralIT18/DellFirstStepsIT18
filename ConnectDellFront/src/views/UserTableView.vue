<script setup lang="ts">
  import UserTable from '../components/UserTable.vue';
  import NavBar from '../components/NavBar.vue';
  import SideBar from '../components/SideBar.vue';
  import { RouterView } from 'vue-router';
</script>

<template>

<main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <UserTable />
    <RouterView />
  </main>

</template>