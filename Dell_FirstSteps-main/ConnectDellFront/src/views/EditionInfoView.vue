<script setup lang="ts">
import ModalForm from "@/components/ModalForm.vue";
import axios from "axios";
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";

const event = ref([]);
const edition = ref([]);
const editMode = ref(true);
let eventBody: object;

onMounted(async () => {
  await getMembers();
  await getEventToUpdate();
});

const route = useRoute();
const editionId = +route.params.id;

const handlePostBody = (body: Object) => {
  eventBody = body;
  handleSubmitForm();
};

async function getMembers() {
  await axios
    .get(
      `https://localhost:5001/edition/showInfoEdition?idProgram=0&idEdition=${editionId}`
    )
    .then((response) => {
      console.log("members", response.data);
      edition.value = response.data;
      // data.value = response.data;
    })
    .catch((error) => {
      alert("Não foi possível atender a solicitação.");
    });
}

//TO-DO Passar pra modal e ficar pré preenchido e deixar o id do evento
async function getEventToUpdate() {
  await axios
    .get(`https://localhost:5001/event/getEventToUpdate?eventId=23`)
    .then((response) => {
      console.log(response.data);
      event.value = response.data;
    })
    .catch((error) => {
      console.log(error.response);
      alert("Não foi possível atender a solicitação.");
    });
}

async function handleSubmitForm() {
  if (!editMode) {
    return await axios
      .post("https://localhost:5001/event/addEvent", {
        name: eventBody.eventTitle,
        peopleInvolved: eventBody.peopleInvolved,
        startDate: eventBody.startDate,
        endDate: eventBody.endDate,
        where: eventBody.location,
        eventType: eventBody.eventType,
        editionId: id,
      })
      .then(function (response) {
        return response;
      })
      .catch((error) => {
        alert("Não foi possível atender a solicitação.");
      });
  }

  if (editMode) {
    return await axios
      .post("https://localhost:5001/event/updateEvent", {
        id: 23,
        name: eventBody.eventTitle,
        eventType: eventBody.eventType,
        peopleInvolved: eventBody.peopleInvolved,
        startDate: eventBody.startDate,
        endDate: eventBody.endDate,
        where: eventBody.location,
      })
      .then(function (response) {
        console.log("editou evento");
        getEventToUpdate();
        return response;
      })
      .catch((error) => {
        alert("Não foi possível atender a solicitação.");
      });
  }
}
</script>

<template>
  <div v-if="editMode">
    <ModalForm
      @sendBodyToParent="handlePostBody"
      modalTitle="Add Event"
      :editionUsers="edition.members"
      :eventStartDate="event.startDate"
      :eventEndDate="event.endDate"
    />
  </div>

  <div v-else="editMode">
    <ModalForm
      editMode="editMode"
      @sendBodyToParent="handlePostBody"
      modalTitle="Edit Event"
      :eventTitle="event.name"
      :eventType="event.eventType"
      :peopleInvolved="event.peopleInvolved"
      :location="event.where"
      :editionUsers="edition.members"
      :eventStartDate="event.startDate"
      :eventEndDate="event.endDate"
    />
  </div>
</template>
