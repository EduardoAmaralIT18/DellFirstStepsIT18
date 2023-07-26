<script setup lang="ts">
import "@dds/components/src/scss/dds-reboot.scss";
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import "@dds/components/src/scss/dds-helpers.scss";
import "@dds/components/src/scss/dds-main.scss";

import Header from "./components/Header.vue";
import Sidebar from "./components/Sidebar.vue";
import {onMounted, ref, watch} from "vue";
import { useRoute } from "vue-router";
import router from "@/router";

const name = ref<string>();
const role = ref<string>();

const route = useRoute();
watch(route, () => {
    name.value = localStorage.getItem("userName")!;
    role.value = localStorage.getItem("userRole")!;
});

const routes = router.options.routes;

const routeExist = () => {
  return routes.some(r => r.path == route.path)
}
</script>

<template class="template">
    <Header class="header" :name="name" :role="role" />
    <div class="container">
        <Sidebar class="sidebar" v-if="(role !== '') && (routeExist())" />
        <main class="main">
            <RouterView id="router" />
        </main>
    </div>

</template>

<style>
.template {
    height: 100vh;
    font-family: 'Roboto', sans-serif;
}

.container {
    /* height: 100vh; */
    display: flex;
    flex-direction: row;
}

.main {
    flex-grow: 2;
}
</style>
