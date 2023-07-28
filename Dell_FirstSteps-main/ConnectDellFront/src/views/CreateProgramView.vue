<script setup lang="ts">
import ProgramForm from "@/components/ProgramForm.vue";
import GoBackButton from "@/components/GoBackButton.vue";






function activateButton(): boolean {
    if (new Date(this.programInfo.endDate!) <= new Date(this.programInfo.startDate) || this.checkName() || this.checkOwners() || this.checkDescription())
        return true;
    return false;
},


</script>

<template>
    <div class="body">
        <GoBackButton class="button" path="/home" />
        <ProgramForm formName="Create Program" />
    </div>
</template>

<style scoped>
.button {
    margin-left: 20%;
}

.body {
    margin-top: 5%;
}
</style>