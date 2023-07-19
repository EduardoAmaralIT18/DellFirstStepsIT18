<script setup lang="ts">
import Card from "./Card.vue"
import type Program from "@/interfaces/Program";
import {onMounted, ref} from "vue";
import axios from "axios";

// const myPrograms = ref<Program[]>([
//     {id: 3, name: 'coisa', description: 'deu certo porra'},
//   {id: 1, name: 'AAAAAAA', description: 'deu certo porra'},
//   {id: 2, name: '????????', description: 'deu certo porra'}])

const myPrograms = ref<Program[]>([])

onMounted(async () => {
  await getPrograms(1, 0);
})

const getPrograms = async (userId: number, role: number) => {
  await axios
      .get(`https://localhost:5001/Program/getPrograms?idUser=${userId}&role=${role}`)
      .then((response) => {
        myPrograms.value = response.data.myPrograms;
  }).catch((e) => {
    console.error(e);
  })
}
</script>

<template>
    <div v-for="item in myPrograms" id="my-programs">
      <Card :name="item.name" :description="item.description"/>
    </div>
    <div v-for="item in this.programs" id="programs">
      <Card :name="item.name" :description="item.description"/>
    </div>
</template>

<style>
</style>
