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
            @click="$router.push({ name: 'ProgramsPage' });">Ok</button>
        </div>
      </div>
    </div>
  </div>

  <div ref="loading" id="loadingIndicator-overlay" class="dds__loading-indicator__container" data-dds="loading-indicator">
    <div class="dds__loading-indicator__overlay" aria-hidden="true"></div>
    <div class="dds__loading-indicator__wrapper">
      <div class="dds__loading-indicator">
        <div class="dds__loading-indicator__label" aria-live="polite">Loading...</div>
        <div class="dds__loading-indicator__spinner"></div>
      </div>
    </div>
  </div>

  <div class="container">
    <RouterLink to="/programinfo" class="goBack"> &larr; Go back</RouterLink>
    <form data-dds="form" class="dds__form dds__container">
      <fieldset class="dds__form__section">
        <h2 class="title">Manage Program</h2>
        <div v-if="program.id === null">
          <div class="dds__loading-indicator">
            <div class="dds__loading-indicator__label">Loading...</div>
            <div class="dds__loading-indicator__spinner"></div>
          </div>
        </div>
        <div v-else>
          <div class="dds__row">
            <div class="dds__col--12 dds__col--sm-12">
              <div class="dds__input-text__container">
                <label id="text-input-label-396765024" for="text-input-control-name-396765024">Program Name<span>
                    *</span>
                </label>
                <small v-if="v$.program.name.$error" class="help-block">The program name is required</small>
                <div class="dds__input-text__wrapper">
                  <input v-model="v$.program.name.$model" type="text" class="dds__input-text"
                    name="text-input-control-name-396765024" id="text-input-control-396765024"
                    aria-labelledby="text-input-label-396765024 text-input-helper-396765024" required="true" />
                  <small id="text-input-helper-396765024" class="dds__input-text__helper"></small>
                  <div id="text-input-error-396765024" class="dds__invalid-feedback">
                    Enter a program name to continue
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="dates dds__row">
            <div class="dds__col--3 dds__col--sm-3">
              <div>
                <label for="startDate">Start date <span> *</span></label>
                <small v-if="v$.program.startDate.$error" class="help-block">A start date is required</small>
                <input v-model="v$.program.startDate.$model" type="date" id="startDate" name="startDate" />
              </div>
            </div>
            <div class="enddate dds__col--3 dds__col--sm-3">
              <div>
                <label for="endDate">End date</label>
                <input v-model="program.endDate" type="date" id="endDate" name="endDate" :min="program.startDate" />
              </div>
            </div>
          </div>

          <div class="dds__row">
            <div class="dds__col--12 dds__col--sm-12">
              <!-- <div class="dds__select" data-dds="select"> -->
              <div class="dds__text-area__header">
                <label id="select-label-141366292" for="select-control-141366292">Owners <span>
                    *</span></label>
                <small class="warning" v-if="v$.program.owners.$error">The Owners field is
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
                    <input @blur="v$.program.owners.$touch" id="multi-select-list-dropdown-input"
                      name="multi-select-list-dropdown-name" type="text" role="combobox"
                      class="dds__dropdown__input-field"
                      aria-labelledby="multi-select-list-dropdown-label multi-select-list-dropdown-helper"
                      autocomplete="off" aria-expanded="false" aria-controls="multi-select-list-dropdown-list" />
                  </div>
                </div>
                <div id="multi-select-list-dropdown-popup" class="dds__dropdown__popup dds__dropdown__popup--hidden"
                  role="presentation" tabindex="-1">
                  <ul class="dds__dropdown__list" role="listbox" tabindex="-1" id="multi-select-list-dropdown-list">
                    <li v-for="owner in owners" :key="owner.id" class="dds__dropdown__item" role="none">
                      <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        :data-value=owner.id tabindex="-1">
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
                  <label id="text-area-label-980579425" for="text-area-control-980579425">Description<span>
                      *</span></label>
                  <small v-if="v$.program.description.$error" class="help-block">Please enter a proper description
                    (between 10 and 1500 characters).</small>
                </div>
                <div class="dds__text-area__wrapper">
                  <textarea class="dds__text-area" name="text-area-control-name-980579425"
                    id="text-area-control-980579425" data-maxlength="null" required="true"
                    aria-labelledby="text-area-label-980579425 text-area-helper-980579425"
                    v-model="v$.program.description.$model"></textarea>
                  <small id="text-area-helper-980579425" class="dds__input-text__helper"></small>
                  <small id="text-area-error-980579425" class="dds__invalid-feedback">Enter a description to
                    continue</small>
                </div>
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
import { useVuelidate } from '@vuelidate/core';
import { required, maxLength, minLength } from '@vuelidate/validators';
import { defineComponent } from "vue";
import axios from "axios";
declare var DDS: any;

type User = {
  id: number;
  name: string;
}[];

type programList = {
  name: string
}[];

interface Data {
  program: {
    id: number | null,
    name: string,
    owners: null | User,
    description: string,
    startDate: string | Date | null,
    endDate: null | Date | string,
  },
  total: null | User,
  options: null | User,
  idProgram: any,
  programList: programList,
  originalName: string,
  messageError: string,
  titleError: string,
  buttonColor: string,
  multiSelect: unknown | null,
  loading: unknown | null,
  owners: User | null
}

export default defineComponent({

  components: {
  },
  props: {
    name: String,
    Description: String,
    startDate: Date,
  },
  setup() {
    return {
      v$: useVuelidate(),

    }
  },
  mounted() {
    this.createModal();
    this.loading = DDS.LoadingIndicator(this.$refs.loading);
  },
  data(): Data {
    return {
      program: {
        id: null,
        name: "",
        owners: null,
        description: "",
        startDate: null,
        endDate: null,
      },
      total: null,
      options: null,
      idProgram: this.$route.params.idProgram,
      programList: [],
      originalName: '',
      messageError: '',
      titleError: '',
      buttonColor: "nullButton",
      multiSelect: null,
      loading: null,
      owners: null
    };
  },
  validations() {
    return {
      program: {
        name: { required },
        description: { required, maxLength: maxLength(1500), minLength: minLength(10) },
        startDate: { required },
        owners: { required }
      }
    }

  },
  created() {
    this.fetchData();
  },

  methods: {
    fetchData(): void {
      axios.get(`/Program/getProgram?id=${this.idProgram}`)
        .then(function (response) {
          return response;
        })
        .then((response) => {
          if (response.status == 200) {
            this.program = response.data;
            this.originalName = response.data.name;
            this.program.startDate = new Date(response.data.startDate).toISOString().slice(0, 10);
            if (this.program.endDate != null) {
              this.program.endDate = new Date(response.data.endDate).toISOString().substring(0, 10);
            }
            return;
          } else if (response.status == 404) {
            this.$router.push({ name: "ProgramsPage" });
            alert("There was an error on our database! Please, try again later.");
          }
        });

      axios.get(`/Program/getProgramsName`)
        .then(function (response) {
          return response;
        })
        .then(response => {
          if (response.status == 200) {
            this.programList = response.data;
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
          this.createMultiselect();
          this.loading.show();
          return;
        });

      setTimeout(() => {
        this.showOwners();
        this.loading.hide();
      }, 1000);
    },

    createMultiselect(): void {
      this.multiSelect = DDS.Dropdown(this.$refs.multiselect);

      // eslint-disable-next-line
      this.$refs.multiselect.addEventListener("ddsDropdownSelectionChangeEvent", (e) => {
        this.searchOwner();
      });

    },

    showOwners(): void {
      this.program.owners?.forEach(element => {
        this.multiSelect.selectOption(element.id.toString());
      });
      this.searchOwner();
    },

    searchOwner(): void {
      this.program.owners = [];
      var ownerMultiselect = this.multiSelect.getSelection();

      ownerMultiselect.forEach((oMulti: number) => {
        this.program.owners?.push(this.owners?.find(o => o.id == oMulti as number))
      });
    },

    nameValidation(): number {
      if (this.originalName.toLowerCase().replaceAll(" ", "") == this.program.name.toLowerCase().replaceAll(" ", "")) {
        return 0;
      } else {
        let n: number = 0;
        this.programList.forEach(pL => {
          if (pL.name.toLowerCase().replaceAll(" ", "") == this.program.name.toLowerCase().replaceAll(" ", "")) {
            n = 1;
          }
        });
        return n;
      }
    },

    createModal(): void {
      const element = this.$refs.uniqueid;
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
        if (!this.v$.$invalid) {
          let targetEndDate = null;
          if (this.program.endDate != "") {
            targetEndDate = this.program.endDate;
          }
          axios.post('/Program/updateProgram', {
            id: this.program.id,
            name: this.program.name,
            startDate: this.program.startDate,
            endDate: targetEndDate,
            description: this.program.description,
            owners: this.program.owners,
            editions: null,
            ownerships: null,
            memberships: null,
          })
            .then(function (response) {
              return response;
            })
            .then((response) => {
              if (response.status == 200) {
                this.titleError = "Program Edited";
                this.messageError = `Your changes were successfully apllied on the program "${this.program.name}".`;
                this.buttonColor = "blueButton";
                return;
              } else if (response.status == 400) {
                this.titleError = "Error";
                this.messageError = `I'm sorry, something went wrong. Try again later.`;
                this.buttonColor = "errorButton";
                return;
              }
            });
        } else {
          this.v$.$validate();
        }
      }
    }
  },
});
</script>
<style scoped>
body {
  font-family: "Roboto", sans-serif;
}

.container {
  padding-top: 3%;
  padding-left: 20%;
  display: flex;
  flex-direction: column;
}

.title {
  color: #0063b8;
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
  margin-bottom: 1%;
}

.dates input {
  width: 100%;
  height: 45px;
  font-size: 18px;
  color: #525151;
  padding-left: 4%;
  border: 0.0625rem solid #7e7e7e;
  border-radius: 0.125rem;
  background-clip: padding-box;
}

span {
  margin-left: 4px;
  color: #0063b8;
  font-weight: bold;
}
</style>

<style>
.multiselect {
  border: 0.0625rem solid #7e7e7e;
  border-radius: 0.125rem;
  background-clip: padding-box;
  margin-bottom: 5px;
  font-family: "Roboto", sans-serif;
}

.multiselect-tag {
  background-color: rgb(6, 114, 203);
  font-weight: lighter;
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
  border: 0.0625rem solid #7e7e7e;
  border-radius: 0.125rem;
  background-clip: padding-box;
}


span {
  margin-left: 4px;
  color: #0063b8;
  font-weight: bold;
}

small {
  color: red;
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
