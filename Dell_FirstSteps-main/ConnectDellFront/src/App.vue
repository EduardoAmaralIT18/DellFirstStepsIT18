<script setup lang="ts">
import "@dds/components/src/scss/dds-reboot.scss";
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import "@dds/components/src/scss/dds-helpers.scss";
import "@dds/components/src/scss/dds-main.scss";
import LoginView from "./views/LoginView.vue";
import Header from "./components/Header.vue";
</script>

<template>
  <!-- <LoginView/> -->
  <Header name="Luana" :role="0" />
</template>

<style scoped></style>
