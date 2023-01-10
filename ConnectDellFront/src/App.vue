
<template>
  <NavBar></NavBar>
  <SideBar view="home"></SideBar>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import NavBar from './components/NavBar.vue';
import SideBar from './components/SideBar.vue';

export default defineComponent({
  name: 'App',
  components: {
    NavBar,
    SideBar
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
