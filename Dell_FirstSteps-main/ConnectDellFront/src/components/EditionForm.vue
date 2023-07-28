<script setup lang="ts">
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import axios from "axios";
import { onMounted, ref } from "vue";

import TextInput from "./TextInput.vue";
import NumberInput from "./NumberInput.vue";
import Select from "./Select.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue";
import TextArea from "./TextArea.vue";
import PrimaryButton from "./PrimaryButton.vue";
import Edition from "@/interfaces/Edition";
import User from "@/interfaces/User";

const editionInfo = ref<Edition>({
  id: 0,
  name: '',
  numberOfInterns: 0,
  members: [],
  description: '',
  curriculum: '',
  mode: -1,
  startDate: new Date().toISOString().slice(0, 10),
  endDate: '',
  program: 0,
  programName: ''
});
const workModel = ref<string[]>(['Remote', 'Hybrid', 'InOffice'])
const internList = ref<User[]>([])
const nameList = ref<string[]>([])

const props = defineProps<{
  formName: String,
  programId: Number
}>();

onMounted(() => {
  getUsersNotAdmin();
  getEditionsNames();
});

const handleInput = (text: string) => {
  editionInfo.value.name = text
}

const handleNumber = (value: number) => {
  editionInfo.value.numberOfInterns = value
}

const handleStartDate = (date: string) => {
  editionInfo.value.startDate = date
}

const handleEndDate = (date: string) => {
  editionInfo.value.endDate = date
}

const handleDropdown = (internId: number[]) => {
  editionInfo.value!.members = [];

  internList.value.forEach(intern => {
    if (internId.some(id => id === intern.id)) {
      editionInfo.value!.members.push(intern)
    }
  })
}

const handleSelect = (workMode: string) => {
  console.log(workModel.value.indexOf(workMode))
  editionInfo.value.mode = workModel.value.indexOf(workMode)
}

const handleDescription = (text: string) => {
  editionInfo.value.description = text;
}

const handleCurriculum = (text: string) => {
  editionInfo.value.curriculum = text;
}

const handleClick = async () => {
  await axios
    .post(`https://localhost:5001/edition/addEdition`, {
      name: editionInfo.value.name.trim(),
      numberOfInterns: editionInfo.value.numberOfInterns,
      members: editionInfo.value.members,
      startDate: editionInfo.value.startDate,
      endDate: editionInfo.value.endDate,
      mode: editionInfo.value.mode,
      description: editionInfo.value.description.trim(),
      curriculum: editionInfo.value.curriculum!.trim(),
      program: props.programId
    })
    .then(() => {
      alert("Solicitação atendida com sucesso!");
    })
    .catch((error) => {
      alert("Não foi possível atender a solicitação.");
    });
}

const getUsersNotAdmin = async () => {
  await axios
    .get("https://localhost:5001/edition/getUsersNotAdmin")
    .then((response) => {
      internList.value = response.data;
    })
    .catch((error) => {
      console.log(error);
    });
}

const getEditionsNames = async () => {
  await axios
    .get("https://localhost:5001/edition/getEditionsNames")
    .then((response) => {
      nameList.value = response.data;
    })
    .catch((error) => {
      console.log(error)
    });
}

const disableButton = () => {
  if (editionInfo.value.endDate == undefined) {
    return true;
  }

  if (new Date(editionInfo.value.endDate!) > new Date(editionInfo.value.startDate!) && checkName() && checkMode() && checkNumberOfInterns() && checkMembers() && checkDescription() && checkCurriculum()) {
    return false;
  }
  return true;
}

const checkName = () => {
  if (editionInfo.value.name.length >= 5 && editionInfo.value.name.length <= 50) {
    return true
  }

  return false;
}

const checkMode = () => {
  if (editionInfo.value.mode >= 0) {
    return true
  }

  return false
}

const checkNumberOfInterns = () => {
  if (editionInfo.value.numberOfInterns >= 1 && editionInfo.value.numberOfInterns <= 21) {
    return true
  }
  return false;
}

const checkMembers = () => {
  if (editionInfo.value.members.filter(usr => usr.role == 1).length !== editionInfo.value.numberOfInterns) {
    return false
  }
  return true;
}

const checkDescription = () => {
  if (editionInfo.value.description.length > 500) {
    return false
  }
  return true;
}

const checkCurriculum = () => {
  if (editionInfo.value.curriculum!.length > 500) {
    return false
  }
  return true;
}
</script>

<template>
  <div class="form">
    <h2 class="title">{{ formName }}</h2>
    <TextInput boxName="Edition Name" @typedText="handleInput"></TextInput>
    <NumberInput boxName="Number of interns" @typedNumber="handleNumber"></NumberInput>
    <Dropdown dropdownName="Members" :data="internList" @selectedId="handleDropdown" />
    <div class="date-container">
      <DatePicker class="date_picker" boxName="Start Date" v-bind:required="true" v-bind:dateNow="true"
        @selectedDate="handleStartDate"></DatePicker>
      <DatePicker class="date_picker" boxName="End Date" v-bind:required="true" v-bind:minRequired="true"
        @selectedDate="handleEndDate"></DatePicker>
    </div>
    <Select boxName="Work Model" placeholder="Please select a work model" :list="workModel"
      @selectedValue="handleSelect"></Select>
    <TextArea boxName="Description" v-bind:minLength="10" v-bind:maxLength="500"
      @descriptionText="handleDescription"></TextArea>
    <TextArea boxName="Curriculum" @descriptionText="handleCurriculum"></TextArea>
    <PrimaryButton class="dds__button" buttonName="Submit" @clicked="handleClick" :disabled="disableButton()">
    </PrimaryButton>
  </div>
</template>

<style scoped>
.form {
  margin-left: 20%;
  margin-right: 20%;
  display: flex;
  flex-direction: column;
  gap: 16px;
}

.date-container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.title {
  color: #0063b8;
  font-size: 200%;
  font-weight: 500;
  text-align: center;
}

.date_picker {
  width: 45%;
}

.dds__button {
  padding-top: -4px;
  width: 10%;
}
</style>
