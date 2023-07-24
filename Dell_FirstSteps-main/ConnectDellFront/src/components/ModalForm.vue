<template>

<PrimaryButton buttonName="Add Event" @click="modal.open()">  </PrimaryButton>
<div role="dialog" ref="list" data-dds="modal" class="dds__modal" aria-labelledby="modal-headline-160350263">
  <div class="dds__modal__content">
    <div class="dds__modal__header"><h3 class="dds__modal__title" id="modal-headline-160350263">{{ modalTitle }}</h3></div>
    <div id="modal-body-754450445" class="dds__modal__body">
      <p>
       <TextInput maxlength="30" boxName="Event Title" @typedText="handleEventTitle"></TextInput>
       <Select v-bind:required="true" :list="selectList" selectTitle="Event Type" @selectValue="handleEventType"></Select>
       <div class="date-container">
            <DatePicker boxName="Start Date" v-bind:required="true"></DatePicker>
            <DatePicker boxName="End Date" v-bind:required="true"></DatePicker>
        </div>
        <Dropdown dropdownName="People Involved" :data="editionUsers" @selectedId="handleDropdown"/>
        <TextArea maxlength="120" boxName="Location" :required="false"></TextArea>
      </p>
    </div>
    <div class="dds__modal__footer">
    <SecondaryButton buttonName="Cancel" ></SecondaryButton>
    <PrimaryButton buttonName="Save" :disabled="true"></PrimaryButton>  
    </div>
  </div>
</div>
</template>

<script setup lang="ts">
import { onMounted, PropType, ref } from 'vue';
import TextInput from "./TextInput.vue";
import PrimaryButton from "./PrimaryButton.vue"
import Select from "./Select.vue"
import DatePicker from "./DatePicker.vue"
import Dropdown from "./Dropdown.vue"
import User from '@/interfaces/User';
import TextArea from './TextArea.vue';
import SecondaryButton from "./SecondaryButton.vue"

declare var DDS: any;
const props = defineProps({
    modalTitle: String,
    editionUsers: Array as PropType<User[]>
});
const selectList=["Phase","Activity"]
const modal= ref()
const list = ref(null)
onMounted(() => {
    modal.value = DDS.Modal(list.value);
})

const inserts={
    eventTitle:"",
    eventType:"",
    startDate:new Date().toISOString().slice(0, 10),
    endDate:new Date().toISOString().slice(0, 10),
    peopleInvolved: Array as PropType<User[]>,
    location:""
}

function handleEventTitle(text: string): void {
            inserts.eventTitle = text;
            console.log(inserts.eventTitle);
        }
function handleEventType(text: string): void {
            inserts.eventType = text;
            console.log(inserts.eventType);
        }
// function handleStartDate(date: string): void {
//             inserts.startDate = date;
//             console.log(inserts.startDate);
//         }
// function handleEndDate(date: Date): void {
//             inserts.endDate=date;
//             console.log(inserts.endDate);
//         }
// function handleDropdown(users: []): void {   
//             inserts.peopleInvolved = users;
//             users.forEach(id =>{
//                 inserts.peopleInvolved?.push(editionUsers.find(user => user.id === id));
//             }) 
//             console.log(inserts.peopleInvolved);
//         }

</script>

<style scoped>
.dds__modal__header .dds__modal__title{
    color: #0672CB;
    font-weight: 500;
}
.dds__modal__content{
    width: 30%;
}
.date-container {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}
</style>