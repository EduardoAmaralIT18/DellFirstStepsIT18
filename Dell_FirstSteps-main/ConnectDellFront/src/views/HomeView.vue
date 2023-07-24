<script setup lang="ts">
import Card from "../components/Card.vue";
import CardPlus from "../components/CardPlus.vue";
import type Program from "@/interfaces/Program";
import {onMounted, ref} from "vue";
import axios from "axios";

const myPrograms = ref<Program[]>([])
const programs = ref<Program[]>([])
const username = ref(localStorage.getItem('userName'))
const role = ref(+localStorage.getItem('userRole')!).value;
const id = ref(+localStorage.getItem('userId')!).value;

onMounted(async () => {
  await getPrograms(id, role);
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
  if (role === 0) {
    return true;
  }
  return false;
}
</script>


<template>
  <div class="container">
    <h4 class="title">
      Welcome, {{ username }}
    </h4>

    <h4 class="subtitle" v-if="myPrograms.length > 0">
      My Programs
    </h4>

    <div class="row">
      <div class="initialCard col-3 dds__mr-4 dds__mb-3">
        <div v-if="isAdmin()">
          <CardPlus url="/createprogram"/>
        </div>
        
        <div class="card col-lg-12 col-md-12 col-sm-12 dds__mb-3" v-for="item in myPrograms" id="my-programs">
          <Card :key="item.id" :name="item.name" :description="item.description" :id="item.id" :isBasic="false" :endDate="item.endDate" :startDate="item.startDate"/>
        </div>
      </div>
    </div>

    <h4 class="subtitle">
      Programs
    </h4>

    <div class="initialCard col-3 dds__mr-4 dds__mb-3">
      <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3" v-for="item in programs" id="programs">
        <Card :key="item.id" :name="item.name" :description="item.description" :id="item.id" :isBasic="true" :endDate="item.endDate" :startDate="item.startDate"/>
      </div>
    </div>
  </div>
</template>

<style scoped>
.container {
  padding-top: 5%;
  padding-left: 15%;
  display: inline-flex;
  flex-direction: column;
}

.title {
  margin-left: 0px;
  text-align: left;
  color: #0672CB;
  margin: 2.5%;
  font-weight: bold;
}

.subtitle {
  margin-left: 0px;
  text-align: left;
  color: #0672CB;
  margin: 2.5%;
}

.row {
  display: flex;
  gap: 16px;
  flex-wrap: wrap;
}

.initialCard {
  display: flex;
  gap: 16px;
  flex-wrap: wrap;
}

h4.title, h4.subtitle {
  margin-left: 0;
}
</style>