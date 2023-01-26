<script setup lang="ts">
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import NotFound from '../components/NotFound.vue';
import { RouterView } from 'vue-router';
</script>
<template>
    <main>
        <NavBar></NavBar>
        <SideBar></SideBar>
        <NotFound />
        <RouterView />
    </main>

</template>