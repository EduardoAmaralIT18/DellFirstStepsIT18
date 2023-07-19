<script setup lang="ts">
    import Select from "../components/Select.vue";
    import axios from "axios";


    import { onMounted, ref } from "vue";

    const usersModel = ref([]);
    const users = ref([String]);

    onMounted(async () => {
      await axios
        .get("https://localhost:5002/Login/getUserList")
        .then((response) => {
          usersModel.value = response.data;
          // console.log(usersModel.value);
        })
        .catch((error) => {
          console.log(error);
        })
        
        usersModel.value.forEach(user => users.value.push(user));
        console.log(users);
    });
</script>

<template>
  <main>
        <select :list="users"></select>
  </main>
</template>