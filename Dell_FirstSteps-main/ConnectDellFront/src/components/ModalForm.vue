<script setup lang="ts">
import { onMounted, PropType, ref, watch, watchEffect } from "vue";
import TextInput from "./TextInput.vue";
import PrimaryButton from "./PrimaryButton.vue";
import Select from "./Select.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue";
import User from "@/interfaces/User";
import TextArea from "./TextArea.vue";
import SecondaryButton from "./SecondaryButton.vue";

declare var DDS: any;

const props = defineProps({
  modalTitle: String,
  editionUsers: Array as PropType<User[]>,
  editionStartDate: Date,
  editionEndDate: Date,
});

const modal = ref();
const element = ref(null);
const key = ref(0);
const activateButton = ref(true);
const inserts = ref({
  eventTitle: "",
  eventType: -1,
  startDate: new Date().toISOString().slice(0, 10),
  endDate: new Date().toISOString().slice(0, 10),
  peopleInvolved: new Array(),
  location: "",
});

onMounted(() => {
  modal.value = DDS.Modal(element.value);
});

watchEffect(() => {
  console.log(inserts.value.eventType)
  if (inserts.value.eventTitle !=="" && inserts.value.eventType !== -1) {
    activateButton.value = false;
    console.log("false");
  } else {
    activateButton.value = true;
    console.log("true");
  }
});

const emits = defineEmits({
  sendBodyToParent: Object,
});

function sendBodyToParent() {
  emits("sendBodyToParent", inserts.value);
}

const handleEventTitle = (text: string) => {
  text = text.trim();
  inserts.value.eventTitle = text;
}
const handleEventType = (text: string) => {
  console.log(text);
  if (text === "Phase") inserts.value.eventType = 0;
  if (text === "Activity") inserts.value.eventType = 1;
};
const handleStartDate = (date: string) => (inserts.value.startDate = date);
const handleEndDate = (date: string) => (inserts.value.endDate = date);
const handleDropdown = (users: []) => {
  inserts.value.peopleInvolved = [];
  users.forEach((id) => {
    inserts.value.peopleInvolved.push(
      props.editionUsers?.find((user) => user.id === id)
    );
  });
};
const handleLocation = (text: string) => (inserts.value.location = text);

function resetInputs() {
  inserts.value.eventTitle = "";
  inserts.value.eventType = -1;
  inserts.value.startDate = new Date().toISOString().slice(0, 10);
  inserts.value.endDate = new Date().toISOString().slice(0, 10);
  inserts.value.peopleInvolved = [];
  inserts.value.location = "";
  key.value++;
}
</script>

<template>
  <PrimaryButton buttonName="Add Event" @click="modal.open(), resetInputs()">
  </PrimaryButton>

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

      <div class="dds__modal__body" :key="key">
        <TextInput
          maxlength="30"
          boxName="Event Title"
          ref="inserts.eventTitle"
          @typedText="handleEventTitle"
        />
        <Select
          placeholder="select EventType"
          v-bind:required="true"
          :list="['Phase', 'Activity']"
          selectTitle="Event Type"
          ref="inserts.eventType"
          @selectedValue="handleEventType"
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
          ref="peopleInvolved"
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
        <SecondaryButton
          @click="modal.close(), resetInputs()"
          buttonName="Cancel"
        />
        <PrimaryButton
          @click="sendBodyToParent(), modal.close(), resetInputs()"
          buttonName="Save"
          :disabled="activateButton ? true : false"
        />
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
