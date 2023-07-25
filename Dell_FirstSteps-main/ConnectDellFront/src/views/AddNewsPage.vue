<script setup lang="ts">


import {onMounted, ref} from "vue";
import type Program from "@/interfaces/Program";
import type News from "@/interfaces/News";
import axios from "axios";
import router from "@/router"
const programList = ref<Program[]>();
const newsToBeCreated = ref<News>(
    {
      authorId: 0,
      id: 0,
      image: "",
      programId: 0
    }
);

onMounted(async () => {
  await getPrograms();
})

const getPrograms = async () => {
  await axios
      .get(`https://localhost:5001/Program/getProgramsName`)
      .then((response) => {
        programList.value = response.data;
      }).catch((e) => {
        console.error(e);
      })
}
</script>

<template>
  <form>
    <label for="program"></label>
    <select name="program" v-model="newsToBeCreated.program" required>
      <option :value="program.id" :key="program.id" v-for="program in programList">
        {{ program.name }}
      </option>
    </select>
    <label for="title"></label>
    <input v-model="newsToBeCreated.title" name="title" type="text" required>
    <label for="text"></label>
    <textarea v-model="newsToBeCreated.text" name="text" required></textarea>
  </form>
</template>

<style scoped lang="scss">
form {
  display: flex;
  flex-direction: column;
}
</style>