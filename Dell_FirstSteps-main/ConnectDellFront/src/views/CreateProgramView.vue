<template>
<div class="body">
    <GoBackButton class="button" />
    <ProgramForm formName="Create Program"/>
</div>
</template>

<script setup lang="ts">
import ProgramForm from "@/components/ProgramForm.vue";
import GoBackButton from "@/components/GoBackButtonTest.vue";

</script>

<style scoped>
.button {
    margin-left: 10%;
}
</style>