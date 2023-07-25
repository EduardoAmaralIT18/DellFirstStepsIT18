<script setup lang="ts">
import { onMounted, PropType, ref, watchEffect } from "vue";
import TextInput from "./TextInput.vue";
import PrimaryButton from "./PrimaryButton.vue";
import Select from "./Select.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue";
import User from "@/interfaces/User";
import TextArea from "./TextArea.vue";
import SecondaryButton from "./SecondaryButton.vue";

declare var DDS: any;

const props=defineProps({
  modalTitle: String,
  editionUsers: Array as PropType<User[]>,
  editionStartDate: Date,
  editionEndDate: Date
});

const modal = ref();
const element = ref(null);

onMounted(() => {
  modal.value = DDS.Modal(element.value);
});

const emits = defineEmits({

sendBodyToParent: Object
})

function sendBodyToParent(){
emits("sendBodyToParent",inserts.value);
}

const inserts = ref({
  eventTitle: "",
  eventType: "",
  startDate: new Date().toISOString().slice(0, 10),
  endDate: new Date().toISOString().slice(0, 10),
  peopleInvolved:[],
  location: "",
});
const activateButton = ref(true);
const handleEventTitle = (text: string) => (inserts.value.eventTitle = text);
const handleEventType = (text: string) => (inserts.value.eventType = text);
const handleStartDate = (date: string) => (inserts.value.startDate = date);
const handleEndDate = (date: string) => (inserts.value.endDate = date);
const handleDropdown = (users: []) => (inserts.value.peopleInvolved = users);
const handleLocation = (text: string) => (inserts.value.location = text);

watchEffect(() => {
  if(inserts.value.eventTitle && inserts.value.eventType){
    activateButton.value=false;
    console.log("false")
  }
  else{
    activateButton.value=true;
    console.log("true")
  }
})

</script>

<template>
  <PrimaryButton buttonName="Add Event" @click="modal.open()"> </PrimaryButton>

  <div
    role="dialog"
    ref="element"
    data-dds="modal"
    class="dds__modal"
    aria-labelledby="modal-headline-160350263"
  >
    <div class="dds__modal__content">
      <div class="dds__modal__header">
        <h3 class="dds__modal__title">
          {{ modalTitle }}
        </h3>
      </div>

      <div class="dds__modal__body">
        <TextInput
          maxlength="30"
          boxName="Event Title"
          @typedText="handleEventTitle"
        />
        <Select
          v-bind:required="true"
          :list="['Phase', 'Activity']"
          selectTitle="Event Type"
          @selectValue="handleEventType"
        />
        <div class="date-container">
          <DatePicker
            boxName="Start Date"
            v-bind:required="true"
            :date-now="true"
            @selectedDate="handleStartDate"
          />
          <DatePicker
            boxName="End Date"
            v-bind:required="true"
            :date-now="true"
            @selectedDate="handleEndDate"
          />
        </div>
        <Dropdown
          dropdownName="People Involved"
          :data="editionUsers"
          @selectedId="handleDropdown"
        />
        <TextArea
          @description-text="handleLocation"
          maxlength="120"
          boxName="Location"
          :required="false"
        />
      </div>

      <div class="dds__modal__footer">
        <SecondaryButton @click="modal.close()" buttonName="Cancel" />
        <PrimaryButton @click="sendBodyToParent(), modal.close()" buttonName="Save" :disabled="activateButton ? true : false " />
      </div>
    </div>
  </div>
</template>

<style scoped>
.dds__modal__header .dds__modal__title {
  color: #0672cb;
  font-weight: 500;
}
.dds__modal__content {
  width: 40%;
}
.date-container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
</style>
