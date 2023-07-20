<script setup lang="ts">
import "@dds/components/src/scss/dds-reboot.scss";
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import "@dds/components/src/scss/dds-helpers.scss";
import "@dds/components/src/scss/dds-main.scss";
import Sidebar from "./components/Sidebar.vue";
const role= localStorage.getItem("role");
console.log(role);
</script>

<template>
    <main>
        <RouterView id="router"/>
    </main>
    <!-- <Sidebar v-if="role"></Sidebar> -->
</template>

<style scoped></style>
