<script setup lang="ts">
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { RouterView } from 'vue-router';
//import AddNews from '@/components/EditProgram.vue';
import EditProgram from '@/components/EditProgram.vue';

</script>
<template>
  <main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <EditProgram />
    <RouterView />
  </main>

</template>