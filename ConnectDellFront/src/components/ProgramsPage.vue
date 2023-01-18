<script lang="ts">
    import NavBar from '../components/NavBar.vue';
    import SideBar from '../components/SideBar.vue';
    import { RouterView } from 'vue-router';
    import { defineComponent } from 'vue';

    interface Data {
      TESTE: string
    }

    export default defineComponent({
      components: {
        NavBar,
        SideBar,
        RouterView
      },
      data(): Data {
        return {
          TESTE: this.$cookies.get("programId")
        }
      }
    })
</script>

<template>
  <main>
    <NavBar></NavBar>
    <SideBar view="home"></SideBar>
    <h2 class="h2">PROGRAMS PAGE</h2>
    {{ TESTE }}
    <RouterView />
  </main>
</template>

<style>
.h2 {
  margin-top: 200px;
}
</style>