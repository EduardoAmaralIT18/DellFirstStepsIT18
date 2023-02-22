<template>
  <div class="container">
    <p class="title">Edition's Calendar</p>
    <button
      class="addevent dds__button dds__button--lg"
      type="submit"
      @click="addEvent()"
    >
      Add Event
    </button>
    <!-- <a @click="options = !options">Change Options</a> -->
    <full-calendar
      class="calendar"
      :event-limit="2"
      :options="calendarOptions"
    />
  </div>
</template>

<script>
/*
TO DO:
- find out how to filter by type of event (phases and different events)
        idea: groupId to group the events, but still need to find out how to appear only a specific groupId or every single one of them
- checkbox to decide how to filter it (related to the to do above)
- style it according to DDS
- form to add events (how to add, there is already a method as example, just do v-model on form inputs to insert it according to the user input)
- do get to show description on the alert (sweetalert)
- get with axios of events on database
- change model to be adpted to events attributes?
- id on front, to each event, to know which one is it on the date

*/

//References: https://fullcalendar.io/docs

import { defineComponent } from "vue";

import swal from "sweetalert";

import axios from "axios";
import FullCalendar from "@fullcalendar/vue3";
import dayGridPlugin from "@fullcalendar/daygrid";
import timeGridPlugin from "@fullcalendar/timegrid";
import interactionPlugin from "@fullcalendar/interaction";
import listPlugin from "@fullcalendar/list";

//1. In month View- Day shoudl be like- Monday, Tuesday instead of Mon, Tue
//2. Default load should be on Oct 2021, bcoz event starting from there.

export default defineComponent({
  components: {
    FullCalendar,
  },
  props: {
    eventDates: {
      type: Array,
      default: null,
    },
  },
  data() {
    return {
      //Cookies com id, startDate e endDate da edition
      cookiesEdit: this.$cookies.get("editionId"),

      //Lista com os eventos da edição passado por param
      eventsList: [],

      options: true,
      calendarOptions: {
        // views: {
        //    dayGrid: {
        //       weekday: 'long'
        //    }
        // },
        plugins: [dayGridPlugin, interactionPlugin, listPlugin, timeGridPlugin],
        initialView: "dayGridMonth",
        headerToolbar: {
          left: "today prev,next",
          center: "title",
          right: "dayGridMonth,timeGridWeek,listWeek",
        },

        events: [],

        validRange: {
            start: this.$cookies.get("startDateEdition"),
            end: this.$cookies.get("endDateCalendarEdition"),
        },

        buttonText: {
          today: "Today",
          month: "Month",
          week: "Week",
          list: "Agenda",
        },
      },
    };
  },

  created() {
    axios
      .get(`/Event/getAllEvents?editionId=${this.cookiesEdit}`)
      .then(function (response) {
        return response;
      })
      .then((response) => {
        if (response.status == 200) {
          // this.calendarOptions.events = response.data;
          this.eventsList = response.data;
          this.loadEvents();
        } else if (response.status == 204) {
          alert("There was an error on our database! Please, try again later.");
        }
      });
  },

  methods: {
    eventDescription() {
      //Swal parace um metodo de add? Nome do evento?
      swal("teste");
    },

    //addEvent() {
    //     this.calendarOptions.events = [
    //         ...this.calendarOptions.events,
    //         { title: 'Another Event', date: '2023-02-13' }
    //     ];
    //},

    loadEvents() {
      this.eventsList.forEach((element) => {
        if (element.eventType == 0) {
          this.calendarOptions.events = [
            ...this.calendarOptions.events,
            {
              title: element.name,
              //formato do start: '2023-02-02',
              //date do BD: 2022-08-10 00:00:00.0000000
              start: element.startDate,
              end: element.endDate,

              extendedProps: {
                where: element.where,
                phaseType: element.phaseType,
              },

              allDay: true,
              display: "background",
              color: "#94DCF7",
            },
          ];
        } else if (element.eventType == 1) {

          this.calendarOptions.events = [
            ...this.calendarOptions.events,
            {
              title: element.name,
              start: element.startDate,
              end: element.endDate,

              extendedProps: {
                where: element.where,
              },

              display: "block",
              backgroundColor: "#31A2E3",
              borderColor: "#7E7E7E",
            },
          ];
        }
      });

      // Fim do load events
    },
  },
});
</script>
<style>
body {
  font-family: "Roboto", sans-serif;
  font-weight: inherit;
  line-height: inherit;
}

.addevent {
  width: 140px;
  font-size: 13px;
  height: 8%;
  margin-left: auto;
  padding: 4px;
  margin-bottom: 1.5%;
  display: flex;
  float: right;
  margin-top: 9px;
}

.title {
  color: #0672cb;
  font-size: 190%;
  text-align: left;
  margin-top: 10px;
}

.title {
  margin-left: 0px !important;
  text-align: left;
  color: #0672cb;
  margin: 2.5%;
  font-weight: bold;
}

.container {
  padding-top: 0%;
  padding-left: 15%;
  display: inline-flex;
  flex-direction: column;
  padding-bottom: 5%;
}

.fc .fc-button .fc-icon {
  vertical-align: bottom !important;
}

.fc-event {
  min-height: 45px;
}

.fc-event-main,
.fc-event-title {
  white-space: pre-wrap;
}

.fc-event-title-container {
  padding: 2px 6px;
}

.fc .fc-button-primary {
  background-color: #0672cb;
  border-color: #0063b8;
  color: var(--fc-button-text-color);
}

.fc .fc-button {
  background-color: #0672cb;
  /* border: 1px #0063b8; */
  border-radius: 0.25em;
  display: inline-block;
  font-size: 0.9em;
  font-weight: normal;
  line-height: 1.5;
  padding: 0.4em 0.65em;
  text-align: center;
  -webkit-user-select: none;
  -moz-user-select: none;
  user-select: none;
  vertical-align: middle;
}

.fc .fc-button-primary:not(:disabled).fc-button-active,
.fc .fc-button-primary:not(:disabled):active {
  background-color: #0063b8;
  border-color: #0063b8;
  color: var(--fc-button-text-color);
}

:root {
  --fc-button-hover-bg-color: #0063b8;
  --fc-button-hover-border-color: #0063b8;
  --fc-button-active-bg-color: #0063b8;
  --fc-button-active-border-color: #0063b8;

  /* Cor do dia atual */
  --fc-today-bg-color: transparent;
}
</style>
