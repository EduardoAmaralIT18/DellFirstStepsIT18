<script setup lang="ts">
import axios from "axios";
import type Edition from "@/interfaces/Edition";
import type Event from "@/interfaces/Event";
import { onMounted, ref, watch, provide } from "vue";
import { useRoute } from "vue-router";
import Calendar from "@/components/Calendar.vue";
import ModalForm from "@/components/ModalForm.vue"
import User from "@/interfaces/User";
import GoBackButton from "@/components/GoBackButton.vue";
const route = useRoute();


type editionType = {
  id?: number;
  name: string;
  programName: string;
  description: string;
  startDate?: string;
  endDate?: string;
  members: User[];
  interns: User[];
  events: Event[];
  mode: number;
}

const editionId = +route.params.id;
const userRole = ref(+localStorage.getItem('userRole')!);
const edition = ref<editionType>();
const loading = ref(false);
let eventBody: object;
let calendarRefreshId = ref(0);

onMounted(async () => {
  await getEdition(editionId);
  loading.value = true;
})
const getEdition = async (editionId: number) => {
  await axios
    .get(`https://localhost:5001/Edition/showInfoEdition?idEdition=${editionId}`)
    .then((response) => {
      edition.value = response.data;
    }).catch((e) => {
      console.error(e);
    })
  console.log(edition.value?.events)
}


function modeToString() {
  switch (edition.value?.mode) {
    case 0:
      return "REMOTE"
    case 1:
      return "HYBRID"
    case 2:
      return "IN-OFFICE"
  }
}

function formatDate(dates: string) {
  const date = new Date(dates);

  return `${date.getMonth() + 1}/${date.getDate()}/${date.getFullYear()}`;
}

function hasEndDate() {
  return edition.value?.endDate == null ? '' : (' - ' + formatDate(edition.value?.endDate));
}

async function handleSubmitForm() {
  await axios
    .post("https://localhost:5001/event/addEvent", {
      name: eventBody.eventTitle,
      peopleInvolved: eventBody.peopleInvolved,
      startDate: eventBody.startDate,
      endDate: eventBody.endDate,
      where: eventBody.location,
      eventType: eventBody.eventType,
      editionId: editionId,
    })
    .then(async function () {
      await getEdition(3241, editionId);
      window.location.reload();
    })
    .catch((error) => {
      alert("Não foi possível atender a solicitação.");
    });
}

const handlePostBody = (body: Object) => {
  eventBody = body;
  handleSubmitForm();
  calendarRefreshId.value++;
};

let dates = ref();
let receiveDate = (body: object) => {
  dates.value = body;
};

let toggleEditClick = ref(false);
const openModalEdit = () => {
  toggleEditClick.value = true;
}
const closeModalEdit = (teste: Boolean) => {
  toggleEditClick.value = false;
}

</script>

<template>
  <div v-if="loading" class="container">
    <GoBackButton class="button" path="/home" />
    <div class="calendar">
      <div class="cont">
        <p class="title">{{ edition?.programName }} - {{ edition?.name }} [{{ modeToString() }}]</p>
        {{ console.log(edition?.id) }}
        <RouterLink :to="`/manageEdition/${edition?.id}`">
          <button v-if="userRole === 0" class="dds__button dds__button--primary dds__button--lg" type="button">
            <span class="dds__icon dds__icon--pencil dds__button__icon--start" aria-hidden="true"></span>
            Manage edition
          </button>
        </RouterLink>
      </div>
      <p class="date">{{ formatDate(edition?.startDate!) }}{{ hasEndDate() }}</p>
      <p class="description">{{ edition?.description }}</p>
      <br>
    </div>
    <div class="calendar">
      <p class="title">Edition's calendar</p>
      <div class="buttons">
        <button @click="openModalEdit" v-if="userRole === 0" class="dds__button dds__button--primary dds__button--lg"
          type="button">
          Add Event
        </button>
        <ModalForm v-if="toggleEditClick" @closeModal="closeModalEdit" class="modalbutton" buttonText="Add Event"
          @sendBodyToParent="handlePostBody" modal-title="Add Event"
          :edition-users="edition?.members.concat(edition?.interns)" :editionStartDate="edition?.startDate"
          :editionEndDate="edition?.endDate">
        </ModalForm>
      </div>
      <Calendar :id="calendarRefreshId" :events="edition?.events" :start-date="edition?.startDate"
        :end-date="edition?.endDate" :editionUsers="edition?.members.concat(edition?.interns)" @sendDate="receiveDate">
      </Calendar>
    </div>
  </div>

  <div v-else class="loading">
    <div class="dds__loading-indicator">
      <div class="dds__loading-indicator__label">Loading...</div>
      <div class="dds__loading-indicator__spinner"></div>
    </div>
  </div>
</template>

<style scoped>
.loading {
  display: flex;
  margin: 23%;
  justify-content: center;
}

.cont {
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.container {
  display: flex;
  flex-direction: column;
  margin: 4em;
  min-width: 600px;
  gap: 20px;
  justify-content: center;
}

.title {
  color: #0672cb;
  font-size: 190%;
  text-align: left;
  font-weight: bold;
  letter-spacing: 2px;
}

.buttons {
  gap: 20px;
  display: flex;
  align-self: flex-end;
}

.calendar {
  display: flex;
  flex-flow: column wrap;
  margin: 0em 7%;
}

.date {
  text-align: left;
  font-size: 13px;
  color: #7e7e7e;
}

.description {
  text-align: justify;
  padding-right: 30px;
  left: 0;
  position: relative;
}

.dds__button {
  align-self: flex-end;
}
</style>