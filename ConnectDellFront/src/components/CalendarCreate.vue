<template>
    <!-- <NavBar />
                <SideBar /> -->
    <div class="container">
        <a @click="addEvent()">Add Event</a>
        <a @click="options = !options">Change Options</a>
        <a id="example">EDIT</a>
        <full-calendar class="calendar" :event-limit="2" :options="calendarOptions" />
    </div>

<!-- mudar a ref e o id do bota pra distinguir entre as modais -->
    <div role="dialog" data-dds="modal" class="dds__modal" id="uniqueid" ref="uniqueid">
        <div class="dds__modal__content">
            <div class="dds__modal__header">
                <h3 class="dds__modal__title title" id="modal-headline-369536123">

                    Manage Event
                    <!-- <h2 class="title">Add Event</h2> -->
                </h3>
            </div>
            <div id="modal-body-532887773" class="dds__modal__body">
                <EditEvent @close-modal.="modal.close()" />
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
- style it according to DDS
- form to add events (how to add, there is already a method as example, just do v-model on form inputs to insert it according to the user input)
- do get to show description on the alert (sweetalert)
- get with axios of events on database
- change model to be adpted to events attributes?
- id on front, to each event, to know which one is it on the date

*/




//References: https://fullcalendar.io/docs





import { defineComponent } from 'vue';

import swal from 'sweetalert';

import FullCalendar from "@fullcalendar/vue3";
import dayGridPlugin from "@fullcalendar/daygrid";
import timeGridPlugin from "@fullcalendar/timegrid";
import interactionPlugin from "@fullcalendar/interaction";
import listPlugin from "@fullcalendar/list";
import EditEvent from '../components/EditEvent.vue'
var DDS = window.DDS;


// 1. In month View- Day shoudl be like- Monday, Tuesday instead of Mon, Tue
//2. Default load should be on Oct 2021, bcoz event starting from there.

export default defineComponent({
    components: {
        FullCalendar,
        EditEvent
    },
    props: {
        eventDates: {
            type: Array,
            default: null,
        },
    },
    mounted() {
        this.createModal();
    },
    data() {
        return {
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
                events: [

                    //Colocar os itens da lista de eventos

                    {
                        start: "2023-02-10T04:30:00",
                        title: "Test",
                        end: "2023-02-11T14:30:00",
                    },
                    {
                        start: "2023-02-08T04:30:00",
                        title: "Test",
                        end: "2023-02-10T14:30:00",
                    },
                    {
                        start: "2023-02-08T04:30:00",
                        title: "Test",
                        end: "2023-02-10T14:30:00",
                    },
                    {
                        start: "2023-02-15T04:30:00",
                        title: "It should be default load",
                        end: "2023-02-18T14:30:00",
                    },
                ],
                eventClick: function (event) {
                    swal('Event: ' + event.event.title);

                },
                eventDisplay: "block",
                displayEventTime: false,
                allDaySlot: false,
                buttonText: {
                    today: "Today",
                    month: "Month",
                    week: "Week",
                    list: "Agenda",
                },
            },
            modal: null
        };
    },
    methods: {
        eventDescription() {

            //Swal parace um metodo de add? Nome do evento?

            swal("teste");
        },
        addEvent() {
            this.calendarOptions.events = [
                ...this.calendarOptions.events,
                { title: 'Another Event', date: '2023-02-13' }
            ];
        },
        createModal() {
            const element = this.$refs.uniqueid;
            //console.log(element);
            console.log(DDS);
            console.log(element);
            this.modal = new DDS.Modal(element, { trigger: "#example" });
            console.log(this.modal);
        },
        computed: {
            optionsComputed() {
                if (this.options) {
                    this.calendarOptions.events = [


                        //Info dos eventos

                        {
                            start: "2023-02-10T04:30:00",
                            title: "Test",
                            end: "2023-02-11T14:30:00",
                        },
                        {
                            start: "2023-02-08T04:30:00",
                            title: "Test",
                            end: "2023-02-10T14:30:00",
                        },
                        {
                            start: "2023-02-08T04:30:00",
                            title: "Test",
                            end: "2023-02-10T14:30:00",
                        },
                        {
                            start: "2023-02-15T04:30:00",
                            title: "It should be default load",
                            end: "2023-02-18T14:30:00",
                        },
                    ]
                } else {
                    this.calendarOptions.events = [
                        {
                            start: "2023-02-15T04:30:00",
                            title: "It should be default load",
                            end: "2023-02-18T14:30:00",
                        }
                    ]
                }

            }
        }

    },
});
</script>
<style scoped>
body {
    font-family: 'Roboto', sans-serif;
}


/* Adicionar Styles para os botões, seguindo o padrão da Dell */


.container {
    padding-top: 1%;
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

.dds__modal__content {
  width: 800px;
}

.title {
  color: #0063b8;
  font-weight: 500;
  max-width: 1024px;
  padding-left: 40px;
  padding-right: 40px;
}
</style>