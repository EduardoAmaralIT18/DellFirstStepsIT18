<script setup lang='ts'>
import { CalendarOptions, EventApi, DateSelectArg, EventClickArg, type EventSourceInput } from '@fullcalendar/core'
import FullCalendar from '@fullcalendar/vue3'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'
import { onMounted, PropType, ref } from 'vue'
import Modal from './ModalEventInfo.vue'

const Props = defineProps({
  startDate: String,
  endDate: String,
  events : Array as PropType<TypeEvent[]>,
})

enum PhaseType {
  "Setup",
  "Training",
  "Sprints",
  "HandsOn"
}

enum EventType {
  "Phase",
  "Activity"
}
     
type TypeEvent = {
  id : Number,
  name : String,
  eventType : Number,
  phaseType : Number,
  startDate : Date,
  endDate : Date,
  where : String
}

let eventToPass = ref();

let aux = ref(false);
const handleEventClick = (args: any) => {
  argsToTypeEvent(args);
  aux.value = !aux.value;
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
  calendarOptions.events = [];
  Props.events?.forEach(
    (event) => {calendarOptions.events = [...calendarOptions.events, {
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
      color: "#97DCF4",
      textColor: "#0E0E0E"
      
    }
    ]
    console.log(calendarOptions.events[0].end)
  })
}


const calendarOptions = {
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
  customButtons: {
    buttonAddEvent: {
      text: 'Add Event',
      click: function() {
        //TODO chamar componente criar evento
      }
    }
  },
  headerToolbar: {  
    left: 'prev,next today',
    center: 'title',
    right: 'dayGridMonth,timeGridWeek,timeGridDay buttonAddEvent'  
  },
  initialView: 'dayGridMonth',
  validRange: {
    start: Props.startDate,
    end: Props.endDate,
  },
  eventClick: handleEventClick
} as CalendarOptions;


loadEvent()

</script>

<template>
  <div class='component'>
    <div class='component-main'>
      <FullCalendar
        class='calendar'
        :options='calendarOptions'
      >
        <template v-slot:eventContent='arg'>
          <b>{{ arg.event.id}}</b>
          <i>{{ arg.event.title }}</i>
          <Modal :event="eventToPass" v-if="aux"></Modal>
        </template>
      </FullCalendar>
    </div>
  </div>
  
</template>


<style lang='css'>

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

.component {
  display: flex;
  min-height: 100%;
  font-family: Roboto;
  font-size: 14px;
  font-weight: 400;
}

.component-main {
  flex-grow: 1;
  padding: 3em;
}

.fc { /* the calendar root */
  max-width: 1100px;
  margin: 0 auto;
  --fc-today-bg-color: rgba(13,118,178,.2);
  --fc-button-bg-color:#00468B;
  --fc-button-border-color: #002A58;
  --fc-button-hover-bg-color: #002A58;
  --fc-button-hover-border-color: #002A58;
  --fc-button-active-bg-color: #002A58;
  --fc-button-active-border-color: #002A58;
}


</style>
