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
            <DatePicker class="date_picker" boxName="Start Date" v-bind:required="true" v-bind:dateNow="true" @selectedDate="handleStartDate"></DatePicker>
            <DatePicker class="date_picker" boxName="End Date" v-bind:minRequired="true" @selectedDate="handleEndDate"></DatePicker>
        </div>
        <Dropdown dropdownName="Owners" :data="ownerList" @selectedId="handleDropdown"/>
        <TextArea boxName="Description" maxlength="50" v-bind:required="true" @descriptionText="handleDescription"></TextArea>
        <PrimaryButton buttonName="Submit" @clicked="handleClick" :isDisabled="activateButton()"></PrimaryButton>
    </div>
</template>

<script lang="ts">
import axios from "axios";
import type ProgramInfo from "@/interfaces/ProgramInfo";

export default {
    data() {
        return {
            programInfo: {
                name: "",
                startDate: new Date(),
                endDate: new Date(),
                description: "",
                owners: [],
                isBasic: false,
            } as ProgramInfo,
            ownerList: new Array,
            nameList: new Array
        };
    },
    props: {
        formName: String
    },
    methods: {
        handleInput(text: string): void {
            this.programInfo.name = text;
        },
        handleStartDate(date: Date): void {
            this.programInfo.startDate = date
        },
        handleEndDate(date: Date): void {
            this.programInfo.endDate = date;
        },
        handleDropdown(owner: []): void {   
            this.programInfo.owners = [];
            owner.forEach(id => {
                this.programInfo.owners?.push(this.ownerList.find(user => user.id === id));
            })
        },
        handleDescription(text: string): void {
            this.programInfo.description = text;
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
                console.error(error);
            });
        },
        async getProgramsName() {
            await axios
                .get("https://localhost:5001/program/getProgramsName")
                .then((response) => {
                this.nameList = response.data;
            })
                .catch((error) => {
                console.error(error);
            });
        },
        activateButton(): boolean {
            if (typeof(this.programInfo.endDate) == undefined)
                return false;

            if (this.programInfo.endDate! <= this.programInfo.startDate || this.checkName() || this.checkOwners() || this.checkDescription())
                return true;
            return false;
        },
        checkName(): boolean {
            if(this.programInfo.name.length < 5 || this.programInfo.name.length > 50)
                return true
            for(let item of this.nameList) {
                if(item.name === this.programInfo.name)
                    return true
            }
            return false;
        },
        checkOwners(): boolean {
            if(this.programInfo.owners?.length === 0)
                return true
            return false;
        },
        checkDescription(): boolean {
            if(this.programInfo.description.length < 10 || this.programInfo.description.length > 1500)
                return true
            return false;
        }
    },
    mounted() {
        this.getOwners();
        this.getProgramsName();
    },
};
</script>

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