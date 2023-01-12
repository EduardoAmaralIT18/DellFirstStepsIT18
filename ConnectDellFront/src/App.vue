<template>
  <NavBar></NavBar>
  <SideBar></SideBar>
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
    },
    data() {
      return {}
    },
    created() {
        this.$cookies.set("NAME", "Elise"),
        this.$cookies.set("ROLE", "Intern")
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