<template>
    <div class="body">
        <GoBackButton class="button" :path="`/myProgram/${id}`" />
        <ProgramEditForm formName="Edit Program"></ProgramEditForm>
    </div>
</template>
 
<script setup lang="ts">
import ProgramEditForm from "@/components/ProgramEditForm.vue";    
import GoBackButton from "@/components/GoBackButton.vue";
import { useRoute } from "vue-router";

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