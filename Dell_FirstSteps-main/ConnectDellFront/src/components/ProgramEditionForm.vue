<script setup lang="ts">
import ProgramInfo from "@/interfaces/ProgramInfo";
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import axios from "axios";
import { onMounted, PropType } from "vue";
import { useRoute } from "vue-router";
import TextInput from "./TextInput.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue";
import TextArea from "./TextArea.vue";
import PrimaryButton from "./PrimaryButton.vue";
</script>

<template>
    <div v-if="isMounted" class="form">
        <h2 class="title">{{ formName }}</h2>
        <TextInput boxName="Program Name" @typedText="handleInput" :data="programInfo.name"></TextInput>
        <div class="date-container">
            <DatePicker class="date_picker" boxName="Start Date" v-bind:required="true" v-bind:dateNow="true" @selectedDate="handleStartDate"></DatePicker>
            <DatePicker class="date_picker" boxName="End Date" v-bind:minRequired="true" @selectedDate="handleEndDate"></DatePicker>
        </div>
        <Dropdown dropdownName="Owners" :data="ownerList" @selectedId="handleDropdown" :selected="programInfo.owners"/>
        <TextArea boxName="Description" v-bind:minLength=10 v-bind:maxLength=50 v-bind:required="true" @descriptionText="handleDescription" :data="programInfo.description"></TextArea>
        <PrimaryButton class="dds__button" buttonName="Submit" @clicked="handleClick" :isDisabled="activateButton()"></PrimaryButton>
    </div>
</template>

<script lang="ts">
    export default {
    data() {
        return {
            programInfo: {
                name: "",
                startDate: new Date(),
                endDate: new Date(),
                description: "",
                editions: [],
                owners: []  
            },
            id: new Number,
            isMounted: false,
            ownerList: new Array,
            nameList: new Array
        }
    },
    methods: {
        handleInput(text: string) {
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
    props: {
        formName: String
    },
    async mounted() {
        const route = useRoute();
        this.id = +route.params.id;
        await axios
            .get(`https://localhost:5001/program/getProgram?id=${this.id}`)
            .then((response) => {
                this.programInfo = response.data;
            })
            .catch((error) => {
            console.log(error);
            });
            this.isMounted = true;
            console.log(this.programInfo);
        this.getOwners();
    }
}
</script>

<style scoped>

</style>