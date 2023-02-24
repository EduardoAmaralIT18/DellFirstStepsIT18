<template>
    <div class="container">

        <!-- Linha abaixo alterar (Tirar do botão)-->
        <!-- <button class="dds__button" id="example" type="button">Launch modal button</button> -->
        <div role="dialog" data-dds="modal" class="dds__modal" id="uniqueid" ref="uniqueid">
            <div class="dds__modal--md">

                <div class="dds__modal__content">


                    <div class="dds__modal__header">
                        <h3 class="dds__modal__title" id="modal-headline-369536123">{{ titleError }}</h3>
                    </div>
                    <div id="modal-body-532887773" class="dds__modal__body">
                        <p>
                            {{ messageError }}
                        </p>
                    </div>
                    <div class="dds__modal__footer">
                        <button :class="buttonColor" class="buttonModal" type="button" name="modal-secondary-button"
                            @click="$router.push({ name: 'ProgramsPage' });">Ok</button>
                    </div>
                </div>
            </div>
        </div>


        <RouterLink to="/programinfo" class="goBack"> &larr; Go back</RouterLink>
        <form data-dds="form" class="dds__form dds__container">
            <!-- <fieldset class="dds__form__section"> -->

            <p class="title">Create Edition</p>

            <div class="dds__row">
                <div class="dds__col--12 dds__col--sm-12">
                    <div class="dds__input-text__container">
                        <label id="text-input-label-396765024" for="text-input-control-name-396765024">Edition
                            name <span> *</span></label>
                        <small v-if="v$.edition.name.$error" class="help-block">The Name field is required</small>
                        <div class="dds__input-text__wrapper">
                            <input v-model="v$.edition.name.$model" type="text" class="dds__input-text"
                                name="text-input-control-name-396765024" id="text-input-control-396765024"
                                aria-labelledby="text-input-label-396765024 text-input-helper-396765024" required="true" />

                            <small id="text-input-helper-396765024" class="dds__input-text__helper"></small>
                            <div id="text-input-error-396765024" class="dds__invalid-feedback">Enter a edition number
                                to continue</div>

                        </div>
                    </div>
                </div>
            </div>



            <div class="numberIntern dds__row">
                <div class="dds__col--12 dds__col--sm-12">
                    <div class="dds__input-text__container">
                        <label id="text-input-label-396765024" for="text-input-control-name-396765024">Number of interns
                        </label>
                    </div>
                    <div id="intern_select">
                        <input style="width:100%;" v-model="edition.numberOfInterns" type="number" min="1" max="22">
                    </div>

                </div>

            </div>

            <div class="dds__row">
                <div class="dds__col--12 dds__col--sm-12">
                    <!-- <div class="dds__select" data-dds="select"> -->
                    <div class="dds__text-area__header">
                        <label id="select-label-141366292" for="select-control-141366292">Members </label>
                        <small v-if="!validateInternsForm" class="help-block">Not possible to select more interns than
                            the amount stated.</small>
                    </div>

                    <!-- <div class="multiselec dds__select__wrapper"> -->
                    <!-- <MultiSelect style="box-shadow: none ;" v-model="v$.program.members.$model" tipo="owner"/> -->

                    <div class="dds__dropdown" data-dds="dropdown" ref="multiselect" id="multi-select-list-dropdown"
                        data-selection="multiple" data-select-all-label="Select all">
                        <div class="dds__dropdown__input-container">
                            <div class="dds__dropdown__input-wrapper" autocomplete="off" aria-haspopup="listbox"
                                aria-controls="multi-select-list-dropdown-popup">
                                <input @blur="v$.edition.members.$touch" id="multi-select-list-dropdown-input"
                                    name="multi-select-list-dropdown-name" type="text" role="combobox"
                                    class="dds__dropdown__input-field"
                                    aria-labelledby="multi-select-list-dropdown-label multi-select-list-dropdown-helper"
                                    autocomplete="off" aria-expanded="false"
                                    aria-controls="multi-select-list-dropdown-list" />
                            </div>
                        </div>
                        <div id="multi-select-list-dropdown-popup" class="dds__dropdown__popup dds__dropdown__popup--hidden"
                            role="presentation" tabindex="-1">
                            <ul class="dds__dropdown__list" role="listbox" tabindex="-1"
                                id="multi-select-list-dropdown-list">
                                <li v-for="member in members" :key="member.id" class="dds__dropdown__item" role="none">
                                    <button type="button" class="dds__dropdown__item-option" role="option"
                                        data-selected="false" :data-value=member.id tabindex="-1">
                                        <span class="dds__dropdown__item-label">{{ member.name }}</span>
                                    </button>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>


            <div class="dates dds__row">
                <div class="dds__col--3 dds__col--sm-3">
                    <div class="dds__text-area__header">
                        <label for="startDate">Start date <span>*</span></label>
                        <small v-if="v$.edition.startDate.$error" class="help-block">The Start Date field is
                            required</small>
                    </div>
                    <div class="dds__text-area__wrapper">
                        <input v-model="v$.edition.startDate.$model" type="date" id="startDate" name="startDate">

                    </div>
                </div>
                <div class="enddate dds__col--3 dds__col--sm-3">
                    <div class="dds__text-area__header">
                        <label for="endDate"> End date <span>*</span></label>
                        <small v-if="v$.edition.endDate.$error" class="help-block">The End Date field is
                            required</small>
                    </div>
                    <div class="dds__text-area__wrapper">
                        <input v-model="v$.edition.endDate.$model" type="date" id="endDate" name="endDate"
                            :min="edition.startDate">
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
            <button class="submitbutton dds__button dds__button--lg" type="button" id="example" @click.prevent="onSubmit()"
                :disabled="v$.$invalid || !validateInterns || !validateInternsForm">Submit</button>
        </form>
    </div>
</template>

<script lang ='ts'>
import { defineComponent } from 'vue';
import axios from 'axios';
import { useVuelidate } from '@vuelidate/core';
import { required } from '@vuelidate/validators';
declare var DDS: any;


type User = {
    id: number,
    name: string
    role: number,
}[];

type EditionsNames = {
    name: string
}[];

interface Data {
    edition: {
        name: string,
        numberOfInterns: Number,
        members: User | null,
        description: string,
        curriculum: string,
        mode: Number,
        startDate: string | Date,
        endDate: null | Date | string,
        program: Number
    },
    members: User | null,
    messageError: string,
    titleError: string,
    buttonColor: string,
    editionsNames: EditionsNames | null,
    multiSelect: unknown | null,


}
export default defineComponent({
    setup() {
        return { v$: useVuelidate() }
    },
    mounted() {
        this.createModal();

        this.multiSelect = DDS.Dropdown(this.$refs.multiselect);

         // eslint-disable-next-line
         this.$refs.multiselect.addEventListener("ddsDropdownSelectionChangeEvent", (e) => {
            this.searchMembers();
        });
    },
    created() {
        axios.get('/edition/getEditionsNames?idProgram=' + this.$cookies.get("programId"))
            .then(function (response) {
                return response;
            })
            .then(response => {
                this.editionsNames = response.data;
            });

        axios.get("/edition/getUsersNotAdmin")
            .then(function (response) {
                return response;
            })
            .then(response => {
                this.members = response.data;
                return;
            });

    },

    validations() {
        return {
            edition: {
                name: {
                    required
                },
                startDate: {
                    required
                },
                endDate: {
                    required
                },
            }
        }
    },
    components: {
    },
    data(): Data {
        return {
            edition: {
                name: '',
                numberOfInterns: 0,
                members: null,
                description: '',
                curriculum: '',
                mode: 1,
                startDate: new Date().toISOString().slice(0, 10),
                endDate: new Date().toISOString().slice(0, 10),
                program: 0
            },
            members: null,
            titleError: "",
            messageError: "",
            buttonColor: "nullButton",
            editionsNames: [],
            multiSelect: null,
        };

    },
    computed: {
        validateInterns(): boolean {
            var nInterns = 0;
            this.edition.members?.forEach(i => {
                if (i.role == 1) {
                    nInterns++;
                }
            })

            if (nInterns <= this.edition.numberOfInterns && nInterns >= 0) {
                return true;
            } else {
                return false;
            }
        },

        validateInternsForm(): boolean {
            var nInterns = 0;
            this.edition.members?.forEach(i => {
                if (i.role == 1) {
                    nInterns++;
                }
            })

            if (nInterns <= this.edition.numberOfInterns && nInterns >= 0) {
                return true;
            } else {
                return false;
            }
        }
    },
    methods: {
        searchMembers(): void{
            this.edition.members = [];
            var ownerMultiselect = this.multiSelect.getSelection();
    
            ownerMultiselect.forEach((mMulti: number) => {
                this.edition.members?.push(this.members?.find(m => m.id == mMulti as number))
            });
        },

        createModal(): void {
            const element = this.$refs.uniqueid;
            // console.log(element);
            console.log(DDS);
            console.log(element);
            const modal = new DDS.Modal(element, { trigger: "#example" });
            console.log(modal);
        },

        checkName(): number {
            let n: number = 0;
            this.editionsNames?.forEach(element => {
                if (element.name.toLowerCase().replaceAll(" ", "") == this.edition.name.toLowerCase().replaceAll(" ", "")) {

                    n = 1;
                }
            });


            return n;

        },

        onSubmit(): void {
            //this.$cookies.set("targetProgramId" , 1);
            this.edition.program = this.$cookies.get("programId");


            if (!this.v$.$invalid && this.validateInterns && this.validateInternsForm && this.checkName() == 0) {
                axios.post('/edition/addEdition', { //nome do controle na rota de EditionController (linha 9)
                    name: this.edition.name,
                    startDate: this.edition.startDate = new Date(),
                    endDate: this.edition.endDate,
                    description: this.edition.description,
                    curriculum: this.edition.curriculum,
                    mode: this.edition.mode,
                    numberOfInterns: this.edition.numberOfInterns,
                    members: this.edition.members,
                    program: this.edition.program,
                })
                    .then(function (response) {
                        return response;
                    })
                    .then(response => {
                        if (response.status == 200) {
                            // alert("Edition Created!");
                            // this.$router.push({ name: 'ProgramsPage' });
                            this.titleError = "Edition Created";
                            this.messageError = `The edition "${this.edition.name}" of ${this.$cookies.get("programName")} was successfully created.`;
                            this.buttonColor = "blueButton";
                            return;
                        } else if (response.status == 404) {
                            //this.$router.push({ name: 'ProgramsPage' });
                            //alert("There was an error on our database! Please, try again later.");
                            this.buttonColor = "errorButton";
                            this.titleError = "Error";
                            this.messageError = "I am sorry, something went wrong. Try again later.";

                        } else {
                            this.buttonColor = "errorButton";

                            this.titleError = "Error";
                            this.messageError = "I am sorry, something went wrong. Try again later.";

                        }
                    })

            } else if (this.checkName() == 1) {
                this.titleError = "Error";
                this.messageError = `The edition "${this.edition.name}" already exists.`;
                this.buttonColor = "errorButton";
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

.numberIntern input {
    width: 100%;
    height: 45px;
    font-size: 18px;
    color: #525151;
    padding-left: 2%;
    border: .0625rem solid #7e7e7e;
    border-radius: .125rem;
    background-clip: padding-box;
}


#intern_select {
    width: 100%;
    margin-bottom: 2%;
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
    float: left;
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

span {
    margin-left: 4px;
    color: #0063B8;
    font-weight: bold;
}

.goBack {
    position: relative;
    right: 40%;
    text-decoration: none;
    color: #0672CB;
    font-weight: 300;
}

.blueButton {
    background-color: #0672cb;
    border-color: #0672cb;
    color: #fff;
    border-radius: 0.125rem;
    font-size: .875rem;
    line-height: 1.5rem;
    padding: 0.4375rem 0.9375rem;
    border-radius: 0.125rem;
    font-size: 1rem;
    line-height: 1.5rem;
    padding: 0.6875rem 1.1875rem;
    border: 0.0625rem solid rgba(0, 0, 0, 0);
    cursor: pointer;
    display: inline-flex;
    justify-content: center;
    align-items: center;
    font-weight: 500;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    vertical-align: middle;
    white-space: normal;
    fill: currentColor;
}

.errorButton {
    background-color: rgb(206, 17, 38);
    border-color: rgb(206, 17, 38);
    color: #fff;
    border-radius: 0.125rem;
    font-size: .875rem;
    line-height: 1.5rem;
    padding: 0.4375rem 0.9375rem;
    border-radius: 0.125rem;
    font-size: 1rem;
    line-height: 1.5rem;
    padding: 0.6875rem 1.1875rem;
    border: 0.0625rem solid rgba(0, 0, 0, 0);
    cursor: pointer;
    display: inline-flex;
    justify-content: center;
    align-items: center;
    font-weight: 500;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    vertical-align: middle;
    white-space: normal;
    fill: currentColor;
}

.nullButton {
    background-color: rgb(255, 255, 255);
    border-color: rgb(255, 255, 255);
    color: #fff;
    border-radius: 0.125rem;
    font-size: .875rem;
    line-height: 1.5rem;
    padding: 0.4375rem 0.9375rem;
    border-radius: 0.125rem;
    font-size: 1rem;
    line-height: 1.5rem;
    padding: 0.6875rem 1.1875rem;
    border: 0.0625rem solid rgb(255, 255, 255);
    cursor: pointer;
    display: inline-flex;
    justify-content: center;
    align-items: center;
    font-weight: 500;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    vertical-align: middle;
    white-space: normal;
    fill: currentColor;
}
</style>
