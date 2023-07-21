<script setup lang="ts">
import "@dds/components/src/scss/dds-reboot.scss";
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import "@dds/components/src/scss/dds-helpers.scss";
import "@dds/components/src/scss/dds-main.scss";
import LoginView from "./views/LoginView.vue";
import Header from "./components/Header.vue"

import Sidebar from "./components/Sidebar.vue";
import { onMounted, onUpdated, ref, watchEffect,watch, computed } from 'vue';
import { onBeforeRouteUpdate,useRoute } from "vue-router";

localStorage.setItem("name", '');
localStorage.setItem("id", '');
localStorage.setItem("email", '');
localStorage.setItem("role", '');


const name = ref();
const role = ref();

const route = useRoute()
watch(route,()=>{
    name.value = localStorage.getItem("name");
    role.value = localStorage.getItem("role");
})
</script>

<template>
    <Header :name="name" :role="role"/>
    <Sidebar/>
    <main>
        <RouterView id="router"/>
    </main>
</template>

<style scoped>

</style>
