
<template>
  <HelloWorld msg="Welcome to Your Vue.js + TypeScript App"/>
  <NavBar></NavBar>
  <SideBar></SideBar>
</template>

<script lang="ts">
/* eslint-disable */
import { defineComponent } from 'vue';
import HelloWorld from './components/HelloWorld.vue';
import NavBar from './components/NavBar.vue';
import SideBar from './components/SideBar.vue';

export default defineComponent({
  name: 'App',
  components: {
    HelloWorld,
    NavBar,
    SideBar,
  }
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
