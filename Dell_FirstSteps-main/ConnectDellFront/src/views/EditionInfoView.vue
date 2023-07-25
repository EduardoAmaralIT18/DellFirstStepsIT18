<template>
<ModalForm modalTitle="Add Event" :editionUsers="data.members"></ModalForm>
</template>

<script setup lang="ts">
import ModalForm from '@/components/ModalForm.vue';
import axios from 'axios';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
const data= ref([]);

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
onMounted(async() => {
    await getMembers();
    console.log(data.memberships);

})

const route = useRoute();
const id = +route.params.id;

</script>