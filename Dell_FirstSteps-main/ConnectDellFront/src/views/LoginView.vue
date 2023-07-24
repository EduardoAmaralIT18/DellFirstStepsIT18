<template>
  <div class="signin-page">
    <h1 class="signIn">Sign In</h1>
    <Select id="select" :list="getEmails()" @selectValue="handleClick"></Select>
  </div>
</template>

<script setup lang="ts">
import Select from "../components/Select.vue";
import axios from "axios";
import { onMounted, ref } from "vue";
import router from "@/router";
import User from "@/interfaces/User";

const mappedData = ref<User[]>([]);

onMounted(async () => {
  await axios
    .get<User[]>("https://localhost:5001/Login/getUserList")
    .then((response) => {
      mappedData.value = response.data.map((item) => {
        const { id, name, email, role } = item;
        return { id, name, email, role };
      });
    })
    .catch((error) => {
      console.log(error);
    });
});

function getEmails() {
  return mappedData.value.map((user) => user.email);
}

function handleClick(email: string) {
  const user = mappedData.value.find((element) => element.email === email)!;
  localStorage.setItem("userName", user.name);
  localStorage.setItem("userId", user.id.toString());
  localStorage.setItem("userEmail", user.email ?? "");
  localStorage.setItem("userRole", user.role.toString());
  router.push("/home");
}
</script>

<style>
.signIn {
  color: #0063b8;
  font-size: 200%;
  font-weight: 400;
}
.signin-page {
  font-family: Roboto;
  height: 100%;
  padding-top: 10%;
  display: flex;
  flex-direction: column;
  align-items: center;
  /* background-color: salmon; */
}

#select {
  min-width: auto;
  margin: 2%;
}
</style>
