<script setup lang='ts'>
import { CalendarOptions } from '@fullcalendar/core'
import FullCalendar from '@fullcalendar/vue3'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'
import { onMounted, PropType, ref, watch } from 'vue'
import Modal from './ModalEventInfo.vue'
import type User from '@/interfaces/User'

const Props = defineProps({
  startDate: String,
  endDate: String,
  events : Array as PropType<TypeEvent[]>,
  editionUsers: Array as PropType<User[]>
})

const emits = defineEmits({
  sendDate: Object,
});

const keyCalendar = ref(0)
const userRole = ref(+localStorage.getItem('userRole')!);
let eventToPass = ref();
let selectCheck = ref(["Phase","Activity"])


type TypeEvent = {
  id : Number,
  name : String,
  eventType : Number,
  phaseType : Number,
  startDate : Date,
  endDate : Date,
  where : String
}

let toggleEventClick = ref(false);
const handleEventClick = (args: any) => {
  argsToTypeEvent(args);
  toggleEventClick.value = !toggleEventClick.value;
}

const handleDateSelect = (info : any) => {
  if(userRole.value === 0) {
    emits("sendDate", {
      startDate: new Date(info.startStr),
      endDate: new Date(info.endStr) 
    });
  }
}


function argsToTypeEvent(e: any) {
  eventToPass.value = {
    id : e.event._def.publicId,
    name : e.event._def.title,
    eventType : e.event._def.extendedProps.eventType,
    phaseType : e.event._def.extendedProps.phaseType,
    endDate : e.event._def.extendedProps.end,
    startDate : e.event._def.extendedProps.start,
    where : e.event._def.extendedProps.where,
  }
}

function loadEvent() {
  calendarOptions.value.events = [];
  Props.events?.forEach(
    (event) => {
      if(event.eventType === 0) {
        calendarOptions.value.events = [...calendarOptions.value.events, {
        id : event.id, 
        title : event.name, 
        start: event.startDate, 
        end: event.endDate, 
        extendedProps: {
          where : event.where, 
          eventType: event.eventType,
          phaseType: event.phaseType,
          start: event.startDate, 
          end: event.endDate,
        },
        allDay: true,
        display: "multi-day",
        borderColor: "#7E7E7E",
        color: "#61C1EB",
        textColor: "#0E0E0E"
      }
    ]}
    else if(event.eventType === 1) {
      calendarOptions.value.events = [...calendarOptions.value.events, {
        id : event.id, 
        title : event.name, 
        start: event.startDate, 
        end: event.endDate, 
        extendedProps: {
          where : event.where, 
          eventType: event.eventType,
          phaseType: event.phaseType,
          start: event.startDate, 
          end: event.endDate,
        },
        display: "multi-day",
        color: '#61C1EBF69AC6',
        borderColor: "#7E7E7E",
        textColor: "#0E0E0E"
      }]
    }
  })
}

watch(selectCheck,() => {
  checkEvent();
})

const checkEvent = () => {
  let checkMultiDayPhase = false;
  let checkMultiDayActivity = false;
  (calendarOptions.value.events as Array<any>).forEach((event) => {
    if (selectCheck.value.length !== 0) {
      selectCheck.value.forEach((check) => {
        if(event.extendedProps.eventType === 0) {
          if(check === "Phase") {
            event.display = "multi-day";
            checkMultiDayPhase = true;
          }
          else if(!checkMultiDayPhase)
            event.display = "none";
        }
        else if(event.extendedProps.eventType === 1) {
          if(check === "Activity") {
            event.display = "multi-day";
            checkMultiDayActivity = true;
          }
          else if (!checkMultiDayActivity) 
            event.display = "none";
        }
      })
    }
    else
      event.display = "none";
  })
}

const calendarOptions = ref({
  plugins: [
    dayGridPlugin,
    timeGridPlugin,
    interactionPlugin 
  ],
  eventTimeFormat: {
    hour: 'numeric',
    minute: '2-digit',
    meridiem: 'short'
  },
  headerToolbar: {  
    left: 'prev,next today',
    center: 'title',
    right: 'dayGridMonth,timeGridWeek'  
  },
  initialView: 'timeGridWeek',
  selectable: true,
  eventClick: handleEventClick,
  select: handleDateSelect
} as CalendarOptions);

function createValidRange() {
  calendarOptions.value.validRange = {
    start: Props.startDate,
    end: Props.endDate
  }
}


onMounted(() => {
  setTimeout(() => {
    createValidRange()
    loadEvent()
  }, 1000);
})

</script>

<template>
  <!-- <div class='component'> -->
    <div class='component-main'>
      <div class="checkbox-layout">
          <label class="dds__checkbox__label" for="phase">
            <input
              type="checkbox"
              id="phase"
              class="dds__checkbox__input"
              value="Phase"
              v-model="selectCheck"
            />
            <span class="test">Phase</span>
          </label>
          <label class="dds__checkbox__label" for="activity">
            <input
              type="checkbox"
              id="activity"
              class="dds__checkbox__input"
              value="Activity"
              v-model="selectCheck"
            />
            <span>Activity</span>
          </label>
      </div>
      <div>
      <FullCalendar
        class='calendar'
        :id="keyCalendar"
        :options='calendarOptions'
      >
        <template v-slot:eventContent='arg'>
          <b>{{ arg.event.id}}</b>
          <i class="eventBox">{{ arg.event.title }}</i>
          <Modal v-if="toggleEventClick" 
            :event="eventToPass"
            :editionUsers="Props.editionUsers"></Modal>
        </template>
      </FullCalendar>
      </div>
    </div>
  <!-- </div> -->
  
</template>


<style lang='css'>

.fc { /* the calendar root */
  
  --fc-today-bg-color: rgba(13,118,178,.2);
  --fc-button-bg-color:#00468B;
  --fc-button-border-color: #002A58;
  --fc-button-hover-bg-color: #002A58;
  --fc-button-hover-border-color: #002A58;
  --fc-button-active-bg-color: #002A58;
  --fc-button-active-border-color: #002A58;
}

a.fc-event {
  overflow: hidden;
  text-overflow: ellipsis;
}

.component-main {
  max-width: 100%;
  min-width: 90%;
  font-family: Roboto;
  font-size: 14px;
  font-weight: 400;
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
  justify-content: center;
}

.checkbox-layout {
  align-self: flex-start;
  display: flex;
  flex-direction: row;
  align-items: center;
  background-color: #00468B;
  border-color: #002A58;
  border-radius: 4px;
  max-width: 1184px;
}

.dds__checkbox__input + span {
  font-size: inherit;
  color: white;
  font-weight: 400;
}

.dds__checkbox__input:checked + span::before {
  background-color: #002A58;
}


h2 {
  margin: 0;
  font-size: 16px;
  font-family: Roboto;
  font-weight: 400;
}

ul {
  margin: 0;
  padding: 0 0 0 1.5em;
}

li {
  margin: 1.5em 0;
  padding: 0;
}

b { /* used for event dates/times */
  margin-right: 3px;
}
</style>
