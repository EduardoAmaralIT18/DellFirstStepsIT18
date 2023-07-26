<template>
<ModalForm @sendBodyToParent="handlePostBody" modalTitle="Add Event" :editionUsers="data.members" :editionStartDate="data.startDate" :editionEndDate="data.endDate"></ModalForm>
</template>

<script setup lang="ts">
import ModalForm from '@/components/ModalForm.vue';
import axios from 'axios';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
const data= ref([]);
let eventBody:object;
const handlePostBody = (body: Object) =>{eventBody=body;console.log("body",eventBody); handleSubmitForm()}
async function handleClick() {
            await axios
                .get('https://localhost:5001/edition/getUsersNotAdmin')
                .then((response) => {console.log(response.data)
                data.value=response.data;
            })
                .catch((error) => {
                alert("Não foi possível atender a solicitação.");
            });
        }
async function getMembers(){
            await axios .get(`https://localhost:5001/edition/showInfoEdition?idProgram=0&idEdition=${id}`)
            .then((response) => {console.log(response.data)
                data.value=response.data
            })
            .catch((error) => {
                alert("Não foi possível atender a solicitação.");
            });
        }
async function handleSubmitForm(){
    console.log("cheguei no post")
    await axios .post("https://localhost:5001/event/addEvent", {
          name: eventBody.eventTitle,
          peopleInvolved: eventBody.peopleInvolved,
          startDate: eventBody.startDate,
          endDate: eventBody.endDate,
          where: eventBody.location,
          eventType: eventBody.eventType,
          editionId: data.editionId,
        })
        .then(function (response) {
          console.log("1",response.data)
          return response;
        })
        .catch((error) => {
                console.log(error)
                alert("Não foi possível atender a solicitação.");
        });
}
onMounted(async() => {
    await getMembers();
})



const route = useRoute();
const id = +route.params.id;

</script>