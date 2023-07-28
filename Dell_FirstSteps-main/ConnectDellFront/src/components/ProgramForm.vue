<script setup lang="ts">
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import { onMounted, ref } from "vue";
import axios from "axios";

import TextInput from "./TextInput.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue"
import TextArea from "./TextArea.vue";
import PrimaryButton from "./PrimaryButton.vue";
import type ProgramInfo from "@/interfaces/ProgramInfo";
import User from "@/interfaces/User";

defineProps<{
    formName: String
}>();

const programInfo = ref<ProgramInfo>({
    name: "",
    startDate: new Date().toISOString().slice(0, 10),
    endDate: '',
    description: "",
    editions: [],
    owners: []
});
const ownerList = ref<User[]>([]);
const nameList = ref<String[]>([]);

onMounted(() => {
    getOwners();
    getProgramsName();
});

const getOwners = async () => {
    await axios
        .get("https://localhost:5001/user/getOwners")
        .then((response) => {
            ownerList.value = response.data;
        })
        .catch((error) => {
            console.error(error);
        });
}

const getProgramsName = async () => {
    await axios
        .get("https://localhost:5001/program/getProgramsName")
        .then((response) => {
            nameList.value = response.data;
        })
        .catch((error) => {
            console.error(error);
        });
}

const handleInput = (text: string) => {
    programInfo.value.name = text;
}

const handleStartDate = (date: Date) => {
    programInfo.value.startDate = date.toString();
}

const handleEndDate = (date: Date) => {
    programInfo.value.endDate = date.toString();
}

const handleDropdown = (ownerId: number[]) => {
    programInfo.value.owners = [];

    ownerList.value.forEach(owner => {
        if (ownerId.some(id => id === owner.id)) {
            programInfo.value!.owners.push(owner)
        }
    })
}

const handleDescription = (text: string) => {
    programInfo.value.description = text;
}

const handleClick = async () => {
    await axios
        .post(`https://localhost:5001/program/addProgram`, {
            name: programInfo.value.name.trim(),
            startDate: new Date(programInfo.value.startDate),
            endDate: new Date(programInfo.value.endDate!),
            description: programInfo.value.description.trim(),
            owners: programInfo.value.owners
        })
        .then(() => {
            alert("Program successfully added.");
        })
        .catch((error) => {
            alert("Could not add program.");
        });
}

const disableButton = () => {
    console.log(programInfo.value.owners)
    if (programInfo.value.endDate == undefined) {
        return true;
    }

    if (new Date(programInfo.value.endDate!) > new Date(programInfo.value.startDate!) && checkName() && checkDescription() && checkOwners()) {
        return false;
    }
    return true;
}

const checkName = () => {
    if (programInfo.value.name.length >= 5 && programInfo.value.name.length <= 50) {
        return true
    }

    return false;
}

const checkOwners = () => {
    if (programInfo.value.owners?.length === 0) {
        return false
    }
    return true;
}

const checkDescription = () => {
    if (programInfo.value.description.length <= 1500 && programInfo.value.description.length >= 10) {
        return true
    }
    return false;
}
</script>

<template>
    <div class="form">
        <h2 class="title">{{ formName }}</h2>
        <TextInput boxName="Program Name" @typedText="handleInput"></TextInput>
        <div class="date-container">
            <DatePicker class="date_picker" boxName="Start Date" v-bind:required="true" v-bind:dateNow="true"
                @selectedDate="handleStartDate"></DatePicker>
            <DatePicker class="date_picker" boxName="End Date" v-bind:minRequired="true" @selectedDate="handleEndDate"
                initialDate=""></DatePicker>
        </div>
        <Dropdown dropdownName="Owners" :data="ownerList" @selectedId="handleDropdown" />
        <TextArea boxName="Description" minlength="10" maxlength="1500" :required="true" @descriptionText="handleDescription"></TextArea>
        <PrimaryButton buttonName="Submit" @clicked="handleClick" :disabled="disableButton()"></PrimaryButton>
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
    color: #0063B8;
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