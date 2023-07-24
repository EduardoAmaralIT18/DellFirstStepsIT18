<script setup lang="ts">
import { onMounted, PropType, ref } from "vue";
import TextInput from "./TextInput.vue";
import PrimaryButton from "./PrimaryButton.vue";
import Select from "./Select.vue";
import DatePicker from "./DatePicker.vue";
import Dropdown from "./Dropdown.vue";
import User from "@/interfaces/User";
import TextArea from "./TextArea.vue";
import SecondaryButton from "./SecondaryButton.vue";

declare var DDS: any;

defineProps({
  modalTitle: String,
  editionUsers: Array as PropType<User[]>,
});

const modal = ref();
const element = ref(null);

onMounted(() => {
  modal.value = DDS.Modal(element.value);
});

const inserts = {
  eventTitle: "",
  eventType: "",
  startDate: new Date().toISOString().slice(0, 10),
  endDate: new Date().toISOString().slice(0, 10),
  peopleInvolved: Array as PropType<User[]>,
  location: "",
};

const handleEventTitle = (text: string) => (inserts.eventTitle = text);
const handleEventType = (text: string) => (inserts.eventType = text);
const handleStartDate = (date: string) => (inserts.startDate = date);
const handleEndDate = (date: string) => (inserts.endDate = date);
const handleDropdown = (users: []) => (inserts.peopleInvolved = users);
const handleLocation = (text: string) => (inserts.location = text);
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
        <SecondaryButton buttonName="Cancel" />
        <PrimaryButton buttonName="Save" :disabled="true" />
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
