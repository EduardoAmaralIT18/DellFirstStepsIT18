<script setup lang="ts">
import ProgramUpdate from "@/interfaces/ProgramUpdate";
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
        <TextInput boxName="Program Name" @typedText="handleInput" :initialValue="programInfo.name"></TextInput>
        <div class="date-container">
            <DatePicker class="date_picker" boxName="Start Date" v-bind:required="true" v-bind:dateNow="true" @selectedDate="handleStartDate" :initialDate="programInfo.startDate.slice(0,10)"></DatePicker>
            <DatePicker class="date_picker" boxName="End Date" v-bind:minRequired="true" @selectedDate="handleEndDate" :initialDate="programInfo.endDate?.slice(0,10)"></DatePicker>
        </div>
        <Dropdown dropdownName="Owners" :data="ownerList" @selectedId="handleDropdown" :selected="programInfo.owners"/>
        <TextArea boxName="Description" v-bind:minLength=10 v-bind:maxLength=50 v-bind:required="true" @descriptionText="handleDescription" :initialValue="programInfo.description"></TextArea>
        <PrimaryButton class="dds__button" buttonName="Submit" @clicked="handleClick" :disabled="activateButton()"></PrimaryButton>
    </div>
</template>

<script lang="ts">
    export default {
    data() {
        return {
            programInfo: {
                id: new Number,
                name: "",
                startDate: "",
                endDate: "",
                description: "",
                editions: [],
                owners: []
            } as ProgramUpdate,
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
        handleStartDate(date: string): void {
            this.programInfo.startDate = date
        },
        handleEndDate(date: string): void {
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
            if(this.programInfo.endDate == "")
                this.programInfo.endDate = undefined
            
            await axios
                .post(`https://localhost:5001/program/updateProgram`, {
                id: this.id,
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
            

            if (new Date(this.programInfo.endDate!) <= new Date(this.programInfo.startDate) || this.checkName() || this.checkOwners() || this.checkDescription())
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

        if(this.programInfo.endDate == null)
            this.programInfo.endDate = ""
    }
}
</script>

[5:28 PM] Rafael Terres, Guilherme - Dell Team

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