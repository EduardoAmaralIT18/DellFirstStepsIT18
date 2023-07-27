<template>
    <GoBackButton class="button" path="/home" />
    <ProgramEditForm formName="Edit Program"></ProgramEditForm>
</template>
 
<script setup lang="ts">
    import ProgramEditForm from "@/components/ProgramEditForm.vue";
    
    import GoBackButton from "@/components/GoBackButton.vue";
    import ProgramForm from "@/components/ProgramForm.vue";
</script>