<template>
  <!--modal to show event details-->
  <!--Modal Ok para changeRole or removeUser-->
  <div role="dialog" data-dds="modal" class="dds__modal" ref="modalEventShow" aria-labelledby="modal-headline-153968555">
    <div class="dds__modal--md">
      <div class="dds__modal__content">
        <div class="dds__modal__header">
          <h3 class="dds__modal__title">{{ event.name }}</h3>
        </div>
        <div id="modal-body-357113985" class="dds__modal__body">
          <p>
            <strong>Event Type:</strong> {{ eventInfo }}
            <br>
            <strong>Start Date:</strong> {{ event.startDate }}
            <br>
            <strong>End Date:</strong> {{ event.endDate }}
            <br>
            <strong v-if="event.where != ''">Where:</strong> {{ event.where }}
          </p>
        </div>
        <p v-if="isOwner" class="editDelete" @click="$cookies.set('eventId', event.id)">
          <a id="exampleEdit" href="#" @click="modalEventShow.close()">Edit</a> 
        </p>
        <div class="dds__modal__footer">
          <button class="dds__button dds__button--md buttonModal" type="button" name="modal-secondary-button"
            @click="modalEventShow.close()">
            Ok
          </button>
        </div>
      </div>
    </div>
  </div>

  <!-- mudar a ref e o id do bota pra distinguir entre as modais -->
  <div role="dialog" data-dds="modal" class="dds__modal" id="editevent" ref="editevent">
    <div class="dds__modal__content">
      <div class="dds__modal__header">
        <h3 class="dds__modal__title title" id="modal-headline-369536123">

          Manage Event
          <!-- <h2 class="title">Add Event</h2> -->
        </h3>
      </div>
      <div id="modal-body-532887773" class="dds__modal__body">
        <EditEvent @close-modal.="modalEdit.close()" @load-events.="eventsGet()" :eventProp="this.event" />
      </div>
      <div class="dds__modal__footer">
        <!-- <button :class="buttonColor" type="button" name="modal-secondary-button"
                        @click="$router.push({ name: 'HomePage' });">Ok</button> -->
      </div>
    </div>
  </div>

  <div class="container">
    <p class="title">Edition's Calendar</p>
    <a v-if="isOwner" class="addevent dds__button dds__button--lg" type="submit" id="exampleAdd" style="color: white">
      Add Event
    </a>
    
    <!-- <div>
      <input type="checkbox" id="phases" checked><label for="phases">Phases</label>
      <input type="checkbox" id="activities" checked><label for="activities">Activities</label>
    </div> -->
    <!-- <a @click="options = !options">Change Options</a> -->
    <full-calendar class="calendar" :event-limit="2" :options="calendarOptions" />
  </div>

  <div role="dialog" data-dds="modal" class="dds__modal" id="addevent" ref="addevent">
    <div class="dds__modal__content">
      <div class="dds__modal__header">
        <h3 class="dds__modal__title title" id="modal-headline-369536123">
          Add Event
          <!-- <h2 class="title">Add Event</h2> -->
        </h3>
      </div>
      <div id="modal-body-532887773" class="dds__modal__body">
        <!-- estrutura do modal -->
        <AddEvent @close-modal.="modalAdd.close()" @load-events.="eventsGet()" />
      </div>
      <div class="dds__modal__footer">
        <!-- <button :class="buttonColor" type="button" name="modal-secondary-button"
    @click="$router.push({ name: 'HomePage' });">Ok</button> -->
      </div>
    </div>
  </div>
</template>

<script>
/*
TO DO:
- find out how to filter by type of event (phases and different events)
        idea: groupId to group the events, but still need to find out how to appear only a specific groupId or every single one of them
- checkbox to decide how to filter it (related to the to do above)
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
import EditEvent from '../components/EditEvent.vue'
import AddEvent from "../components/AddEvent.vue";
var DDS = window.DDS;

//1. In month View- Day shoudl be like- Monday, Tuesday instead of Mon, Tue
//2. Default load should be on Oct 2021, bcoz event starting from there.

export default defineComponent({
  components: {
    FullCalendar,
    EditEvent,
    AddEvent,
  },
  props: {
    eventDates: {
      type: Array,
      default: null,
    },
  },
  mounted() {
    this.createModalEdit();
    this.createModalAdd();
    this.modalEventShow = DDS.Modal(this.$refs.modalEventShow);
  },
  data() {
    return {
      //Cookies com id, startDate e endDate da edition
      cookiesEdit: this.$cookies.get("editionId"),
      cookiesProgram: this.$cookies.get("programId"),
      event: [],
      //Lista com os eventos da edição passado por param
      eventsList: [],
      options: true,
      modalEventShow: null,
      modal: null,

      eventInfo: '',

      calendarOptions: {
        plugins: [dayGridPlugin, interactionPlugin, listPlugin, timeGridPlugin],
        initialView: "timeGridWeek",
        headerToolbar: {
          left: "today prev,next",
          center: "title",
          right: "dayGridMonth,timeGridWeek,listWeek",
        },
        editable: true,
        selectable: true,
        selectMirror: true,
        views: {
          month: {
            dayMaxEventRows: 3
          }
        },
        moreLinkClick: "day",
        weekends: true,
        //COLOCAR ADD EVENT AQUI PARA APARECER SE CLICLAR NO DIA !!!!!!!!!!!!!!!!!!!!!
        //select: this.handleDateSelect,
        eventClick: this.handleEventClick,
        eventsSet: this.handleEvents,
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
      modalEdit: null,
      modalAdd: null,
      hasMultiSelect: false
    };
  },
  created() {
    this.eventsGet();
  },
  computed: {
    isOwner() {
      if (this.$cookies.get("isOwner") == 1)
        return true;
      else
        return false;
    },
  },
  methods: {

    eventsGet() {
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
            console.log("Entrou aqui");
          } else if (response.status == 204) {
            console.log("no content - no events in this edition");
          }
        });
    },

    handleEventClick(clickInfo) {
      this.showEvent(clickInfo.event.id);
      this.$cookies.set('eventId', clickInfo.event.id);
    },

    handleEvents(events) {
      this.currentEvents = events
    },

    showEvent(id) {
      axios.get('event/getEventToUpdate?eventId=' + id)
        .then(function (response) {
          return response;
        })
        .then((response) => {
          if (response.status == 200) {
            this.event = response.data;
            this.eventInfo = this.eventAndPhaseType(this.event.eventType, this.event.phaseType);
            this.modalEventShow.open();
            if (this.event.eventType == 0) {
              this.event.startDate = new Date(response.data.startDate).toISOString().slice(0, 10);
              if (this.event.endDate != null) {
                this.event.endDate = new Date(response.data.endDate).toISOString().slice(0, 10);
              }
            } else {
              this.event.startDate = new Date(response.data.startDate).toISOString().slice(0, 16);
              if (this.event.endDate != null) {
                this.event.endDate = new Date(response.data.endDate).toISOString().slice(0, 16);
              }
            }

          } else {
            //erro
          }
        });
    },

    eventAndPhaseType(EventType, PhaseType) {
      //eventType: ["Phase", "Activity"],
      //phaseType: ["Set_Up", "Training", "Sprints", "HandsOn", "None"],
      let eventandphase;
      if (EventType == 1) {
        console.log("entrei no if de activity");
        return "Activity";
      } else {
        console.log("entrei no if de phase");
        switch (PhaseType) {
          case 0:
            eventandphase = "Phase - Set_Up";
            break;
          case 1:
            eventandphase = "Phase - Training";
            break;
          case 2:
            eventandphase = "Phase - Sprints";
            break;
          case 3:
            eventandphase = "Phase - HandsOn";
            break;
        }
        return eventandphase;
      }
    },

    createModalEdit() {
      const element = this.$refs.editevent;
      //console.log(element);
      console.log(DDS);
      console.log(element);
      this.modalEdit = new DDS.Modal(element, { trigger: "#exampleEdit" });
      console.log(this.modalEdit);
    },
    eventDescription() {
      //Swal parace um metodo de add? Nome do evento?
      swal("teste");
    },
    createModalAdd() {//add
      const element = this.$refs.addevent;
      //console.log(element);
      console.log(DDS);
      console.log(element);
      this.modalAdd = new DDS.Modal(element, { trigger: "#exampleAdd" });
      console.log(this.modalAdd);
    },

    //addEvent() {
    //     this.calendarOptions.events = [
    //         ...this.calendarOptions.events,
    //         { title: 'Another Event', date: '2023-02-13' }
    //     ];
    //},

    loadEvents() {
      this.calendarOptions.events = [];
      this.eventsList.forEach((element) => {
        if (element.eventType == 0) {
          console.log(element.calendarEndDate),
            (this.calendarOptions.events = [
              ...this.calendarOptions.events,
              {
                id: element.id,
                title: element.name,
                start: element.startDate,
                end: element.calendarEndDate,

                extendedProps: {
                  where: element.where,
                  phaseType: element.phaseType,
                },

                //Tentativas de Mudar de cor
                // if(phaseType == 0) {
                //   color: "#FFEED2",
                // } //Set_up
                // if(phaseType == 1) {
                //   color: "#E9F5CE",
                // }, //Training
                // if(phaseType == 2) {
                //   color: "#DAF5FD",
                // }, //Sprints
                // if(phaseType == 3) {
                //   color: "#FFECEE",
                // }, //Hands-on

                allDay: true,
                display: "multi-day",
                color: "#97DCF4",
                textColor: "#0E0E0E",
              },
            ]);
        } else if (element.eventType == 1) {
          this.calendarOptions.events = [
            ...this.calendarOptions.events,
            {
              id: element.id,
              title: element.name,
              start: element.startDate,
              end: element.endDate,

              extendedProps: {
                where: element.where,
              },

              display: "block",
              backgroundColor: "#0672CB",
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

.dds__modal--md {
  position: fixed;
  bottom: 0px;
  right: 0px;
  margin: 0px;
}


.dds__modal {
  background: none;
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

a {
  text-decoration: none;
}

a :hover {
  text-decoration: none;
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

.fc-icon {
  speak: none;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  display: inline-block;
  font-family: fcicons !important;
  font-style: normal;
  font-variant: normal;
  font-weight: 400;
  height: 1em;
  line-height: 1;
  text-align: center;
  text-transform: none;
  -webkit-user-select: none;
  -moz-user-select: none;
  user-select: none;
  width: 1em;
  color: white;
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

.dds__modal__content {
  width: 800px;
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

.editDelete {
  position: relative;
  text-decoration: none;
  color: #0672CB;
  font-weight: 300;
  text-decoration: none;
}
</style>
