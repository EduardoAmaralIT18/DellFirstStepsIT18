<template>
    <Calendar :events="mockData"></Calendar>>
</template>

<script setup lang="ts">
import Calendar from '../components/Calendar.vue'

type TypeEvent = {
    id : number,
    name : string,
    eventType : number,
    phaseType : number,
    startDate : Date,
    endDate : Date,
    where : string,
    peopleInvolved : string[]
}
const mockData: TypeEvent[] = [{
    id : 1,
    name : 'John Johns',
    eventType : 1,
    phaseType : 1,
    startDate : new Date(),
    endDate : new Date(),
    where : 'here',
    peopleInvolved : ['me', 'he']
}, 
    {id : 2,
    name : 'Joana',
    eventType : 1,
    phaseType : 1,
    startDate : new Date(),
    endDate : new Date("2023-7-27"),
    where : 'here',
    peopleInvolved : ['me', 'he']}]
</script>

<style scoped>
p{
    margin-top: 100px;
    margin-left: 400px;
}
</style>