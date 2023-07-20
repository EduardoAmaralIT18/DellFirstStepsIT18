<script setup lang="ts">
import axios from "axios";

const getProgram = async (programId: number, userId: number) =>{
  await axios
      .get(`https://localhost:5001/Program/showInfoProgram?id=${programId}&userId=${userId}`)
      .then((response) =>{

      }).catch((e) => {
        console.error(e);
      })
}

</script>

<template>

</template>

<style scoped>

</style>