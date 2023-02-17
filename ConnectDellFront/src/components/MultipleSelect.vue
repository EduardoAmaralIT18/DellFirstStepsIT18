<template>
    <!-- mode="tags" é a opção antiga -->
    <Multiselect mode="multiple" :close-on-select="false" :searchable="true" :create-option="false" :options="transformOptions()"/>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Multiselect from '@vueform/multiselect';
import axios from 'axios';

type User = {
    id: number,
    name: string
}[];


interface Data {
    options: null | User,
    //esconder: boolean
}

export default defineComponent ({
    components: {
        Multiselect
    },
    props: {
        tipo: { 
            type: String,
        }
    },
    data() : Data {
        return {
            options: null
        };
    },
    created() {
        if (this.tipo == "owner" ) {
            axios.get("/user/GetOwners")
            .then(function (response) {
                return response;
            })
            .then(response => {
                this.options = response.data;
                return;
            });
        } else if (this.tipo == "members") {
            axios.get("/edition/getUsersNotAdmin")
            .then(function (response) {
                return response;
            })
            .then(response => {
                this.options = response.data;
                return;
            });
        } else {
            axios.get("/user/GetOwners")
            .then(function (response) {
                return response;
            })
            .then(response => {
                this.options = response.data;
                return;
            });

            axios.get("/edition/getUsersNotAdmin")
            .then(function (response) {
                return response;
            })
            .then(response => {
                this.options?.push(response.data);
                return;
            });
        }
        
        
    },
    methods: {
        transformOptions() {
                var list = this.options?.map(option => ({
                value: option,
                label: option.name
            }))
            return list;
        }
    }
});
</script>

<style src="@vueform/multiselect/themes/default.css">
.multiselect {
    border: .0625rem solid #7e7e7e;
    border-radius: .125rem;
    background-clip: padding-box;
    margin-bottom: 5px;
    font-family: 'Roboto', sans-serif;
}


.multiselect-tag {
    background-color: rgb(6, 114, 203);
    font-weight: lighter;
}
</style>
