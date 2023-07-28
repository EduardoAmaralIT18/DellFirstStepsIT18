<script setup lang="ts">
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import TextInput from "./TextInput.vue";
import NumberInput from "./NumberInput.vue";
import Select from "./Select.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue"
import TextArea from "./TextArea.vue";
import PrimaryButton from "./PrimaryButton.vue";
import Edition from "@/interfaces/Edition";
import User from "@/interfaces/User";
import axios from "axios";
import { PropType } from "vue";
</script>

<template>
    <div class="form">
        <h2 class="title">{{ formName }}</h2>
        <TextInput boxName="Edition Name" @typedText="handleInput"></TextInput>
        <NumberInput boxName="Number of interns" @typedNumber="handleNumber"></NumberInput>
        <Dropdown dropdownName="Members" :data="internList" @selectedId="handleDropdown"/>
        <div class="date-container">
            <DatePicker class="date_picker" boxName="Start Date" v-bind:required="true" v-bind:dateNow="true" @selectedDate="handleStartDate"></DatePicker>
            <DatePicker class="date_picker" boxName="End Date" v-bind:required="true" v-bind:minRequired="true" @selectedDate="handleEndDate"></DatePicker>
        </div>
        <Select boxName="Work Model" placeholder="Please select a work model" :list="workModel" @selectValue="handleSelect"></Select>
        <TextArea boxName="Description" v-bind:minLength=10 v-bind:maxLength=50 @descriptionText="handleDescription"></TextArea>
        <TextArea boxName="Curriculum" @descriptionText="handleCurriculum"></TextArea>
        <PrimaryButton class="dds__button" buttonName="Submit" @clicked="handleClick" :disabled="activateButton()"></PrimaryButton>
    </div>
</template>

<script lang="ts">
export default {
    data() {
        return {
            editionInfo: {
                id: new Number,
                name: "",
                numberOfInterns: new Number,
                members: new Array,
                startDate: new Date().toISOString().slice(0, 10),
                endDate: "",
                mode: new Number,
                description: "",
                curriculum: "",
                program: new Number
            } as Edition,
            workModel: ['Remote', 'Hybrid', 'InOffice'],
            internList: new Array,
            nameList: new Array
        };
    },
    props: {
        formName: String,
        programId: Number
    },
    methods: {
        handleInput(text: string): void {
            this.editionInfo.name = text;
        },
        handleNumber(value: number): void {
            this.editionInfo.numberOfInterns = value;
        },
        handleStartDate(date: string): void {
            this.editionInfo.startDate = date
        },
        handleEndDate(date: string): void {
            this.editionInfo.endDate = date;
        },
        handleDropdown(intern: []): void {   
            this.editionInfo.members = [];   
            intern.forEach(id => {
                this.editionInfo.members?.push(this.internList.find(user => user.id === id));
            })
        },
        handleSelect(workMode: string): void {
            this.editionInfo.mode = this.workModel.indexOf(workMode);
        },
        handleDescription(text: string): void {
            this.editionInfo.description = text;
        },
        handleCurriculum(text: string): void {
            this.editionInfo.curriculum = text;
        },
        async handleClick() {
            await axios
                .post(`https://localhost:5001/edition/addEdition`, {
                name: this.editionInfo.name.trim(),
                numberOfInterns: this.editionInfo.numberOfInterns,
                members: this.editionInfo.members,
                startDate: this.editionInfo.startDate,
                endDate: this.editionInfo.endDate,
                mode: this.editionInfo.mode,
                description: this.editionInfo.description.trim(),
                curriculum: this.editionInfo.curriculum?.trim(),
                program: this.programId
            })
                .then(() => {
                alert("Solicitação atendida com sucesso!");
            })
                .catch(() => {
                alert("Não foi possível atender a solicitação.");
            });
        },
        async getUsersNotAdmin() {
            await axios
                .get("https://localhost:5001/edition/getUsersNotAdmin")
                .then((response) => {
                    this.internList = response.data;
                })
                .catch((error) => {
                    console.log(error);
                });
        },
        async getEditionsNames() {
            await axios
                .get("https://localhost:5001/edition/getEditionsNames")
                .then((response) => {
                    this.nameList = response.data;
                })
                .catch((error) => {
                    console.log(error)
                });
        },
        activateButton(): boolean {
            if (this.editionInfo.endDate == undefined)
                return true;

            if (this.editionInfo.endDate! <= this.editionInfo.startDate! || this.checkName() || this.checkNumberOfInterns() || this.checkMembers() || this.checkDescription() || this.checkCurriculum())
                return true;
            return false;
        },
        checkName(): boolean {
            if(this.editionInfo.name.length < 5 || this.editionInfo.name.length > 50)
                return true
            for(let item of this.nameList) {
                if(item.name === this.editionInfo.name)
                    return true
            }
            return false;
        },
        checkNumberOfInterns(): boolean {
            if(this.editionInfo.numberOfInterns < 1 || this.editionInfo.numberOfInterns > 21)
                return true
            return false;
        },
        checkMembers(): boolean {
            if(this.editionInfo.members.filter(usr => usr.role == 1).length > this.editionInfo.numberOfInterns)
                return true
            return false;
        },
        checkDescription(): boolean {
            if(this.editionInfo.description.trim().length > 500)
                return true
            return false;
        },
        checkCurriculum(): boolean {
            if(this.editionInfo.curriculum!.trim().length > 500)
                return true
            return false;
        }
    },
    mounted() {
        this.getUsersNotAdmin();
        this.getEditionsNames();
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