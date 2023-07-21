<script setup lang="ts">
import "@dds/components/src/scss/dds-reboot.scss";
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import "@dds/components/src/scss/dds-helpers.scss";
import "@dds/components/src/scss/dds-main.scss";
import Header from "./components/Header.vue"
import Sidebar from "./components/Sidebar.vue";
import { ref, watch } from 'vue';
import { useRoute } from "vue-router";

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

<template class="template">
    <Header class="header" :name="name" :role="role"/>
    <div class="container">
    <Sidebar class="sidebar" v-if="role !== ''"/>
        <main class="main" >
            <RouterView id="router"/>
        </main>
    </div>
</template>

<style scoped>
    .template{
        height: 100vh;
    }
    .container {
        height: 92vh; /* TO-DO */
        display: flex;
        flex-direction: row; 
    }

    .main {
        flex-grow: 2;
    }
</style>
