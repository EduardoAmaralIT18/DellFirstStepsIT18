<script setup lang="ts">
import EditProgram from '../components/EditProgram.vue';
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { RouterView } from 'vue-router';

</script>
<template>
  <main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <EditProgram />
    <RouterView />
  </main>

</template>