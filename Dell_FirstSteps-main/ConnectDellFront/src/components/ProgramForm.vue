<script setup lang="ts">
import "@dds/components/src/scss/dds-fonts.scss";
import "@dds/components/src/scss/dds-icons.scss";
import TextInput from "./TextInput.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue"
import Program from "@/interfaces/Program";
import axios from "axios";
</script>

<template>
    <div class="form">
        <h2 class="title">{{ formName }}</h2>
        <TextInput boxName="Program Name" @typedText="handleInput"></TextInput>
        <div class="date-container">
            <DatePicker boxName="Start Date" v-bind:required="true" v-bind:dateNow="true" @selectedDate="handleStartDate"></DatePicker>
            <DatePicker boxName="End Date" @selectedDate="handleEndDate"></DatePicker>
        </div>
        <Dropdown dropdownName="Owners" :data="programInfo.owners" />
        <div id="text-area-container-502168065" class="dds__text-area__container" data-dds="text-area"
            data-counter-max="50">
            <div class="dds__text-area__header">
                <label id="text-area-label-867784391" for="text-area-control-867784391"
                    class="dds__label dds__label--required">Description</label>
            </div>
            <div class="dds__text-area__wrapper">
                <textarea class="dds__text-area" name="text-area-control-name-867784391" id="text-area-control-867784391"
                    aria-required="true" aria-labelledby="text-area-label-867784391 text-area-helper-867784391" required
                    v-model="programInfo.description" @input="" minlength="10" maxlength="50"></textarea>
                <small id="text-area-helper-359524269" class="dds__input-text__helper">Helper Text</small>
                <small id="text-area-error-867784391" class="dds__invalid-feedback">Error text</small>
            </div>
        </div>
        <button class="dds__button dds__button--primary" type="button" @click="handleClick">Submit</button>
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
            } as Program,
        };
    },
    props: {
        formName: String
    },
    methods: {
        handleInput(text: string) {
            this.programInfo.name = text;
            console.log(this.programInfo.name);
            console.log(this.programInfo.description);
        },
        handleStartDate(date: string) {
            this.programInfo.startDate = date
            console.log(this.programInfo.startDate);
        },
        handleEndDate(date: Date) {
            this.programInfo.endDate = date;
            console.log(this.programInfo.endDate);
        },
        async handleClick() {
            await axios
                .post(`https://localhost:5001/program/addProgram`, {
                name: this.programInfo.name,
                startDate: this.programInfo.startDate,
                endDate: this.programInfo.endDate,
                description: this.programInfo.description
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
                this.programInfo.owners = response.data;
            })
                .catch((error) => {
                console.log(error);
            });
        }
    },
    mounted() {
        this.getOwners();
    },
    components: {
        TextInput,
        DatePicker,
        Dropdown
    }
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