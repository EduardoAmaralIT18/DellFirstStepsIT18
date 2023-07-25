<script setup lang="ts">
import EditionForm from "@/components/EditionForm.vue";
import GoBackButton from "@/components/GoBackButton.vue";
import { useRoute } from "vue-router";

const route = useRoute();
const id = +route.params.id;

</script>

<template>
    <div class="body">
        <GoBackButton class="button" path="/home" />
        <EditionForm formName="Create Edition" v-bind:programId="id"/>
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