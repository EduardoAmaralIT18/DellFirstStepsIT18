<template>
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
                      @click="$router.push({ name: 'HomePage' });">Ok</button>
              </div>
          </div>
      </div>
  </div>

  <div class="container">
      <RouterLink to="/home" class="goBack"> &larr; Go back</RouterLink>
      <form data-dds="form" class="dds__form dds__container">
          <fieldset class="dds__form__section">

              <h2 class="title">Create Program</h2>
              <div class="dds__row">
                  <div class="dds__col--12 dds__col--sm-12">
                      <div class="dds__input-text__container">

                          <label id="text-input-label-396765024" for="text-input-control-name-396765024">Program Name
                              <span> * </span></label>
                          <small class="warning" v-if="v$.program.name.$error">The Name field is required with at
                              least
                              5 and at most 50 characters.
                          </small>

                          <div class="dds__input-text__wrapper">

                              <input v-model="v$.program.name.$model" type="text" class="dds__input-text"
                                  name="text-input-control-name-396765024" id="text-input-control-396765024"
                                  aria-labelledby="text-input-label-396765024 text-input-helper-396765024"
                                  required="true" />

                          </div>
                      </div>
                  </div>
              </div>

              <div class="dates dds__row">
                  <div class="dds__col--3 dds__col--sm-3">
                      <div>
                          <div class="dds__text-area__header">
                              <label for="startDate">Start date <span> *</span></label>
                              <small class="warning" v-if="v$.program.startDate.$error">The Start Date is
                                  required.
                              </small>
                          </div>
                          <input v-model="v$.program.startDate.$model" type="date" id="startDate" name="startDate">


                      </div>
                  </div>

                  <div class="enddate dds__col--3 dds__col--sm-3">
                      <div>
                          <div class="dds__text-area__header">
                              <label for="endDate">End date</label>
                              <small class="warning" v-if="v$.program.endDate.$error">The End Date must be after the Start
                                  Date.
                              </small>
                          </div>
                          <input v-model="v$.program.endDate.$model" type="date" id="endDate" name="endDate"
                              :min="program.startDate">

                      </div>
                  </div>
              </div>

              <div class="dds__row">
                  <div class="dds__col--12 dds__col--sm-12">
                      <!-- <div class="dds__select" data-dds="select"> -->
                      <div class="dds__text-area__header">
                          <label id="select-label-141366292" for="select-control-141366292">Owners <span>
                                  *</span></label>
                              <small class="warning" v-if="v$.program.members.$error">The Owners field is
                                  required.
                              </small>
                      </div>

                      <!-- <div class="multiselec dds__select__wrapper"> -->
                      <!-- <MultiSelect style="box-shadow: none ;" v-model="v$.program.members.$model" tipo="owner"/> -->

                      <div class="dds__dropdown" data-dds="dropdown" ref="multiselect" id="multi-select-list-dropdown"
                          data-selection="multiple" data-select-all-label="Select all">
                          <div class="dds__dropdown__input-container">
                              <div class="dds__dropdown__input-wrapper" autocomplete="off" aria-haspopup="listbox"
                                  aria-controls="multi-select-list-dropdown-popup">
                                  <input @blur="v$.program.members.$touch" id="multi-select-list-dropdown-input" name="multi-select-list-dropdown-name"
                                      type="text" role="combobox" class="dds__dropdown__input-field"
                                      aria-labelledby="multi-select-list-dropdown-label multi-select-list-dropdown-helper"
                                      autocomplete="off" aria-expanded="false"
                                      aria-controls="multi-select-list-dropdown-list" />
                              </div>
                          </div>
                          <div id="multi-select-list-dropdown-popup"
                              class="dds__dropdown__popup dds__dropdown__popup--hidden" role="presentation" tabindex="-1">
                              <ul class="dds__dropdown__list" role="listbox" tabindex="-1"
                                  id="multi-select-list-dropdown-list">
                                  <li v-for="owner in owners" :key="owner.id" class="dds__dropdown__item" role="none">
                                      <button type="button" class="dds__dropdown__item-option" role="option"
                                          data-selected="false" :data-value=owner.id tabindex="-1">
                                          <span class="dds__dropdown__item-label">{{ owner.name }}</span>
                                      </button>
                                  </li>
                              </ul>
                          </div>
                      </div>
                  </div>
              </div>

              <div class="dds__row">
                  <div class="dds__col--12 dds__col--sm-12">
                      <div class="dds__text-area__container" data-dds="text-area">
                          <div class="dds__text-area__header">
                              <label id="text-area-label-980579425" for="text-area-control-980579425">Description
                                  <span> *</span></label>
                              <small class="warning" v-if="v$.program.description.$error">The Description field is
                                  required with at least 10 and at most 1500 characters.</small>
                          </div>
                          <div class="dds__text-area__wrapper">
                              <textarea class="dds__text-area" name="text-area-control-name-980579425"
                                  id="text-area-control-980579425" data-maxlength="null" required="true"
                                  aria-labelledby="text-area-label-980579425 text-area-helper-980579425"
                                  v-model="v$.program.description.$model"></textarea>


                          </div>
                      </div>
                  </div>
              </div>
          </fieldset>
          <button class="submitbutton dds__button dds__button--lg" id="example" type="submit" @click.prevent="onSubmit()"
              :disabled="v$.$invalid">
              Submit
          </button>
      </form>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
// import MultiSelect from './MultipleSelect.vue';
import axios from 'axios';
import { useVuelidate } from '@vuelidate/core';
import { minLength, maxLength, required } from '@vuelidate/validators';
declare var DDS: any;

type User = {
  id: number,
  name: string
}[];

type programList = {
  name: string
}[];

interface Data {
  program: {
      name: string,
      members: null | User,
      description: string,
      startDate: string | Date,
      endDate: null | Date | string
  },
  total: null | User,
  options: null | User,
  programList: programList,
  messageError: string,
  titleError: string,
  buttonColor: string,
  owners: User | null,
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
          this.searchOwner();
      });
 },
  validations() {
      return {
          program: {
              name: {
                  required,
                  minLength: minLength(5),
                  maxLength: maxLength(50)
              },
              members: { required },
              description: {
                  required,
                  minLength: minLength(10),
                  maxLength: maxLength(1500)
              },
              startDate: { required },
              endDate: {

              }
          }
      }
  },
  components: {
      // MultiSelect
  },
  data(): Data {
      return {
          program: {
              name: '',
              members: [],
              description: '',
              startDate: new Date().toISOString().slice(0, 10),
              endDate: null
          },
          total: null,
          options: null,
          programList: [],
          messageError: '',
          titleError: '',
          buttonColor: "nullButton",
          owners: null,
          multiSelect: null,
      };
  },
  created() {
      axios.get(`/Program/getProgramsName`)
          .then(function (response) {
              return response;
          })
          .then(response => {
              if (response.status == 200) {
                  this.programList = response.data;
                  console.log(this.programList);
              } else if (response.status == 204) {
                  alert("There was an error on our database! Please, try again later.");
              }
          });

      axios.get(`/user/getOwners`)
          .then(function (response) {
              return response;
          })
          .then(response => {
              this.owners = response.data;
              return;
          });
  },
  methods: {
      searchOwner(): void {
          this.program.members = [];
          var ownerMultiselect = this.multiSelect.getSelection();

          ownerMultiselect.forEach((oMulti: number) => {
              this.program.members.push(this.owners?.find(o => o.id == oMulti as number))
          });

      },
      nameValidation() {
          var retorno = 0;
          this.programList.forEach(pL => {
              if (pL.name.toLowerCase().trim().replaceAll(" ", "") === this.program.name.toLowerCase().trim().replaceAll(" ", "")) {
                  retorno = 1;
              }
          })
          return retorno;
      },
      createModal(): void {
          const element = this.$refs.uniqueid;
          //console.log(element);
          console.log(DDS);
          console.log(element);
          const modal = new DDS.Modal(element, { trigger: "#example" });
          console.log(modal);
      },
      onSubmit(): void {
          if (this.nameValidation() != 0) {
              this.titleError = "Error";
              this.messageError = `The program "${this.program.name}" already exists.`;
              this.buttonColor = "errorButton";
              return;
          } else {
              if (this.program.endDate == null) {
                  axios.post('/program/addProgram', {
                      name: this.program.name,
                      startDate: this.program.startDate = new Date(),
                      description: this.program.description,
                      owners: this.program.members,
                      editions: null,
                      ownerships: null,
                      memberships: null
                  })
                      .then(function (response) {
                          return response;
                      })
                      .then(response => {
                          if (response.status == 202) {
                              this.titleError = "Program Created";
                              this.messageError = `The program "${this.program.name}" was successfully created.`;
                              this.buttonColor = "blueButton";
                              return;
                          } else if (response.status == 400) {
                              this.titleError = "Error";
                              this.messageError = `I'm sorry, something went wrong. Try again later.`;
                              this.buttonColor = "errorButton";
                              return;
                          }
                      })
              } else {
                  axios.post('/program/addProgram', {
                      name: this.program.name,
                      startDate: this.program.startDate = new Date(),
                      endDate: this.program.endDate = new Date(),
                      description: this.program.description,
                      owners: this.program.members,
                      editions: null,
                      ownerships: null,
                      memberships: null
                  })
                      .then(function (response) {
                          return response;
                      })
                      .then(response => {
                          if (response.status == 202) {
                              this.titleError = "Program Created";
                              this.messageError = `The program "${this.program.name}" was successfully created.`;
                              this.buttonColor = "blueButton";
                              return;
                          } else if (response.status == 400) {
                              this.titleError = "Error";
                              this.messageError = `I'm sorry, something went wrong. Try again later.`;
                              this.buttonColor = "errorButton";
                              return;
                          }
                      })
              }
          }
      }
  }
});
</script>

<style scoped>
body {
  font-family: 'Roboto', sans-serif;
}

.container {
  padding-top: 3%;
  padding-left: 20%;
  display: flex;
  flex-direction: column;
}

.title {
  color: #0063B8;
  margin-bottom: 5%;
  margin-top: 2%;
  font-size: 200%;
}

label {
  margin-top: 7px;
  display: flex;
  text-align: left;
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

.warning {
  display: flex;
  color: red;
  margin-top: 2px;
}
</style>

<style>
/* .multiselect {
  border: .0625rem solid #7e7e7e;
  border-radius: .125rem;
  background-clip: padding-box;
  margin-bottom: 5px;
  font-family: 'Roboto', sans-serif;
} */

/* .multiselect-tag {
  background-color: rgb(6, 114, 203);
  font-weight: lighter;
} */

.dates {
  text-align: left;
  display: flex;
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

/* 
.multiselect:hover {
  border: .0625rem solid rgb(6, 114, 203);
} */

.goBack {
  position: relative;
  right: 40%;
  text-decoration: none;
  color: #0672CB;
  font-weight: 300;
}

.dates input:hover {
  border: .0625rem solid rgb(6, 114, 203);
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