<script setup lang="ts">
import axios from "axios";
import type Program from "@/interfaces/Program";
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import CardPlus from "@/components/CardPlus.vue";
import CardEdition from "@/components/CardEdition.vue";
import User from "@/interfaces/User";

const route = useRoute();
const program = ref<Program>({
  name: '',
  description: '',
  owners: [],
  isBasic: true,
  startDate: new Date()
});
const ownerList = ref<string>('');
const id = +route.params.id
const userId = ref(+localStorage.getItem('userId')!).value;
const userRole = ref(+localStorage.getItem('userRole')!).value;
onMounted(async () => {
  await getProgram(id, userId);
  defineOwnerList();
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

function formatDate(dates: Date) {
  const date = new Date(dates);
  return `${date.getMonth() + 1}/${date.getDate()}/${date.getFullYear()}`;
}

function getLastElement(array: any[]) {
  if (!Array.isArray(array) || array.length === 0) {
    return undefined;
  }
  return array[array.length - 1];
}

const ownersFormatter = (owners: User[]) => {
    if (owners.length === 1) return `${owners[0].name}`

    let lastUserName = getLastElement(owners).name;
    let text = '';

    text += owners[0].name;
    for (let i = 1; i < owners.length - 1; i++) {
        text +=  ', ' + owners[i].name
    }

    text += (' and ' + lastUserName)
    return text;
}
const defineOwnerList = () => {
  ownerList.value = ownersFormatter(program.value.owners)
}

function isOwner() {
  return program.value.owners.some(owner => owner.id === userId);
}

function isAdmin() {
  if (userRole == 0) {
    return true;
  }
  return false;
}

</script>

<template>
  <div class="container">
    <h2 class="title">
      {{ program.name }}
    </h2>

    <p class="date">
      {{ formatDate(program.startDate!) }}
    </p>

    <p class="description">
      {{ program.description }}
    </p>

    <div class="bottomInfo">
      <div class="owner">
        <p> {{ program.owners.length > 1 ? "Owners:&nbsp" : "Owner:&nbsp" }} </p>
        <p> {{ ownerList }}</p>
      </div>
      <div v-if="isOwner()">
        <RouterLink style="text-decoration: none" :to="`/editProgram/${id}`">
          <p class="manageProgram button dds__button dds__button&#45;&#45;primary" type="button">
            <img src="../assets/pencil.png" alt="pencil icon" width="19">
            Manage Program
          </p>
        </RouterLink>
      </div>

    </div>

    <div class="row">
      <div class="initialCard col-3 dds__mr-4 dds__mb-3">
        <div v-if="isAdmin()">
          <CardPlus url="edition" />
        </div>

        <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3" v-for="item in program.editions" id="editions">
          <CardEdition :key="item.id" :name="item.name" :description="item.description" :id="item.id"
            :start-date="item.startDate" :end-date="item.endDate" />
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
  padding-top: 3%;
  padding-left: 15%;
  display: flex;
  flex-direction: column;
  max-width: 1630px;
}

.title {
  color: #0672CB;
  font-size: 190%;
  text-align: left;
  margin-top: 55px;
  font-weight: bold;
}

.date {
  text-align: left;
  font-size: 13px;
  color: #7E7E7E;
}

.description {
  text-align: justify;
  padding-right: 30px;
  left: 0;
  position: relative;
}

.description a {
  color: #0672CB;
  font-size: 15px;
}


.row {
  display: flex;
  gap: 2rem;
  flex-wrap: wrap;
  margin-top: 2rem;
}

.initialCard {
  display: flex;
  gap: 16px;
  flex-wrap: wrap;
}

.bottomInfo {
  display: flex;
  justify-content: space-between;
  padding-right: 30px;
}

.owner {
  text-align: left;
  font-size: 14px;
  color: #7E7E7E;
  margin-top: 1%;
  display: flex;
  float: left;
  font-weight: 590;
}

.manageProgram {
  display: flex;
  flex-direction: row;
  gap: 10px;
}
</style>
