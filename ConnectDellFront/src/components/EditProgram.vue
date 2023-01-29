<template>
  <div class="container">
    <RouterLink to="/programinfo" class="goBack"> &larr; Go back</RouterLink>
    <form data-dds="form" class="dds__form dds__container">
      <fieldset class="dds__form__section">
        <h2 class="title">Edit Program</h2>
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
                <input v-model="program.endDate" type="date" id="endDate" name="endDate" />
              </div>
            </div>
          </div>
          <div class="dds__row">
            <div class="dds__col--12 dds__col--sm-12">
              <div class="dds__select" data-dds="select">
                <label id="select-label-141366292" for="select-control-141366292">Owners <span> *</span></label>
                <div class="multiselec dds__select__wrapper">
                  <MultiSelect v-model="program.owners" />
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
                    (between 10 and 500 characters).</small>
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
          <button class="submitbutton dds__button dds__button--lg" type="submit" @click.prevent="onSubmit()">
            Submit
          </button>
        </div>
      </fieldset>
    </form>
  </div>
</template>

<script lang="ts">
import { useVuelidate } from '@vuelidate/core';
import { required, maxLength, minLength } from '@vuelidate/validators';
import { defineComponent } from "vue";
import MultiSelect from "./MultipleSelect.vue";
import axios from "axios";


type User = {
  id: number;
  name: string;
}[];

interface Data {
  program: {
    id: number | null;
    name: string;
    owners: null | User;
    description: string;
    startDate: string | Date | null;
    endDate: null | Date | string;
  };
  total: null | User;
  options: null | User;
  idProgram: any;
}

export default defineComponent({

  components: {
    MultiSelect,
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
      idProgram: this.$route.params.idProgram
    };
  },
  validations() {
    return {
      program: {
        name: { required },
        description: { required, maxLength: maxLength(1500), minLength: minLength(10) },
        startDate: { required }
      }
    }

  },

  created() {
    axios
      .get(`/Program/GetProgram?id=${this.idProgram}`)
      .then(function (response) {
        return response;
      })
      .then((response) => {
        if (response.status == 200) {
          this.program = response.data;
          this.program.startDate = new Date(response.data.startDate).toISOString().slice(0, 10);
          this.program.endDate = response.data.endDate ? new Date(response.data.endDate).toISOString().slice(0, 10) : null;
          return;
        } else if (response.status == 404) {
          this.$router.push({ name: "ProgramsPage" });
          alert("There was an error on our database! Please, try again later.");
        }
      });
  },
  methods: {
    onSubmit(): void {
      if (!this.v$.$invalid) {

        axios.post('/Program/UpdateProgram', {
          id: this.program.id,
          name: this.program.name,
          startDate: this.program.startDate,
          endDate: this.program.endDate,
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
              alert("Program updated!");
              this.$router.push({ name: "ProgramsPage" });
              return;
              //ver se daria apra fazer um !=200
            } else if (response.status == 404) {
              this.$router.push({ name: "ProgramsPage" });
              alert(
                "There was an error on our database! Please, try again later."
              );
            }
          });
      }else{
        this.v$.$validate();
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
  float: right;
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

.enddate input {
  background-color: rgba(181, 181, 181, 0.233);
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

.enddate input {
  background-color: rgba(181, 181, 181, 0.233);
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
</style>
