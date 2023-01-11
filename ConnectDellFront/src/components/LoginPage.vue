<script setup lang="ts">
import { defineComponent } from 'vue';
import axios from 'axios';

type User = {

}[];

interface Data {

    User: null | User,

}

export default defineComponent({

    data(): Data {

        return {

            User: null,

        };

    },

    created() {
        // fetch the data when the view is created and the data is
        // already being observed
        this.fetchData();
    },
    watch: {
        // call again the method if the route changes
        '$route': 'fetchData'
    },
    methods: {
        fetchData(): void {
            axios.get('/Login/getUserList')
                 .then(function(response){
                    return response;   
                 }).then(response=>{
                    this.User = response.data;
                    return;
                 })
        },
       setCookies(): void{
        this.$cookies.set("id",item.id);
        this.$cookies.set("name",item.name);
        this.$cookies.set("role",item.role);
       } 
},


});
</script>
<template>
    
</template>