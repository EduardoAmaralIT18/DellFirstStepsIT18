<script setup lang="ts">
import ProgramUpdate from "@/interfaces/ProgramUpdate";
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import axios from "axios";
import { useRoute } from "vue-router";
import TextInput from "./TextInput.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue";
import TextArea from "./TextArea.vue";
import PrimaryButton from "./PrimaryButton.vue";
import { onMounted, ref } from "vue";
import User from "@/interfaces/User";


const props = defineProps({
    formName: String
})

const id = ref<number>()
const route = useRoute();
id.value = +route.params.id;

const programInfo = ref<ProgramUpdate>()

const ownerList = ref<User[]>([])
const nameList = ref<String[]>([])
const initialSelectedIds = ref<number[]>([])


onMounted(() => {
    getProgram();
})

const getProgram = async () => {
    await axios
        .get<ProgramUpdate>(`https://localhost:5001/program/getProgram?id=${id.value}`)
        .then((response) => {
            programInfo.value = response.data;
            response.data.owners.forEach(owner => initialSelectedIds.value.push(owner.id))
        })
        .catch((error) => {
            console.log(error);
        });
    getOwners();

    if (programInfo.value!.endDate == null) {
        programInfo.value!.endDate = ""
    }
}

const handleInput = (text: string) => {
    programInfo.value!.name = text;
}

const handleStartDate = (date: string) => {
    programInfo.value!.startDate = date
}

const handleEndDate = (date: string) => {
    programInfo.value!.endDate = date;
}
const handleDropdown = (ownerId: number[]) => {
    programInfo.value!.owners = [];

    ownerList.value.forEach(owner => {
        if (ownerId.some(id => id === owner.id)) {
            programInfo.value!.owners.push(owner)
        }
    })
}
const handleDescription = (text: string) => {
    programInfo.value!.description = text;
}

const handleClick = async () => {
    if (programInfo.value!.endDate == "") {
        programInfo.value!.endDate = undefined
    }

    await axios
        .post(`https://localhost:5001/program/updateProgram`, {
            id: id.value,
            name: programInfo.value!.name.trim(),
            startDate: programInfo.value!.startDate,
            endDate: programInfo.value!.endDate,
            description: programInfo.value!.description.trim(),
            owners: programInfo.value!.owners
        })
        .then(() => {
            alert("Solicitação atendida com sucesso!");
        })
        .catch((error) => {
            alert("Não foi possível atender a solicitação.");
        });
}
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

const activateButton = () => {
    if (programInfo.value!.endDate == undefined) {
        return false;
    }

    if (new Date(programInfo.value!.endDate!) <= new Date(programInfo.value!.startDate) || checkName() || checkOwners() || checkDescription()) {
        return true;
    }

    return false;
}

const checkName = () => {
    if (programInfo.value!.name.length < 5 || programInfo.value!.name.length > 50) {
        return true
    }
    for (let item of nameList.value) {
        if (item === programInfo.value!.name) {
            return true
        }
    }
    return false;
}

const checkOwners = () => {
    if (programInfo.value!.owners?.length === 0) {
        return true
    }
    return false;
}

const checkDescription = () => {
    if (programInfo.value!.description.length < 10 || programInfo.value!.description.length > 1500) {
        return true
    }
    return false;
}
</script>

<template>
    <div v-if="programInfo" class="form">
        <h2 class="title">{{ formName }}</h2>
        <TextInput :initial-value="programInfo.name" boxName="Program Name" @typedText="handleInput"></TextInput>
        <div class="date-container">
            <DatePicker class="date_picker" boxName="Start Date" v-bind:required="true" @selectedDate="handleStartDate"
                :initialDate="programInfo?.startDate.slice(0, 10)"></DatePicker>
            <DatePicker class="date_picker" boxName="End Date" @selectedDate="handleEndDate"
                :initialDate="programInfo?.endDate?.slice(0, 10)"></DatePicker>
        </div>
        <Dropdown dropdownName="Owners" :data="ownerList" :initial-value="initialSelectedIds" @selectedId="handleDropdown"/>
        <TextArea boxName="Description" v-bind:minLength=10 v-bind:maxLength=50 v-bind:required="true"
            @descriptionText="handleDescription" :initialValue="programInfo?.description"></TextArea>
        <PrimaryButton class="dds__button" buttonName="Submit" @clicked="handleClick" :disabled="activateButton()">
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