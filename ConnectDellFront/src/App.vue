<template>
  <NavBar></NavBar>
  <SideBar></SideBar>
  <CreateProgram></CreateProgram>
</template>

<script lang="ts">
  
  import { defineComponent } from 'vue';
  import NavBar from './components/NavBar.vue';
  import SideBar from './components/SideBar.vue';
  import CreateProgram from './components/CreateProgram.vue';
  
  export default defineComponent({
    name: 'App',
    components: {
      NavBar,
      SideBar,
      CreateProgram
    },
    data() {
      return {}
    },
    created() {
    }
  });
</script>

<style>
  #app {
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
</style>