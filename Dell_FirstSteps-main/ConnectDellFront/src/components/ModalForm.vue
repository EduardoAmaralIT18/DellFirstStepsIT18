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
  eventId: Number,
  buttonText: String,
  eventTitle: String,
  eventType: Number,
  modalTitle: String,
  editionUsers: Array as PropType<User[]>,
  eventStartDate: Date,
  eventEndDate: Date,
  peopleInvolved: Array as PropType<User[]>,
  location: String,
  editMode: Boolean,
  editionStartDate: String,
  editionEndDate: String
});

const emits = defineEmits({
  sendBodyToParent: Object,
  closeModal: Object
});

const modal = ref();
const element = ref(null);
const key = ref(0);
const activateButton = ref(true);

const inserts = ref({
  eventId: props.eventId,
  eventTitle: "",
  eventType: -1,
  startDate: props.editionStartDate!,
  endDate: props.editionEndDate!,
  peopleInvolved: new Array(),
  location: "",
  editionAux: props.editionStartDate!,
});

onMounted(() => {
  modal.value = DDS.Modal(element.value);
  console.log(props.editMode);
  if (props.editMode) activateButton.value = true;
  openModal()
});

watchEffect(() => {
  if (inserts.value.eventTitle !== "" && inserts.value.eventType !== -1 && validateDate()) {
    activateButton.value = false;
    console.log("false");
  } else {
    activateButton.value = true;
  }
});

function validateDate():Boolean{
  if(inserts.value.startDate=== "" && inserts.value.endDate===""){
    return false;
  }
  if(new Date(inserts.value.endDate) < new Date(inserts.value.startDate)){
    return false;
  }
  if(new Date(inserts.value.endDate) > new Date(props.editionEndDate!) || new Date(inserts.value.startDate) < new Date(inserts.value.editionAux)){
    return false;
  }
  return true;
}

function sendBodyToParent() {
  emits("sendBodyToParent", inserts.value);
}

const handleEventTitle = (text: string) => {
  text = text.trim();
  inserts.value.eventTitle = text;
};
const handleEventType = (text: string) => {
  console.log(text);
  if (text === "Phase") inserts.value.eventType = 0;
  if (text === "Activity") inserts.value.eventType = 1;
};
const handleStartDate = (date: string) => {
  const dateaux= new Date(date).toISOString().slice(0,10);
  inserts.value.editionAux=new Date(props.editionStartDate!).toISOString().slice(0,10);
  inserts.value.startDate = dateaux;
}
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

const checkEventType = () => {
  return props.eventType === -1;
};

function openModal() {
  modal.value.open()
}

const phaseList = ["Phase", "Activity"];

function resetInputs() {
  inserts.value.eventTitle = "";
  inserts.value.eventType = -1;
  inserts.value.startDate = new Date().toISOString().slice(0, 10);
  inserts.value.endDate = new Date().toISOString().slice(0, 10);
  inserts.value.peopleInvolved = [];
  inserts.value.location = "";
  emits("closeModal", false);
  key.value++;
}
</script>

<template>
  <div
    role="dialog"
    ref="element"
    data-dds="modal"
    class="dds__modal"
    aria-labelledby="modal-headline-160350263"
  >
    <div class="dds__modal__content">
      <div class="dds__modal__header" @click="resetInputs()">
        <h3 class="dds__modal__title">
          {{ modalTitle }}
        </h3>
      </div>

      <div class="dds__modal__body" :key="key">
        <TextInput
          maxlength="30"
          boxName="Event Title"
          @typedText="handleEventTitle"
          :initial-value="props.eventTitle"
        />
        <Select
          :placeholder="checkEventType() ? 'Event Type' : phaseList[props.eventType!] "
          v-bind:required="true"
          :list="phaseList"
          selectTitle="Event Type"
          ref="inserts.eventType"
          @selectedValue="handleEventType"
        ></Select>
        <div class="date-container">
          <DatePicker
            boxName="Start Date"
            v-bind:required="true"
            :initialDate="props.editionStartDate?.slice(0,10)"
            @selectedDate="handleStartDate"
          />
          <DatePicker
            boxName="End Date"
            v-bind:required="true"
            :date-now="true"
            :initialDate="props.editionEndDate?.slice(0,10)"
            @selectedDate="handleEndDate"
          />
        </div>
        <Dropdown
          dropdownName="People Involved"
          :data="props.editionUsers"
          :peopleInvolved="props.editionUsers"
          :selected="props.peopleInvolved"
          @selectedId="handleDropdown"
        />
        <TextArea
          @description-text="handleLocation"
          maxlength="120"
          boxName="Location"
          :required="false"
          :description="props.location"
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
          :disabled="activateButton"
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
