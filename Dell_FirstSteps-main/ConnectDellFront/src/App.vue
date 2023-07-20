<script setup lang="ts">
import "@dds/components/src/scss/dds-reboot.scss";
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import "@dds/components/src/scss/dds-helpers.scss";
import "@dds/components/src/scss/dds-main.scss";
import LoginView from "./views/LoginView.vue";

import Sidebar from "./components/Sidebar.vue";

</script>

<template>
    <main>
        <RouterView id="router"/>
    </main>
</template>

<style scoped></style>
