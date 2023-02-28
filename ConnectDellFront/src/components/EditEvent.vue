<template>
  <!-- <div class="container"> -->
  <form data-dds="form" class="dds__form dds__container">
    <fieldset class="dds__form__section">

      <div class="dds__row">
        <div class="dds__col--12 dds__col--sm-12">
          <div class="dds__input-text__container">
            <label id="text-input-label-396765024" for="text-input-control-name-396765024">Event Title<span> *
              </span></label>
            <div class="dds__input-text__wrapper">
              <input v-model="v$.event.name.$model" type="text" class="dds__input-text"
                name="text-input-control-name-396765024" id="text-input-control-396765024"
                aria-labelledby="text-input-label-396765024 text-input-helper-396765024" required="true" />
              <small id="text-input-helper-396765024" class="dds__input-text__helper"></small>
              <small class="warning" v-if="v$.event.name.$error">The Name field is required with at most 30
                characters.</small>
            </div>
          </div>
        </div>
      </div>
      <div class="mode dds__row">
        <div class="dds__col--12 dds__col--sm-12">
          <div class="dds__select" data-dds="select">
            <div>Event Type<span>*</span></div>
            <select v-model="v$.event.eventType.$model">
              <option disabled value="">Please select one</option>
              <option value="0">Phase</option>
              <option value="1">Activity</option>
            </select>
            <small class="warning" v-if="v$.event.eventType.$error">The Event Type field is required.</small>
          </div>
        </div>
      </div>

      <div class="dates dds__row" v-if="event.eventType == 0">
        <div class="dds__col--3 dds__col--sm-3">
          <div> <label for="startDate">Start date <span> *</span></label> <input v-model="v$.event.startDate.$model"
              type="date" id="startDate" name="startDate" /> </div>
        </div>
        <div class="enddate dds__col--3 dds__col--sm-3">
          <div> <label for="endDate">End date<span> *</span></label> <input v-model="v$.event.endDate.$model" type="date"
              id="endDate" name="endDate" :min="event.startDate" /> <small class="warning"
              v-if="v$.event.endDate.$error">The End Date filed is required.</small> </div>
        </div>
      </div>
      <div class="dates dds__row" v-if="event.eventType == 1">
        <div class="dds__col--3 dds__col--sm-3">
          <div> <label for="startDate">Start time<span> *</span></label> <input v-model="v$.event.startDate.$model"
              type="datetime-local" id="startTime" name="appt" required /> </div>
        </div>
        <div class="enddate dds__col--3 dds__col--sm-3">
          <div> <label for="endDate">End time<span> *</span></label> <input v-model="v$.event.endDate.$model"
              type="datetime-local" :min="event.startDate" id="endTime" name="endTime" required /> </div>
        </div>
      </div>

      <div class="phasetype dds__row">
        <div class="dds__col--12 dds__col--sm-12">
          <div v-if="event.eventType == 0" class="dds__select" data-dds="select">
            <div>Phase</div>
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
            <label id="select-label-141366292" for="select-control-141366292">People Involved</label>
            <div class="multiselec dds__select__wrapper">

              <div class="dds__dropdown" data-dds="dropdown" ref="multiselectEdit" id="multiselectEdit"
                data-selection="multiple" data-select-all-label="Select all">
                <div class="dds__dropdown__input-container">
                  <div class="dds__dropdown__input-wrapper" autocomplete="off" aria-haspopup="listbox"
                    aria-controls="multi-select-list-dropdown-popup"> <input id="multi-select-list-dropdown-input"
                      name="multi-select-list-dropdown-name" type="text" role="combobox"
                      class="dds__dropdown__input-field"
                      aria-labelledby="multi-select-list-dropdown-label multi-select-list-dropdown-helper"
                      autocomplete="off" aria-expanded="false" aria-controls="multi-select-list-dropdown-list" /> </div>
                </div>
                <div id="multi-select-list-dropdown-popup" class="dds__dropdown__popup dds__dropdown__popup--hidden"
                  role="presentation" tabindex="-1">
                  <ul class="dds__dropdown__list" role="listbox" tabindex="-1" id="multi-select-list-dropdown-list">
                    <li v-for="member in options" :key="member.id" class="dds__dropdown__item" role="none"> <button
                        type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        :data-value=member.id tabindex="-1"> <span class="dds__dropdown__item-label">{{ member.name
                        }}</span> </button> </li>
                  </ul>
                </div>
              </div>



              <!-- <MultiSelect style="box-shadow: none" v-model="event.peopleInvolved" tipo="all" /> -->
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
              <label id="text-area-label-980579425" for="text-area-control-980579425">Location</label>
            </div>
            <div class="dds__text-area__wrapper">
              <textarea class="dds__text-area" name="text-area-control-name-980579425" id="text-area-control-980579425"
                data-maxlength="null" required="true"
                aria-labelledby="text-area-label-980579425 text-area-helper-980579425" v-model="event.where"></textarea>
              <small id="text-area-helper-980579425" class="dds__input-text__helper"></small>
              <!-- <small class="warning" v-if="event.where"
                  >The Description field is required with at least 10 and at
                  most 1500 characters.</small
                > -->
            </div>
          </div>
        </div>
      </div>
    </fieldset>

    <button class="submitbutton dds__button dds__button--secondary" type="button" @click.prevent="$emit('close-modal')">
      Cancel
    </button>

    <button :disabled="v$.$invalid" class="submitbutton dds__button dds__button--lg" type="submit"
      @click.prevent="onSubmit()">
      Save
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
  <!-- </div> -->


  <div ref="loading" id="loadingIndicator-overlay" class="dds__loading-indicator__container" data-dds="loading-indicator">
    <div class="dds__loading-indicator__overlay" aria-hidden="true"></div>
    <div class="dds__loading-indicator__wrapper">
      <div class="dds__loading-indicator">
        <div class="dds__loading-indicator__label" aria-live="polite">Loading...</div>
        <div class="dds__loading-indicator__spinner"></div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useVuelidate } from '@vuelidate/core';
import { required, maxLength, minLength } from '@vuelidate/validators';
import axios from "axios";
declare var DDS: any;


interface Data {
  event: Event,
  eventId: number,
  owners: User,
  options: User,
  multiselect: any,
  loading: any
}

type Event = {
  id: number,
  name: string,
  startDate: Date | null | string,
  endDate: Date | null | string,
  phaseType: number | string,
  eventType: number | string,
  where: string,
  peopleInvolved: User | null,
  edition: Edition | null,
};

type User = {
  id: number,
  name: string
}[];

type Edition = {
  id: number
};

export default defineComponent({
  data(): Data {
    return {
      event: {
        id: 0,
        name: "",
        startDate: null,
        endDate: null,
        phaseType: 0,
        eventType: 0,
        where: "",
        peopleInvolved: [],
        edition: this.$cookies.get("editionId")
      },
      eventId: this.$cookies.get("eventId"),
      owners: [],
      options: [],
      multiselect: null,
      loading: null
    }
  },
  setup() {
    return {
      v$: useVuelidate(),
    }
  },
  props: { eventProp: Event, },

  validations() {
    return {
      event: {
        name: { required, maxLength: maxLength(30), minLength: minLength(5) },
        eventType: { required },
        startDate: { required },
        endDate: { required }
      }
    }
  },
  mounted() {
    this.createMultiselect();
  },
  created() {
    this.event = this.eventProp;

    axios.get("/edition/getUsersNotAdmin")
      .then(function (response) {
        return response;
      })
      .then(response => {
        this.options = response.data;
        return;
      });
    axios.get("/user/GetOwners")
      .then(function (response) {
        return response;
      })
      .then(response => {
        this.owners = response.data;
        if (this.owners != null) {
          this.owners.forEach(u => {
            this.options.push(u);
          })
          this.loading.show();
        }
        return;
      })
    setTimeout(() => {
      this.showMembers();
      this.loading.hide();
    }, 1000);
  },
  updated() {
    this.event = this.eventProp;
    this.loading.show();
    setTimeout(() => {
      this.showMembers();
      this.loading.hide();
    }, 1000);
  },
  methods: {
    onSubmit() {
      if (!this.v$.$invalid) {
        if (this.event.eventType == "0") {
          this.event.eventType = 0;
        } else {
          this.event.eventType = 1;
        }

        // switch (this.event.phaseType) {
        //   case "0":
        //     this.event.phaseType = 0;
        //     break;
        //   case "1":
        //     this.event.phaseType = 1;
        //     break;
        //   case "2":
        //     this.event.phaseType = 2;
        //     break;
        //   case "3":
        //     this.event.phaseType = 3;
        //     break;
        //   case "4":
        //     this.event.phaseType = 4;
        //     break;
        //   default:
        //     console.log("Erro no switch");
        // }

        axios.post('event/updateEvent', this.event)
          .then(function (response) {
            return response;
          })
          .then(response => {
            if (response.status == 200) {
              this.$emit('close-modal');
              this.$emit('load-events');
              //deu certo
            } else {
              this.$emit('close-modal');
              this.$emit('load-events');
              //erro
            }
          })


      }

    },
    searchMembers(): void {
      this.event.peopleInvolved = [];
      var memberMultiselect = this.multiselect.getSelection();
      memberMultiselect.forEach((n: number) => {
        this.event.peopleInvolved?.push(this.options.find(p => p.id == n as number));
      })
    },
    showMembers(): void {
      this.event.peopleInvolved?.forEach(element => {
        this.multiselect.selectOption(element.id.toString());
      });
      this.searchMembers();
    },
    createMultiselect(): void {
      this.multiselect = DDS.Dropdown(this.$refs.multiselectEdit);
      this.loading = DDS.LoadingIndicator(this.$refs.loading);


      // eslint-disable-next-line            
      this.$refs.multiselectEdit.addEventListener("ddsDropdownSelectionChangeEvent", (e) => {
        this.searchMembers();
      });
    },

  },


})
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
  font-weight: 500;
  max-width: 1024px;
  padding-left: 40px;
  padding-right: 40px;
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
  margin-right: 10%;
}

.enddate input {
  background-color: rgba(181, 181, 181, 0.233);
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
  padding: .6875rem 4.5rem .6875rem 1rem;
  border: .0625rem solid #7e7e7e;
  border-radius: .125rem;
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
  padding: .6875rem 4.5rem .6875rem 1rem;
  border: .0625rem solid #7e7e7e;
  border-radius: .125rem;
  background-clip: padding-box;
  margin-top: 1%;
  margin-bottom: 1%;
}

.dds__modal__content {
  width: 800px;
}
</style>