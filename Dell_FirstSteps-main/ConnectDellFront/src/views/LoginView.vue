<template>
  <div class="signin-page">
    <h1>Sign In</h1>
    <Select :list="users" />
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
        
        users.value = usersModel.value.map(user => user.name);
        console.log(users.value);
        // usersModel.value.forEach(user => {
        //   users.value.push(user.name);
        // });
    });
</script>

