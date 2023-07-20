<script setup lang="ts">
import "@dds/components/src/scss/dds-fonts.scss";
import Dropdown from "@/components/Dropdown.vue"

</script>

<template>
    <div class="form">
        <h2 class="title">Create Program</h2>
        <div id="text-input-216225955" class="dds__input-text__container">
            <label id="text-input-label-647192958" for="text-input-control-647192958"
                class="dds__label dds__label--required">Program Name</label>
            <div class="dds__input-text__wrapper">
                <input type="text" class="dds__input-text" name="text-input-control-name-647192958"
                    id="text-input-control-647192958" required="true"
                    aria-labelledby="text-input-label-647192958 text-input-helper-647192958" v-model="programInfo.name"
                    @input="handleInput" />
                <small id="text-input-helper-647192958" class="dds__input-text__helper"></small>
                <div id="text-input-error-647192958" class="dds__invalid-feedback">Error text</div>
            </div>
        </div>
        <div class="date-container">
            <div class="dds__date-picker" data-dds="date-picker" id="startPicker">
                <label id="date-picker-label-206993451" for="date-picker-control-name-206993451"
                    class="dds__label dds__label--required">Start Date</label>
                <div class="dds__date-picker__wrapper">
                    <input type="date" class="dds__date-picker__input" placeholder="Enter the date" required="true"
                        maxlength="256" id="date-picker-control-206993451" name="date-picker-control-name-206993451"
                        aria-labelledby="date-picker-label-206993451 date-picker-helper-206993451"
                        v-model="programInfo.startDate" @input="handleInput" />
                    <small id="date-picker-helper-206993451" class="dds__date-picker__helper">Please, use the format
                        MM/DD/YYYY</small>
                    <div id="date-picker-error-206993451" class="dds__date-picker__invalid-feedback">Invalid date</div>
                </div>
            </div>
            <div class="dds__date-picker" data-dds="date-picker" id="endPicker">
                <label id="date-picker-label-206993451" for="date-picker-control-name-206993451"
                    class="dds__label dds__label">
                    End Date
                </label>
                <div class="dds__date-picker__wrapper">
                    <input type="date" class="dds__date-picker__input" placeholder="Enter the date" maxlength="256"
                        id="date-picker-control-206993451" name="date-picker-control-name-206993451"
                        aria-labelledby="date-picker-label-206993451 date-picker-helper-206993451"
                        v-model="programInfo.endDate"/>
                    <small id="date-picker-helper-206993451" class="dds__date-picker__helper">Please, use the format
                        MM/DD/YYYY</small>
                    <div id="date-picker-error-206993451" class="dds__date-picker__invalid-feedback">Invalid date</div>
                </div>
            </div>
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
                    v-model="programInfo.description" @input="handleInput" minlength="10" maxlength="50"></textarea>
                <small id="text-area-helper-359524269" class="dds__input-text__helper">Helper Text</small>
                <small id="text-area-error-867784391" class="dds__invalid-feedback">Error text</small>
            </div>
        </div>
        <button class="dds__button dds__button--primary" type="button" @click="handleClick">Submit</button>
    </div>
</template>

<script lang="ts">
import Program from "@/interfaces/Program";
import User from "@/interfaces/User";
import axios from "axios";
import { onMounted } from "vue";

export default {
    data() {
        return {
            programInfo: {
                name: '',
                startDate: new Date().toISOString().slice(0, 10),
                endDate: undefined,
                description: '',
                owners: []
            } as Program,
            counter: Number,
        };
    },
    methods: {
        handleInput() {
            console.log(this.programInfo.name);
            console.log(this.programInfo.description);
            console.log(this.programInfo.startDate);
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
                    alert('Solicitação atendida com sucesso!');
                })
                .catch((error) => {
                    alert('Não foi possível atender a solicitação.')
                });
        },
        async getOwners() {
            await axios
                .get("https://localhost:5001/user/getOwners")
                .then( (response) => {
                    this.programInfo.owners = response.data;
                })
                .catch( (error) => {
                    console.log(error);
                })
        }
    },
    mounted () {
        this.getOwners();
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