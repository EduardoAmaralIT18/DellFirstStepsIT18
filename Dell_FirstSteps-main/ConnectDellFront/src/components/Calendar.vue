<script setup lang='ts'>
import { CalendarOptions, EventApi, DateSelectArg, EventClickArg } from '@fullcalendar/core'
import FullCalendar from '@fullcalendar/vue3'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'
import { onMounted, PropType, ref } from 'vue'
import Modal from './ModalEventInfo.vue'

enum PhaseType {
  "Setup",
  "Training",
  "Sprints",
  "HandsOn"
}

type TypeEvent = {
  id : Number
  name : String,
  eventType : Number,
  phaseType : Number,
  startDate : String,
  endDate : String,
  where : String,
  peopleInvolved : Array<String>
}

declare var DDS: any;


// let refer = ref(null);
// let list = ref();

// onMounted(() => {
//   refer.value = DDS.Popover(list.value);
// })

const handleEventClick = (info : EventClickArg) => {
  // refer.open();

  // console.log(info)
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
                phaseType: PhaseType[event.phaseType as number]
              }, 
      allDay: true,
      display: "multi-day",
      color: "#97DCF4",
      textColor: "#0E0E0E",}
    ]
  })
}

const Props = defineProps({
  startDate: String,
  endDate: String,
  events : Array as PropType<TypeEvent[]>,
})

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
  eventClick : handleEventClick,
  editable: true,
  refer: null
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
          <i>{{ arg.event.title }}</i> -->
          <Popover  ref="refer" :event="arg.event" id="idPop"></Popover>
        </template>
      </FullCalendar>
      
    </div>
  </div>


  <Modal></Modal>
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
