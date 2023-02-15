

<template>
    <!-- <NavBar />
    <SideBar /> -->
    <div class="container">
        <a @click="addEvent()">Add Event</a>
        <a @click="options = !options">Change Options</a>
        <full-calendar class="calendar" :event-limit="2" :options="calendarOptions" />
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
// import NavBar from '../components/NavBar.vue';
// import SideBar from '../components/SideBar.vue';
import { defineComponent } from 'vue';

import swal from 'sweetalert';

import FullCalendar from "@fullcalendar/vue3";
import dayGridPlugin from "@fullcalendar/daygrid";
import timeGridPlugin from "@fullcalendar/timegrid";
import interactionPlugin from "@fullcalendar/interaction";
import listPlugin from "@fullcalendar/list";
// 1. In month View- Day shoudl be like- Monday, Tuesday instead of Mon, Tue
//2. Default load should be on Oct 2021, bcoz event starting from there.

export default defineComponent({
    components: {
        FullCalendar,
        // NavBar,
        // SideBar
    },
    props: {
        eventDates: {
            type: Array,
            default: null,
        },
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
        };
    },
    methods: {
        eventDescription() {
            swal("teste");
        },
        addEvent() {
            this.calendarOptions.events = [
                ...this.calendarOptions.events,
                { title: 'Another Event', date: '2023-02-13' }
            ];
        },
        computed: {
            optionsComputed() {
                if (this.options) {
                    this.calendarOptions.events = [
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

.container {
    padding-top: 5%;
    padding-left: 15%;
    display: inline-flex;
    flex-direction: column;
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
</style>