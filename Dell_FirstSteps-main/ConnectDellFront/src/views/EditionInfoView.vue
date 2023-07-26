<script setup lang="ts">
import ModalForm from "@/components/ModalForm.vue";
import axios from "axios";
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";

const data = ref([]);
let eventBody: object;

onMounted(async () => {
  await getMembers();
  await getEventToUpdate();
});

const route = useRoute();
const id = +route.params.id;

const handlePostBody = (body: Object) => {
  eventBody = body;
  handleSubmitForm();
};

async function handleClick() {
  await axios
    .get("https://localhost:5001/edition/getUsersNotAdmin")
    .then((response) => {
      data.value = response.data;
    })
    .catch((error) => {
      alert("Não foi possível atender a solicitação.");
    });
}

async function getMembers() {
  await axios
    .get(
      `https://localhost:5001/edition/showInfoEdition?idProgram=0&idEdition=${id}`
    )
    .then((response) => {
      data.value = response.data;
    })
    .catch((error) => {
      alert("Não foi possível atender a solicitação.");
    });
}

//TO-DO Passar pra modal e ficar pré preenchido e deixar o id do evento dinâmico
async function getEventToUpdate() {
  await axios
    .get(`https://localhost:5001/event/getEventToUpdate?eventId=23`)
    .then((response) => {
      console.log(response.data);
      data.value = response.data;
    })
    .catch((error) => {
      console.log(error.response);
      alert("Não foi possível atender a solicitação.");
    });
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
      editionId: id,
    })
    .then(function (response) {
      return response;
    })
    .catch((error) => {
      alert("Não foi possível atender a solicitação.");
    });
}
</script>

<template>
  <!-- <ModalForm
    @sendBodyToParent="handlePostBody"
    modalTitle="Add Event"
    :editionUsers="data.members"
    :editionStartDate="data.startDate"
    :editionEndDate="data.endDate"
  /> -->

  <ModalForm
    @sendBodyToParent="handlePostBody"
    modalTitle="Edit Event"
    :editionUsers="data.members"
    :editionStartDate="data.startDate"
    :editionEndDate="data.endDate"
  />
</template>
