<script>
    import NavBar from '../components/NavBar.vue';
    import SideBar from '../components/SideBar.vue';
    import { RouterView } from 'vue-router';
    import { defineComponent } from 'vue';
    import axios from 'axios';
    import ApiHandler from '../libs/ApiHandler'; 

    export default defineComponent({
      components: {
        NavBar,
        SideBar,
        RouterView
      },
      data() {
        return {
          cookiesId: this.$cookies.get("programId"),
          program: ''
        }
      },
      created() {
        axios.get(ApiHandler.URL(`/Program/showInfoProgram?id1=${this.cookiesId}`))
                .then(function (response) {
                    return response;
                })
                .then(response => {
                    if (response.status == 200) {
                        this.program = response.data;
                    } else if (response.status == 204) {
                        alert("There was an error on our database! Please, try again later.");
                    }
                })
      }
    })
</script>

<template>
  <main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <h2>PROGRAMS PAGE</h2>
    <p>{{ program.name }}</p>
    <RouterView />
  </main>
</template>

<style scoped>
h2 {
  margin-top: 200px;
}
</style>