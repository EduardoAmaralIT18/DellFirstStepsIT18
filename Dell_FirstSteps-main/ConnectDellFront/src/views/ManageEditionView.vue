<script setup lang="ts">
import ManageEditionForm from "@/components/ManageEditionForm.vue";
import GoBackButton from "@/components/GoBackButton.vue";
import { useRoute } from "vue-router";

const route = useRoute();
const id = +route.params.id;

</script>

<template>
    <div class="body">
        <GoBackButton class="button" :path="`/editionInfo/${id}`" />
        <ManageEditionForm form-name="Manage Edition" />
    </div>
</template>

<style scoped>
.button {
    margin-left: 20%;
}

.body {
    margin-top: 5%;
    margin-bottom: 10%;
}
</style>