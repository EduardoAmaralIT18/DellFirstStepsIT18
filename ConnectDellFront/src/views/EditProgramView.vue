<script setup lang="ts">
import EditProgram from '../components/EditProgram.vue';
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { RouterView } from 'vue-router';
<<<<<<< HEAD
//import AddNews from '@/components/EditProgram.vue';
import EditProgram from '@/components/EditProgram.vue';
=======
>>>>>>> 8ed4ca8ea0e580bb69561801b99c44c937c23304

</script>
<template>
  <main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <EditProgram />
    <RouterView />
  </main>

</template>