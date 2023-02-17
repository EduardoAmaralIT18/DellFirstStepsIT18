<script setup lang="ts">
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { RouterView } from 'vue-router';
import AddEvent from '@/components/AddEvent.vue';
</script>
<template>
  <main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <AddEvent />
    <RouterView />
  </main>

</template>