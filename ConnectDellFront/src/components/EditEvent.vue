<template></template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useVuelidate } from '@vuelidate/core';
import { required, maxLength } from '@vuelidate/validators';
import axios from "axios";
declare var DDS: any;


interface Data {
    event: Event,
    eventId: number
}

type Event = {
    id: number,
    name: string,
    startDate: Date | null,
    endDate: Date | null,
    phaseType: number | string,
    eventType: number | string,
    where: string,
    peopleInvolved: User | null,
    edition: Edition | null,
};

type User = {
    id: number,
    name: string
}[];

type Edition = {
    id: number
};

export default defineComponent({
    data(): Data {
        return {
            event: {
                id: 0,
                name: "",
                startDate: null,
                endDate: null,
                phaseType: 0,
                eventType: 0,
                where: "",
                peopleInvolved: [],
                edition: null,
            },
            eventId: this.$cookies.get("eventId")
        }
    },
    setup() {
        return {
            v$: useVuelidate(),
        }
    },
    validations() {
        return {
            event: {
                name: { required, maxLength: maxLength(30) },
                eventType: { required },
                startDate: { required },
                endDate: { required }
            }
        }
    },
    created() {
        axios.get('event/getEventToUpdate?eventId=' + this.eventId)
            .then(function (response) {
                return response;
            })
            .then((response) => {
                if (response.status == 200) {
                    this.event = response.data;
                } else {
                    //erro
                }
            })
    },
    methods: {
        onSubmit() {
            axios.post('event/updateEvent', this.event)
                .then(function (response) {
                    return response;
                })
                .then(response => {
                    if (response.status == 200) {
                        this.$router.push("EditionsPage");
                        //deu certo
                    } else {
                        //erro
                    }
                })
        },
        createModal(): void {
            const element = this.$refs.uniqueid;
            //console.log(element);
            console.log(DDS);
            console.log(element);
            const modal = new DDS.Modal(element, { trigger: "#example" });
            console.log(modal);
        },
    }

})
</script>

<style></style>