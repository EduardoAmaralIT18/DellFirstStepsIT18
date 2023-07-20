<script setup lang="ts">
import axios from "axios";
import type Program from "@/interfaces/Program";
import {onMounted, ref} from "vue";
import {useRoute} from "vue-router";
import CardPlus from "@/components/CardPlus.vue";
import Card from "@/components/Card.vue";
import CardEdition from "@/components/CardEdition.vue";

const route = useRoute();
const program = ref<Program>({});
const id = route.params.id
const userId = ref(+localStorage.getItem('userId')).value;
const description = ref<string>();
onMounted(async () => {
  await getProgram(id, userId);
})

const getProgram = async (programId: number, userId: number) => {
  await axios
      .get(`https://localhost:5001/Program/showInfoProgram?id=${programId}&userId=${userId}`)
      .then((response) => {
        program.value = response.data;
      }).catch((e) => {
        console.error(e);
      })
}

const dateHasPassed = (date: string): boolean => {

  const currentDate: Date = new Date();

  const dataInformada: Date = new Date(date);

  return dataInformada < currentDate;

}

function formatDate(dates: Date) {
  const date = new Date(dates);
  return `${date.getMonth() + 1}/${date.getDate()}/${date.getFullYear()}`;
}


</script>

<template>
  <div class="container">
    <h4 class="title">
      {{ program.name }}
    </h4>

    <h4>
      {{ formatDate(program.startDate) }}
    </h4>

    <h4 class="subtitle">
      {{ program.description }}
    </h4>

<!--    <div class="bottomInfo">-->
<!--      <p class="owner">{{ program.owners.length > 1 ? "Owners" : "Owner" }}: &nbsp; </p>-->
<!--      <p class="owner"> {{ commaAnd() }}</p>-->
<!--      <RouterLink style="text-decoration: none" :to="{ name: 'EditProgram', params: { idProgram: cookiesId } }">-->
<!--        <p v-if="isOwner" class="button dds__button dds__button&#45;&#45;primary" type="button">-->
<!--          <img src="../assets/pencil.png" alt="pencil icon" width="19">-->
<!--          Manage Program-->
<!--        </p>-->
<!--      </RouterLink>-->

<!--    </div>-->

    <div class="row">

      <div class="initialCard col-3 dds__mr-4 dds__mb-3">
        <div>
          <CardPlus url="edition"/>
        </div>

        <div class="initialCard col-3 dds__mr-4 dds__mb-3">
          <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3" v-for="item in program.editions" id="editions">
            <CardEdition :key="item.id" :name="item.name" :description="item.description" :id="item.id"/>
          </div>
        </div>
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
