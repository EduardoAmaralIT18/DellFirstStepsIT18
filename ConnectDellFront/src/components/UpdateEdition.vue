<template>

    <div class="container">
        <form data-dds="form" class="dds__form dds__container">
            <!-- <fieldset class="dds__form__section"> -->

            <p class="title">Update Edition</p>

            <div class="dds__row">
                <div class="dds__col--12 dds__col--sm-12">
                    <div class="dds__input-text__container">
                        <label id="text-input-label-396765024" for="text-input-control-name-396765024">Edition
                            name <span> *</span></label>
                            <small v-if="v$.edition.name.$error" class="help-block">The Name field is required</small>
                        <div class="dds__input-text__wrapper">
                            <input v-model="v$.edition.name.$model" type="text" class="dds__input-text"
                                name="text-input-control-name-396765024" id="text-input-control-396765024"
                                aria-labelledby="text-input-label-396765024 text-input-helper-396765024"
                                required="true" />

                            <small id="text-input-helper-396765024" class="dds__input-text__helper"></small>
                            <div id="text-input-error-396765024" class="dds__invalid-feedback">Enter a edition number
                                to continue</div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="dates dds__row">
                <div class="dds__col--3 dds__col--sm-3">
                    <div class="dds__input-text__container">
                        <label id="text-input-label-396765024" for="text-input-control-name-396765024">Number of interns
                        </label>
                    </div>
                    <div id="intern_select">
                        <input v-model="edition.numberOfInterns" type="number" min="1" max="22">
                    </div>

                </div>

                <div class="dds__col--3 dds__col--sm-3">
                    <div class="dds__input-text__container">
                        <label id="text-input-label-396765024" for="text-input-control-name-396765024">Number of members
                        </label>
                    </div>
                    <div id="member_select">
                        <input v-model="edition.numberOfMembers" type="number" min="1" max="25">
                    </div>
                </div>
            </div>


            <div class="dates dds__row">
                <div class="dds__col--3 dds__col--sm-3">
                    <div>
                        <label for="startDate">Start date <span>*</span></label>
                        <small v-if="v$.edition.startDate.$error" class="help-block">The Start Date field is required</small>
                        <input v-model="v$.edition.startDate.$model" type="date" id="startDate" name="startDate">
                    </div>
                </div>
                <div class="enddate dds__col--3 dds__col--sm-3">
                    <div>
                        <label for="endDate"> End date </label>
                        <input v-model="edition.endDate" type="date" id="endDate" name="endDate">
                    </div>
                </div>
            </div>

            <div class="mode dds__row">

                <div class="dds__col--12 dds__col--sm-12">
                    <div class="dds__select" data-dds="select">
                        <div>Work Model:</div>

                        <select v-model="edition.mode">
                            <option disabled value="">Please select one</option>
                            <option value="2">In-Office</option>
                            <option value="1">Hybrid</option>
                            <option value="0">Remote</option>
                        </select>

                    </div>
                </div>
            </div>

            <div class="dds__row">
                <div class="dds__col--12 dds__col--sm-12">
                    <div class="dds__text-area__container" data-dds="text-area">
                        <div class="dds__text-area__header">
                            <label id="text-area-label-980579425" for="text-area-control-980579425">Description
                            </label>
                        </div>
                        <div class="dds__text-area__wrapper">
                            <textarea class="dds__text-area" name="text-area-control-name-980579425"
                                id="text-area-control-980579425" data-maxlength="null" required="true"
                                aria-labelledby="text-area-label-980579425 text-area-helper-980579425"
                                v-model="edition.description"></textarea>
                            <small id="text-area-helper-980579425" class="dds__input-text__helper"></small>
                            <small id="text-area-error-980579425" class="dds__invalid-feedback">Enter a description
                                to continue</small>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dds__row">
                <div class="dds__col--12 dds__col--sm-12">
                    <div class="dds__text-area__container" data-dds="text-area">
                        <div class="dds__text-area__header">
                            <label id="text-area-label-980579425" for="text-area-control-980579425">Curriculum
                            </label>
                        </div>
                        <div class="dds__text-area__wrapper">
                            <textarea class="dds__text-area" name="text-area-control-name-980579425"
                                id="text-area-control-980579425" data-maxlength="null" required="true"
                                aria-labelledby="text-area-label-980579425 text-area-helper-980579425"
                                v-model="edition.curriculum"></textarea>
                            <small id="text-area-helper-980579425" class="dds__input-text__helper"></small>
                            <small id="text-area-error-980579425" class="dds__invalid-feedback">Enter your curriculum
                                to continue</small>
                        </div>

                    </div>
                </div>
            </div>
            <!-- </fieldset> -->
            <button class="submitbutton dds__button dds__button--lg" type="submit"
                @click.prevent="onSubmit()">Submit</button>
        </form>
    </div>

</template>

<script lang ='ts'>
import { defineComponent } from 'vue';
import axios from 'axios';
import {useVuelidate} from '@vuelidate/core';
import {required} from '@vuelidate/validators';
//import moment from 'moment';

interface Data {
    edition: {
        id: number,
        name: string,
        numberOfInterns: Number,
        numberOfMembers: Number,
        description: string,
        curriculum: string,
        mode: Number,
        startDate: null | Date | string,
        endDate: null | Date | string,
        program: Number
    },
    cookiesId: Number | null,
    cookiesEdit: Number | null
}
export default defineComponent({
    setup(){
        return {v$:useVuelidate()}
    },
    data(): Data {
        return {
            edition: {
                id: 0,
                name: '',
                numberOfInterns: 0,
                numberOfMembers: 0,
                description: '',
                curriculum: '',
                mode: 1,
                startDate: null,
                endDate: null,
                program: 0
            },
            cookiesId: this.$cookies.get("programId"),
            cookiesEdit: this.$cookies.get("editionId")
        };
    },
    validations(){
        return {
            edition: {name : {required}, startDate: {required}}
        }
    },
    created() {
        axios.get(`/edition/showInfoEdition?idProgram=${this.cookiesId}&idEdition=${this.cookiesEdit}`)
            .then(function (response) {
                return response;
            })
            .then(response => {
                if (response.status == 200) {
                    this.edition.id = response.data.id;
                    this.edition.name = response.data.name;
                    this.edition.numberOfInterns = response.data.numberOfInterns;
                    this.edition.numberOfMembers = response.data.numberOfMembers;
                    this.edition.description = response.data.description;
                    this.edition.curriculum = response.data.curriculum;
                    this.edition.mode = response.data.mode;
                    this.edition.startDate = new Date(response.data.startDate).toISOString().substring(0,10);
                    this.edition.endDate = new Date(response.data.endDate).toISOString().substring(0,10);
                    this.edition.program = response.data.program;
                } else if (response.status == 204) {
                    alert("There was an error on our database! Please, try again later.");
                }
            })
    },
    methods: {
        onSubmit(): void {
            //this.edition.program = this.$cookies.get("programId");
            if (!this.v$.$invalid){
                axios.post('/edition/updateEdition', { 
                    id: this.edition.id,
                    name: this.edition.name,
                    startDate: this.edition.startDate,
                    endDate: this.edition.endDate,
                    description: this.edition.description,
                    curriculum: this.edition.curriculum, 
                    mode: this.edition.mode,
                    numberOfMembers: this.edition.numberOfMembers,
                    numberOfInterns: this.edition.numberOfInterns,
                    //program: this.edition.program,

                })
                    .then(function (response) {
                        return response;
                    })
                    .then(response => {
                        if (response.status == 200) {
                            this.$router.push({ name: 'ProgramsPage' });
                            return;
                        } else if (response.status == 404) {
                            this.$router.push({ name: 'ProgramsPage' });
                            alert("There was an error on our database! Please, try again later.");
                        }
                    })
            } else {
                this.v$.$validate();
            }

        },

    }
});
</script>

<style scoped>
body {
    font-family: 'Roboto', sans-serif;
}

small {
    color: red;
}

.container {
    padding-top: 3%;
    padding-left: 20%;
    display: flex;
    flex-direction: column;

}

.mode {
    text-align: left;
    margin-top: 3%;
    margin-bottom: 3%;
}

.mode select {
    width: 100%;
    height: 45px;
    font-size: 18px;
    color: #525151;
    padding: .6875rem 4.5rem .6875rem 1rem;
    border: .0625rem solid #7e7e7e;
    border-radius: .125rem;
    background-clip: padding-box;
    margin-top: 1%;
    margin-bottom: 1%;
}

.title {
    color: #0063B8;
    margin-bottom: 5%;
    margin-top: 2%;
    font-size: 200%;
}

label {
    display: flex;
    text-align: left;
    margin-bottom: 10px;
}

.submitbutton {
    margin-top: 30px;
    display: flex;
    float: right;
    width: 20%;
    font-size: 20px;
    margin-bottom: 12%;
}

.dates {
    text-align: left;
    display: flex;
    margin-top: 2%;
    margin-bottom: 1%;

}

.dates input {
    width: 100%;
    height: 45px;
    font-size: 18px;
    color: #525151;
    padding-left: 4%;
    border: .0625rem solid #7e7e7e;
    border-radius: .125rem;
    background-clip: padding-box;
}

.enddate input {
    background-color: rgba(181, 181, 181, 0.233);
}

span {
    margin-left: 4px;
    color: #0063B8;
    font-weight: bold;
}
</style>