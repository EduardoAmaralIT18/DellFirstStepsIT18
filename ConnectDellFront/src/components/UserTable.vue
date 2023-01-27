<template>

    <div class="container">

        <h4 class="title">
            {edition.name} - Members
        </h4>

        <div>
            <button @click="clickIntern()">
                Interns
            </button>
            <button @click="clickMembers()">
                Members
            </button>
            <button @click="clickStaff()">
                PucrsStaff
            </button>

            <table v-if="selectedOption == 1">

                <tr>
                    <th>Name</th>
                    <th>E-mail</th>
                    <th>Role</th>
                </tr>
                
                <p>1</p>
            </table>

            <table v-else-if="selectedOption == 2">
                
                <tr>
                    <th>Name</th>
                    <th>E-mail</th>
                    <th>Role</th>
                </tr>
                <p>2</p>

            </table>

            <table v-else>
                
                <tr>
                    <th>Name</th>
                    <th>E-mail</th>
                    <th>Role</th>
                </tr>
                <p>3</p>
            </table>
        </div>

    </div>

</template>


<script lang="ts">//mudar pra JS? 
import { defineComponent } from 'vue';
import axios from 'axios';


interface Data {
    interns: Person | null,
    members: Person | null,
    pucstaff: Person | null,
    selectedOption: number | string | null,
}

type Person = {
    name: string,
    email: string,
    role: number
}[];

export default defineComponent({
    data(): Data {
        return {
            interns: [],
            members: [],
            pucstaff: [],
            selectedOption: 0,
        }
    },
    created() {
        axios.get(`/Program/showInfoProgram`)

            .then(function (response) {
                return response;
            })
            .then(response => {
                if (response.status == 200) {
                    // this.program = response.data;
                    // this.owners = response.data.owners;
                    // this.editions = response.data.editions;
                } else if (response.status == 204) {
                    alert("There was an error on our database! Please, try again later.");
                }
            })
    },
    methods: {
        clickIntern() {
            this.selectedOption = 1
        },
        clickMembers() {
            this.selectedOption = 2
        },
        clickStaff() {
            this.selectedOption = 3
        }
    }
});

</script>

<style scooped>
body {
    font-family: 'Roboto', sans-serif;
}

.container {
    padding-top: 5%;
    padding-left: 15%;
    display: inline-flex;
    flex-direction: column;
}

.title {
    margin-left: 0px !important;
    text-align: left;
    color: #0672CB;
    margin: 2.5%;
    font-weight: bold;
}
</style>