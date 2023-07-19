<script setup lang="ts">
import { ref } from 'vue';
const props = defineProps({role:Number})
let isActive = ref(1)
function selectedItem(key: number){
  isActive.value=key;
}
</script>

<template>
    <nav class="dds__side-nav__wrapper" data-dds="side-nav" id="sidenav-909416562" aria-label="Side Navigation example">
    <section class="dds__side-nav">
      <ul class="dds__side-nav__menu">
        <li @click="selectedItem(1)" :class="{ 'dds__side-nav__item--selected': isActive===1}" class="dds__side-nav__item">
          <a href="javascript:void(0)">
            <span class="text dds__icon dds__side-nav__icon dds__icon--home" aria-hidden="true"></span>
            <span class="text">Home</span>
          </a>
        </li>
        <li @click="selectedItem(2)" :class="{ 'dds__side-nav__item--selected': isActive===2}" v-if=" role===0 " class="dds__side-nav__item">
          <a href="javascript:void(0)">
            <span class="text dds__icon dds__side-nav__icon dds__icon--user-cir" aria-hidden="true"></span>
            <span class="text">Users</span>
          </a>
        </li>
        <li @click="selectedItem(3)" :class="{ 'dds__side-nav__item--selected': isActive===3}" class="dds__side-nav__item ">
          <a href="javascript:void(0)">
            <span class="text dds__icon dds__side-nav__icon dds__icon--doc-lines" aria-hidden="true"></span>
            <span class="text">News</span>
          </a>
        </li>
      </ul>
    </section>
  </nav>
  </template>

<style scoped>
nav{
  height: 100vh;
}
.text{
  color: #0d76b2;
}
</style>
