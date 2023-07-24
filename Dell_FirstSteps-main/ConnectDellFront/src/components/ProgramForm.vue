<script setup lang="ts">
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import TextInput from "./TextInput.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue"
import TextArea from "./TextArea.vue";
import PrimaryButton from "./PrimaryButton.vue";
import Program from "@/interfaces/Program";
import axios from "axios";
</script>

<template>
    <div class="form">
        <h2 class="title">{{ formName }}</h2>
        <TextInput boxName="Program Name" @typedText="handleInput"></TextInput>
        <div class="date-container">
            <DatePicker boxName="Start Date" v-bind:required="true" v-bind:dateNow="true" @selectedDate="handleStartDate"></DatePicker>
            <DatePicker boxName="End Date" v-bind:minRequired="true" @selectedDate="handleEndDate"></DatePicker>
        </div>
        <Dropdown dropdownName="Owners" :data="ownerList" @selectedId="handleDropdown"/>
        <TextArea boxName="Description" maxlength="50" v-bind:required="true" @descriptionText="handleDescription"></TextArea>
        <PrimaryButton buttonName="Submit" @clicked="handleClick" :isDisabled="activateButton()"></PrimaryButton>
    </div>
</template>

<script lang="ts">
export default {
    data() {
        return {
            programInfo: {
            name: "",
            startDate: new Date().toISOString().slice(0, 10),
            endDate: undefined,
            description: "",
            owners: []
} as unknown as Program,
            ownerList: new Array
        };
    },
    props: {
        formName: String
    },
    methods: {
        handleInput(text: string): void {
            this.programInfo.name = text;
            console.log(this.programInfo.name);
        },
        handleStartDate(date: string): void {
            this.programInfo.startDate = date
            console.log(this.programInfo.startDate);
        },
        handleEndDate(date: Date): void {
            this.programInfo.endDate = date;
            console.log(this.programInfo.endDate);
        },
        handleDropdown(owner: []): void {   
            this.programInfo.owners = [];   
            owner.forEach(id => {
                this.programInfo.owners?.push(this.ownerList.find(user => user.id === id));
            })
            console.log(this.programInfo.owners);
        },
        handleDescription(text: string): void {
            this.programInfo.description = text;
            console.log(this.programInfo.description);
        },
        async handleClick() {
            await axios
                .post(`https://localhost:5001/program/addProgram`, {
                name: this.programInfo.name.trim(),
                startDate: this.programInfo.startDate,
                endDate: this.programInfo.endDate,
                description: this.programInfo.description.trim(),
                owners: this.programInfo.owners
            })
                .then(() => {
                alert("Solicitação atendida com sucesso!");
            })
                .catch((error) => {
                alert("Não foi possível atender a solicitação.");
            });
        },
        async getOwners() {
            await axios
                .get("https://localhost:5001/user/getOwners")
                .then((response) => {
                this.ownerList = response.data;
            })
                .catch((error) => {
                console.log(error);
            });
        },
        activateButton(): boolean {
            if (typeof(this.programInfo.endDate) == undefined)
                return false;

            if (this.programInfo.endDate! <= this.programInfo.startDate)
                return true;
            return false;
        }
    },
    mounted() {
        this.getOwners();
    },
};
</script>

<style scoped>
.form {
    margin-left: 10%;
    margin-right: 10%;
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

.dds__button {
    margin-top: 30px;
}
</style>