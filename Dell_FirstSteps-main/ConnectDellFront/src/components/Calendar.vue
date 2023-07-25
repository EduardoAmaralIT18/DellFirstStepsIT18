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
  where : String,
  peopleInvolved : Array<String>
}


let aux = ref(false);
const handleEventClick = () => {
  aux.value = !aux.value;
}

function argToTypeEvent(event: any) {
  console.log(event.end)
  let newEvent = {
    id : event.id,
    name : event.title,
    eventType : event.extendedProps.eventType,
    phaseType : event.extendedProps.phaseType,
    endDate : event.end,
    startDate : event.start,
    where : event.extendedProps.where,
  }
  return newEvent;
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
                phaseType: event.phaseType
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
    interactionPlugin // needed for dateClick
  ],
  headerToolbar: {  // botoes
    left: 'prev,next today',
    center: 'title',
    right: 'dayGridMonth,timeGridWeek,timeGridDay'  // parte dos imports
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
  <div class='demo-app'>
    <div class='demo-app-main'>
      <FullCalendar
        class='demo-app-calendar'
        :options='calendarOptions'
      >
        <template v-slot:eventContent='arg'>
          <b>{{ arg.event.id }}</b>
          <i>{{ arg.event.title }}</i>
          <Modal :event="argToTypeEvent(arg.event)" v-if="aux"></Modal>
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

.demo-app {
  display: flex;
  min-height: 100%;
  font-family: Roboto;
  font-size: 14px;
  font-weight: 400;
}

.demo-app-main {
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
