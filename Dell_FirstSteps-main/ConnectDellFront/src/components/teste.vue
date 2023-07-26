<template>
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
<style>
.a {
    max-width: 200px;
}
</style>