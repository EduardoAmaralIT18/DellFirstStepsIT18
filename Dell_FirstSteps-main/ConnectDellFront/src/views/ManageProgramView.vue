<template>
    <div class="body">
        <GoBackButton class="button" :path="`/myProgram/${id}`" />
        <ManageProgramForm formName="Manage Program"></ManageProgramForm>
    </div>
</template>
 
<script setup lang="ts">  
import GoBackButton from "@/components/GoBackButton.vue";
import { useRoute } from "vue-router";
import ManageProgramForm from "@/components/ManageProgramForm.vue";

const route = useRoute()
const id = +route.params.id

</script>

<style scoped>
.button {
    margin-left: 20%;
}

.body {
    margin-top: 5%;
}
</style>