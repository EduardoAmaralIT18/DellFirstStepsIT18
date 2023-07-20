<template>
    <div class="container">
        <h2 class="title">{{ formName }}</h2>
        <TextInput boxName="Program Name"></TextInput>
        <div class="date-container">
            <DatePicker boxName="Start Date"></DatePicker>
            <DatePicker boxName="End Date"></DatePicker>
        </div>
        <Dropdown boxName="Owners"></Dropdown>
        <TextArea boxName="Description"></TextArea>
        <PrimaryButton class="submitButton" name="Submit"></PrimaryButton>
    </div>
</template>

<script setup lang="ts">
import PrimaryButton from "./PrimaryButton.vue";
import TextInput from "./TextInput.vue"
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue";
import TextArea from "./TextArea.vue"
import "@dds/components/src/scss/dds-fonts.scss";

const props = defineProps({
  formName: String
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
.title {
  color: #0063B8;
  font-size: 200%;
  font-weight: 500;
  text-align: center;
}
.submitButton {
  margin-top: 30px;
}
</style>