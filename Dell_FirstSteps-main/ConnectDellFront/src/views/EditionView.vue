<script setup lang="ts">
import axios from "axios";
import type Edition from "@/interfaces/Edition";
import type Event from "@/interfaces/Event";
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import Calendar from "@/components/Calendar.vue";
import ModalForm from "@/components/ModalForm.vue"
import User from "@/interfaces/User";

const route = useRoute();

type editionType = {
    id?: number;
    name: string;
    programName : string;
    description: string;
    startDate?: Date;
    endDate?: Date;
    members: User[];
    events: Event[];
    mode: number;
}

const editionId = +route.params.editionId;
const programId = +route.params.programId;
const userId = ref(+localStorage.getItem('userId')!).value;
const userRole = ref(+localStorage.getItem('userRole')!).value;
const edition = ref<editionType>();
let eventBody: object;
let calendarRefreshId = ref(0);

onMounted(async () => {
  await getEdition(programId, editionId);
  console.log(edition.value);
})

const getEdition = async (programId: number, editionId: number) => {
  await axios
    .get(`https://localhost:5001/Edition/showInfoEdition?idProgram=${programId}&idEdition=${editionId}`)
    .then((response) => {
      edition.value = response.data;
    }).catch((e) => {
      console.error(e);
    })
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

function formatDate(dates: Date) {
  const date = new Date(dates);
  
  return `${date.getMonth() + 1}/${date.getDate()}/${date.getFullYear()}`;
}

function hasEndDate() {
    return edition.value?.endDate == null ? '' : (' - ' + formatDate(edition.value?.endDate));
}

async function handleSubmitForm() {
  console.log("teste")
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
    .then(function (response) {
      return response;
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

</script>

<template>
    <h1>{{ edition?.programName }} - {{ edition?.name }} [{{ modeToString() }}]</h1>
    <p class="date">{{ formatDate(edition?.startDate!) }}{{ hasEndDate() }}</p>
    <p class="description">{{ edition?.description }}</p>
    <button class="dds__button dds__button--primary dds__button--lg" type="button">
        <span class="dds__icon dds__icon--pencil dds__button__icon--start" aria-hidden="true"></span>
        Manage edition
    </button>
    <p>Edition's calendar</p>
    <ModalForm 
      @sendBodyToParent="handlePostBody"
      modal-title="Add Event"
      :edition-users="edition?.members"
      :edition-start-date="edition?.startDate"
      :edition-end-date="edition?.endDate"
    ></ModalForm>
    <Calendar :id="calendarRefreshId" :events="edition?.events" :start-date="edition?.startDate" :end-date="edition?.endDate"></Calendar>
</template>