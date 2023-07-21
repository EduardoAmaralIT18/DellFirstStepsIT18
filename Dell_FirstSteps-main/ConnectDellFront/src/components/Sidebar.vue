<script setup lang="ts">
import router from '@/router';
import { ref } from 'vue';

const role = +localStorage.getItem("userRole")!;
let isActive = ref(0)

function handleClick(key: number) {
  if (key !== isActive.value) {
    if (key === 1) {
      isActive.value = 1
      router.push("/")
    }
    else if (key === 2) {
      isActive.value = 2
      router.push("/Users")
    }
    else if (key === 3) {
      isActive.value = 3
      router.push("/News")
    }

  }
}

</script>

<template>
  <nav class="dds__side-nav__wrapper" data-dds="side-nav" id="sidenav-909416562" aria-label="Side Navigation example">
    <section class="dds__side-nav">
      <ul class="dds__side-nav__menu">
        <li @click="handleClick(1)" :class="{ 'dds__side-nav__item--selected': isActive === 1 }" class="dds__side-nav__item">
          <a href="javascript:void(0)">
            <span class="text dds__icon dds__side-nav__icon dds__icon--home" aria-hidden="true"></span>
            <span class="text">Home</span>
          </a>
        </li>
        <li @click="handleClick(2)" :class="{ 'dds__side-nav__item--selected': isActive === 2 }" v-if="role === 0"
          class="dds__side-nav__item">
          <a href="javascript:void(0)">
            <span class="text dds__icon dds__side-nav__icon dds__icon--user-cir" aria-hidden="true"></span>
            <span class="text">Users</span>
          </a>
        </li>
        <li @click="handleClick(3)" :class="{ 'dds__side-nav__item--selected': isActive === 3 }"
          class="dds__side-nav__item ">
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
nav {
  height: 100%;
}

.text {
  color: #0d76b2;
}</style>
