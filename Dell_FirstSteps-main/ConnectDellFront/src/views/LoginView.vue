<template>
  <div class="signin-page">
    <h1>Sign In</h1>
    <Select :list="users" @selectValue="handleClick"></Select>
  </div>
</template>

<script setup lang="ts">
    import Select from "../components/Select.vue";
    import axios from "axios";
    import { onMounted, ref } from "vue";

    const usersModel = ref([]);
    const users = ref([]);

    onMounted(async () => {
      await axios
        .get("https://localhost:5002/Login/getUserList")
        .then((response) => {
          usersModel.value = response.data;
          
        })
        .catch((error) => {
          console.log(error);
        })
        
        users.value = usersModel.value.map(user => user.email);
        console.log(users.value);
    });
</script>

<style>

</style>

<script lang="ts">
  import router from "@/router";

  export default {
    methods: {
      handleClick(email: string) {
        console.log("email", email);
      }
    }
  }
</script>

