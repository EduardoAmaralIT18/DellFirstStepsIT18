<script setup lang="ts">
import Card from "./Card.vue";
import CardPlus from "./CardPlus.vue";
import type Program from "@/interfaces/Program";
import {onMounted, ref} from "vue";
import axios from "axios";

// const myPrograms = ref<Program[]>([
//     {id: 3, name: 'coisa', description: 'deu certo porra'},
//   {id: 1, name: 'AAAAAAA', description: 'deu certo porra'},
//   {id: 2, name: '????????', description: 'deu certo porra'}])

const myPrograms = ref<Program[]>([])
const programs = ref<Program[]>([])

onMounted(async () => {
  await getPrograms(1, 0);
})

const getPrograms = async (userId: number, role: number) => {
  await axios
      .get(`https://localhost:5001/Program/getPrograms?idUser=${userId}&role=${role}`)
      .then((response) => {
        myPrograms.value = response.data.myPrograms;
        programs.value = response.data.programs;
  }).catch((e) => {
    console.error(e);
  })
}

function isAdmin() {
  // role = +localStorage.getItem(userRole);
  if (0 == 0) {
    return true;
  }
  return false;
}
</script>

<template>
  <div class="container">
    <h4 class="title">
        Welcome, Nick Light !
    </h4>

    
    <h4 class="subtitle">
        My Programs
    </h4>

    <div class="row">
      <div v-if="isAdmin()">
        <div class="initialCard col-3 dds__mb-3">
          <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3">
            <CardPlus url="createprogram" />
          </div>
        </div>
      </div>

      <div class="initialCard col-3 dds__mr-4 dds__mb-3">
          <div class="card col-lg-12 col-md-12 col-sm-12 dds__mb-3" v-for="item in myPrograms" id="my-programs">
            <Card :name="item.name" :description="item.description"/>
          </div>
      </div>
    </div>

    <h4 class="subtitle">
        Programs
    </h4>

    <div class="initialCard col-3 dds__mr-4 dds__mb-3">
      <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3" v-for="item in programs" id="programs">
        <Card :name="item.name" :description="item.description"/>
      </div>
    </div>
  </div>
</template>

<style scoped>
body {
  font-family: 'Roboto', sans-serif;
}

.container {
  padding-top: 5%;
  padding-left: 15%;
  display: inline-flex;
  flex-direction: column;
}

.title {
  margin-left: 0px !important;
  text-align: left;
  color: #0672CB;
  margin: 2.5%;
  font-weight: bold;
}

.subtitle {
  margin-left: 0px !important;
  text-align: left;
  color: #0672CB;
  margin: 2.5%;
}

.message {
  text-align: center;
  color: #0672CB;
  margin-top: 5%;
  font-size: 1.5rem;
}

.row {
  display: flex;
  gap: 16px;
  flex-wrap: wrap;
}

.dds__icon__search {
  color: #0672CB;
  font-size: 1.5rem;
  font-weight: bold;
  padding-right: 1%;
}

.link {
  color: #0672CB;
  font-size: 15px;
  position: absolute;
  bottom: 0;
  text-align: center;
  left: 0;
  margin-left: 20px;
  margin-top: 10px;
  padding-bottom: 17px;
}

.addProgramIcon {
  color: #0672CB;
  text-align: center;
  font-size: 89px;
  padding-top: 40%;
  padding-bottom: 35px;
  text-decoration: none;
}

.initialCard {
  display: flex;
  gap: 16px;
  flex-wrap: wrap;
  
}
</style>
