<template>
<ModalForm modalTitle="Add Event" :editionUsers="data"></ModalForm>
</template>

<script setup lang="ts">
import ModalForm from '@/components/ModalForm.vue';
import axios from 'axios';
import { onMounted, ref } from 'vue';
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
onMounted(async() => {
    await handleClick();
})

</script>