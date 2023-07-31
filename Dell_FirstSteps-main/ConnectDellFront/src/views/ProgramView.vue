<script setup lang="ts">
import axios from "axios";
import {onMounted, ref} from "vue";
import {useRoute} from "vue-router";
import CardEdition from "@/components/CardEdition.vue";
import User from "@/interfaces/User";
import ProgramInfo from "@/interfaces/ProgramInfo";
import router from "@/router";

const route = useRoute();
const program = ref<ProgramInfo>({
  name: '',
  description: '',
  startDate: '',
  editions: [],
  owners: []
});
const ownerList = ref<string>('');
const id = +route.params.id
const userId = ref(+localStorage.getItem('userId')!).value;
onMounted(async () => {
  await getSimpleProgram(id);
  defineOwnerList();
})

const getSimpleProgram = async (programId: number) => {
  await axios
      .get(`https://localhost:5001/Program/showBasicInfo?id=${programId}`)
      .then((response) => {
        program.value = response.data;
      }).catch((e) => {
        console.error(e);
        router.push('/notFound')
      })
}

function formatDate(dates: string) {
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
    text += ', ' + owners[i].name
  }

  text += (' and ' + lastUserName)
  return text;
}
const defineOwnerList = () => {
  ownerList.value = ownersFormatter(program.value.owners)
}


</script>

<template>
  <div class="container">
    <h2 class="title">
      {{ program.name }}
    </h2>

    <p class="date">
      {{ formatDate(program.startDate) }}
    </p>

    <p class="description">
      {{ program.description }}
    </p>

    <div class="bottomInfo">
      <div class="owner">
        <p> {{ program.owners.length > 1 ? "Owners:&nbsp" : "Owner:&nbsp" }} </p>
        <p> {{ ownerList }}</p>
      </div>
    </div>

    <div class="row">
      <div class="initialCard col-3 dds__mr-4 dds__mb-3">
        <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3" v-for="item in program.editions" id="editions">
          <CardEdition :key="item.id" :id="item.id" :name="item.name" :numberOfInterns="item.numberOfInterns" :members="item.members" :description="item.description" 
            :curriculum="item.curriculum" :mode="item.mode" :start-date="item.startDate" :end-date="item.endDate" :program="item.program"/>
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
  padding-left: 5%;
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
</style>
