<template>
  <div class="signin-page" id="container">
    <h1 class="signIn">Sign In</h1>
    <Select id="select" :list="users" @selectValue="handleClick"></Select>
  </div>
</template>

<script setup lang="ts">
    import Select from "../components/Select.vue";
    import axios from "axios";
    import { onMounted, ref } from "vue";
    import Header from "../components/Header.vue";
import router from "@/router";

    type User = {
      id: number;
      name: string;
      email: string;
      role: number;
    }
    
    const usersModel = ref([]);
    const users = ref<User[]>();

    onMounted(async () => {
      await axios
        .get("https://localhost:5001/Login/getUserList")
        .then((response) => {
          usersModel.value = response.data;
          
        })
        .catch((error) => {
          console.log(error);
        })
        
        users.value = usersModel.value.map(user => user.email);
    });

    function handleClick(email: string) {
        const user = usersModel.value.find(element => element.email === email);
        localStorage.setItem("name", user.name);
        localStorage.setItem("id", user.id);
        localStorage.setItem("email", user.email);
        localStorage.setItem("role", user.role);
        router.push("/Home")
      }
</script>

<style>
  .signIn {
    color:  #0063b8;
    font-size: 200%;
    font-weight: 400;
  }
  #container {
    font-family: Roboto;
    margin-top: 300px;
    display: flex;
    flex-direction: column;
    align-items: center; 
  }

  #select {
    width: 50%
  }

</style>

