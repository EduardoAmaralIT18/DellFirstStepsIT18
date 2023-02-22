<template>
  <div class="container">
    <RouterLink to="/home" class="goBack"> &larr; Go back</RouterLink>
    <form data-dds="form" class="dds__form dds__container">
      <fieldset class="dds__form__section">
        <h2 class="title">Add Event</h2>
        <div class="dds__row">
          <div class="dds__col--12 dds__col--sm-12">
            <div class="dds__input-text__container">
              <label
                id="text-input-label-396765024"
                for="text-input-control-name-396765024"
                >Event Title<span> * </span></label
              >
              <div class="dds__input-text__wrapper">
                <input
                  v-model="event.name"
                  type="text"
                  class="dds__input-text"
                  name="text-input-control-name-396765024"
                  id="text-input-control-396765024"
                  aria-labelledby="text-input-label-396765024 text-input-helper-396765024"
                  required="true"
                />
                <small
                  id="text-input-helper-396765024"
                  class="dds__input-text__helper"
                ></small>
                <!-- <small class="warning" v-if="event.name"
                  >The Name field is required with at least 5 and at most 50
                  characters.</small
                > -->
              </div>
            </div>
          </div>
        </div>
        <div class="mode dds__row">
          <div class="dds__col--12 dds__col--sm-12">
            <div class="dds__select" data-dds="select">
              <div>Type of Event:</div>
              <select v-model="event.eventType">
                <option disabled value="">Please select one</option>
                <option value="0">Phase</option>
                <option value="1">Activity</option>
              </select>
            </div>
          </div>
        </div>

        <div class="dates dds__row" v-if="event.eventType == 0">
          <div class="dds__col--3 dds__col--sm-3">
            <div>
              <label for="startDate">Start date <span> *</span></label>
              <input
                v-model="event.startDate"
                type="date"
                id="startDate"
                name="startDate"
              />
            </div>
          </div>
          <div class="enddate dds__col--3 dds__col--sm-3">
            <div>
              <label for="endDate">End date</label>
              <input
                v-model="event.endDate"
                type="date"
                id="endDate"
                name="endDate"
                :min="event.startDate"
              />
            </div>
          </div>
        </div>

        <div class="dates dds__row" v-if="event.eventType == 1">
          <div class="dds__col--3 dds__col--sm-3">
            <div>
              <label for="startDate">Start time<span> *</span></label>
              <input
                v-model="event.startDate"
                type="datetime-local"
                id="startTime"
                name="appt"
                required
            />
            </div>
          </div>
          <div class="enddate dds__col--3 dds__col--sm-3">
            <div>
              <label for="endDate">End time<span> *</span></label>
              <input
                v-model="event.endDate"
                type="datetime-local"
                id="endTime"
                name="endTime"
                required
            />
            </div>
          </div>
        </div>

        <div class="phasetype dds__row">
          <div class="dds__col--12 dds__col--sm-12">
            <div
              v-if="event.eventType == 0"
              class="dds__select"
              data-dds="select"
            >
              <div>Phase:</div>
              <select v-model="event.phaseType">
                <option disabled value="">Please select one</option>
                <option value="0">Set Up</option>
                <option value="1">Training</option>
                <option value="2">Sprints</option>
                <option value="3">Hands On</option>
                <option value="4">Manager Meetings</option>
              </select>
            </div>
          </div>
        </div>

        <div class="dds__row">
          <div class="dds__col--12 dds__col--sm-12">
            <div class="dds__select" data-dds="select">
              <label id="select-label-141366292" for="select-control-141366292"
                >People Involved<span> *</span></label
              >
              <div class="multiselec dds__select__wrapper">
                <MultiSelect
                  style="box-shadow: none"
                  v-model="event.peopleInvolved"
                  tipo="all"
                />
                <!-- <small class="warning" v-if="event.peopleInvolved"
                  >The Members field is required.</small
                > -->
              </div>
            </div>
          </div>
        </div>
        <div class="dds__row">
          <div class="dds__col--12 dds__col--sm-12">
            <div class="dds__text-area__container" data-dds="text-area">
              <div class="dds__text-area__header">
                <label
                  id="text-area-label-980579425"
                  for="text-area-control-980579425"
                  >Location <span> *</span></label
                >
              </div>
              <div class="dds__text-area__wrapper">
                <textarea
                  class="dds__text-area"
                  name="text-area-control-name-980579425"
                  id="text-area-control-980579425"
                  data-maxlength="null"
                  required="true"
                  aria-labelledby="text-area-label-980579425 text-area-helper-980579425"
                  v-model="event.where"
                ></textarea>
                <small
                  id="text-area-helper-980579425"
                  class="dds__input-text__helper"
                ></small>
                <!-- <small class="warning" v-if="event.where"
                  >The Description field is required with at least 10 and at
                  most 1500 characters.</small
                > -->
              </div>
            </div>
          </div>
        </div>
      </fieldset>
      <button
        class="submitbutton dds__button dds__button--lg"
        type="submit"
        @click.prevent="onSubmit()"
      >
        Submit
      </button>
      <!-- <button
        class="submitbutton dds__button dds__button--lg"
        type="submit"
        @click.prevent="onSubmit()"
        :disabled=".$invalid"
      >
        Submit
      </button> -->
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import MultiSelect from "./MultipleSelect.vue";
import axios from "axios";
// import { useVuelidate } from '@vuelidate/core';
// import { minLength, maxLength, required } from '@vuelidate/validators';

type User = {
  id: number;
  name: string;
}[];

interface Data {
  event: {
    name: string;
    peopleInvolved: User;
    startDate: string | Date;
    endDate: Date | string;
    where: string;
    phaseType: Number;
    eventType: Number;
    editionId: Number;
  };
}

export default defineComponent({
  // setup() {
  //     return { : useVuelidate() }
  // },
  // validations() {
  //     return {
  //         event: {
  //             name: {
  //                 required,
  //                 minLength: minLength(5),
  //                 maxLength: maxLength(50)
  //             },
  //             people: { required },
  //             description: {
  //                 required,
  //                 minLength: minLength(10),
  //                 maxLength: maxLength(1500)
  //             },
  //             startDate: { required },
  //         }
  //     }
  // },
  components: {
    MultiSelect,
  },
  data(): Data {
    return {
      event: {
        name: "",
        peopleInvolved: [],
        startDate: new Date().toISOString(),
        endDate: new Date().toISOString(),
        where: "",
        phaseType: 1,
        eventType: 1,
        editionId: 0,
      },
    };
  },

  // Confirmar com gurias do display se elas vão pegar os eventos do banco para mostrar no calendário

  methods: {
    onSubmit(): void {
      console.log(this.event.startDate);
      axios.post("/event/addEvent", {
        name: this.event.name,
        peopleInvolved: this.event.peopleInvolved,
        startDate: this.event.startDate,
        endDate: this.event.endDate,
        where: this.event.where,
        phaseType: this.event.phaseType,
        eventType: this.event.eventType,
        editionId: this.$cookies.get("editionId"),
      });
      // .then(function (response) {
      //   return response;
      // })
      // .then((response) => {
      //   if (response.status == 200) {
      //     this.$router.push({ name: "HomePage" });
      //     return;
      //   } else if (response.status == 404) {
      //     this.$router.push({ name: "HomePage" });
      //     alert(
      //       "There was an error on our database! Please, try again later."
      //     );
      //   }
      // });
    },
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
.dates {
  text-align: left;
  display: flex;
  margin-bottom: 1%;
}
.dates label {
  color: #636363;
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
.dates input:hover {
  border: 0.0625rem solid rgb(6, 114, 203);
}
.submitbutton {
  margin-top: 30px;
  display: flex;
  float: left;
  width: 20%;
  font-size: 20px;
  margin-bottom: 12%;
}
span {
  margin-left: 4px;
  color: #0063b8;
  font-weight: bold;
}
.warning {
  display: flex;
  color: rgb(150 29 29);
  margin-top: 2px;
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
span {
  margin-left: 4px;
  color: #0063b8;
  font-weight: bold;
}
.multiselect:hover {
  border: 0.0625rem solid rgb(6, 114, 203);
}
.goBack {
  position: relative;
  right: 40%;
  text-decoration: none;
  color: #0672cb;
  font-weight: 300;
}
.dates input:hover {
  border: 0.0625rem solid rgb(6, 114, 203);
}
.mode {
  text-align: left;
  margin-top: 1%;
  margin-bottom: 3%;
}
.mode select:hover {
  border: 0.0625rem solid rgb(6, 114, 203);
}
.colorText {
  color: #636363;
}
.mode select {
  width: 100%;
  height: 45px;
  font-size: 18px;
  color: #636363;
  padding: 0.6875rem 4.5rem 0.6875rem 1rem;
  border: 0.0625rem solid #7e7e7e;
  border-radius: 0.125rem;
  background-clip: padding-box;
  margin-top: 1%;
  margin-bottom: 1%;
}
.phasetype {
  text-align: left;
  margin-top: 1%;
  margin-bottom: 3%;
}
.phasetype select {
  width: 100%;
  height: 45px;
  font-size: 18px;
  color: #636363;
  padding: 0.6875rem 4.5rem 0.6875rem 1rem;
  border: 0.0625rem solid #7e7e7e;
  border-radius: 0.125rem;
  background-clip: padding-box;
  margin-top: 1%;
  margin-bottom: 1%;
}
</style>
