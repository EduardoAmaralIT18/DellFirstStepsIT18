<script setup lang="ts">
import ProgramForm from "@/components/ProgramForm.vue";
import GoBackButton from "@/components/GoBackButton.vue";
</script>

<template>
    <div class="body">
        <GoBackButton class="button" path="/home" />
        <ProgramForm formName="Create Program"/>
    </div>
</template>

<style scoped>
.button {
    margin-left: 10%;
}

.body {
    margin-top: 5%;
}
</style>