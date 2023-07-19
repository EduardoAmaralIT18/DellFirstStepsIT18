
<template>
    <div class="container">
        <TextInput boxName="Program Name"></TextInput>
        <div class="date-container">
            <DatePicker boxName="Start Date"></DatePicker>
            <DatePicker boxName="End Date"></DatePicker>
        </div>
        <TextArea boxName="Description"></TextArea>
    </div>
    <SubmitButton />
</template>

<script setup lang="ts">
import { PropType } from "vue";
import SubmitButton from "./SubmitButton.vue";
import TextInput from "./TextInput.vue"
import DatePicker from "./DatePicker.vue";
import TextArea from "./TextArea.vue"
import "@dds/components/src/scss/dds-fonts.scss";
const props = defineProps({
  boxName: String
});
</script>


<style scoped>
.container{
    margin-left: 10%;
    margin-right: 10%;
}
.date-container{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}
</style>

