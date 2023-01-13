<!-- ALTERADO -->
<template>

  <header class="navbar shadow-lg fixed-top">
      <div class="container-fluid">
          <div class="row">
              <div class="col-4 dellLogo">
                <a href="index.html"><img class="logo" alt="logo Dell" src="../assets/logoDell.png"></a>
              </div>
          </div>
      </div>
  </header>

  <div class="container">
    <p class="title">Sign in to Dell FirstSteps</p>
    <button v-for="us in user" :key="us.id" @click="setCookies(us)" class="dds__button dds__button--primary" type="button">Login with {{us.email}}</button>
  </div>

</template>

<script lang="ts">

import { defineComponent } from "vue";
import axios from "axios";

type User = {
}[];

interface Data {
  user: null | User;
  item: {
    id: Number;
    name: string;
    email: string;
    role: Number;
  };
}


export default defineComponent({
  data(): Data {
    return {
      user: null,
      item: {
        id: 0,
        name: "",
        email: "",
        role: 1,
      },
    };
  },

  created() {
    // fetch the data when the view is created and the data is
    // already being observed
    this.fetchData();
  },
  watch: {
    // call again the method if the route changes
    $route: "fetchData",
  },
  methods: {
    fetchData(): void {
      axios
        .get("/Login/getUserList")
        .then(function (response) {
          return response;
        })
        .then((response) => {
          this.user = response.data;
          return;
        });
    },
    setCookies(us: Data["item"]): void {
      this.$cookies.set("id", us.id);
      this.$cookies.set("name", us.name);
      this.$cookies.set("role", us.role);
      this.$cookies.set("email", us.email);
      this.$router.push({ name: "HomePage" });
    },
  },
});
</script>
   
<style scoped>

main{
  background-color: transparent;
}
body{
    background: #EEEEEE
}
button{
  margin-bottom: 2.5%; 
  display: flex;
  width: 50%;
  margin: 5px;
}
.container {
    padding-top: 3%;
    display: flex;
    flex-direction: column;
    background-color: #EEEEEE;
    align-items: center;
    justify-content: center;
    position: relative;
}
div {
  display: flex;
  justify-content: center;
}
.title{
    color: #0063B8;
    margin-bottom: 2%;
    margin-top: 2%;
    font-size: 200%;
}
.navbar{
padding-bottom: 0;
margin-bottom: 0;
background-color: #ffffff;
box-shadow: 2px 2px #a6a6a6ba;
width: 100%;
border-bottom: 2px solid #A6A6A6;
margin-bottom: 0;
width: 100%;
height: 75px;
padding-top: 3px;
}

.logo{
width: 400px;
margin-left: 3%;
top:0;
position: relative;
}
</style>

<style>
  main{
    background-color: #EEEEEE;
  }
</style>