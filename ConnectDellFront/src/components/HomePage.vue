<template>
    <NavBar></NavBar>
    <SideBar view="home"></SideBar>
    <div class="container">
        <h4 class="title">
            Welcome, {{ user.name }}!
        </h4>

        <div v-if="HasMyPrograms()">
            <h4 class="subtitle">
                My Programs
            </h4>
            <div class="row">
                <div class="initialCard col-3 dds__ml-3 dds__mr-4 dds__mb-3" v-if="IsAdmin()">
                    <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3">
                        <div class="dds__card">
                            <div class="dds__card__content">
                                <div class="addProgramIcon dds__card__body">
                                    <RouterLink style="text-decoration: none" to="/createprogram">
                                        +
                                    </RouterLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="initialCard col-3 dds__ml-3 dds__mr-4 dds__mb-3" v-for="(item, i) in myPrograms" :key="i">
                    <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3">
                        <div class="dds__card">
                            <div class="dds__card__content">
                                <div class="dds__card__header">
                                    <span class="dds__card__header__text">
                                        <h5 class="dds__card__header__title">{{ item.name }}</h5>
                                    </span>
                                </div>
                                <div class="dds__card__body">{{ item.description }}
                                </div>
                                <div class="dds__card__footer">
                                    <RouterLink style="text-decoration: none" class="link" to="/programinfo"
                                        @click="settingCookies(item.id)">
                                        Learn more ➔
                                    </RouterLink>
                                    <!-- adicionar metodo que seta os cookies com o id referente a div clicada -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>

        <div v-if="HasPrograms()">
            <h4 class="subtitle">
                Programs
            </h4>
            <div class="row">
                <div class="initialCard col-3 dds__ml-3 dds__mr-4 dds__mb-3" v-for="(item, i) in programs" :key="i">
                    <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3">
                        <div class="dds__card">
                            <div class="dds__card__content">
                                <div class="dds__card__header">
                                    <span class="dds__card__header__text">
                                        <h5 class="dds__card__header__title">{{ item.name }}</h5>
                                    </span>
                                </div>
                                <div class="dds__card__body">{{ item.description }}
                                </div>
                                <div class="dds__card__footer">
                                    <RouterLink style="text-decoration: none" class="link" to="/programinfo"
                                        @click="settingCookiesNoPermission(item.id)">
                                        Learn more ➔
                                    </RouterLink>
                                    <!-- adicionar metodo que seta os cookies com o id referente a div clicada -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div v-if="!HasMyPrograms() && !HasPrograms()">
                    <p class="message">
                        <i class="dds__icon dds__icon--search dds__icon__search"></i>
                        No programs found
                    </p>
                </div>
            </div>
        </div>
    </div>
    <RouterView />
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import axios from 'axios';
import { RouterLink, RouterView } from 'vue-router';

interface Program {
    id: Number;
    name: string;
    description: string;
    startDate: any;
    endDate: any;
}

interface Data {
    user: {
        id: Number;
        name: string;
        role: Number;
    },
    myPrograms: Program[],
    programs: Program[]
}

export default defineComponent({
    components: {
        SideBar,
        NavBar,
        RouterLink,
        RouterView
    },
    props: {
    },
    data(): Data {
        return {
            user: {
                id: 0,
                name: '',
                role: -1
            },
            myPrograms: [],
            programs: []
        }
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
        fetchData: function () {
            this.myPrograms = [];
            this.programs = [];

            this.user.id = this.$cookies.get("id") ? Number(this.$cookies.get("id")) : 0;
            this.user.name = this.$cookies.get("name");
            this.user.role = this.$cookies.get("role") ? Number(this.$cookies.get("role")) : -1;

            axios.get(`/Program/getPrograms?idUser=${this.user.id}&role=${this.user.role}`)
                .then(function (response) {
                    return response;
                })
                .then(response => {
                    if (response.status == 204) {
                        this.myPrograms = [];
                        this.programs = [];
                    } else if (response.status == 200) {
                        this.myPrograms = response.data?.myPrograms;
                        this.programs = response.data?.programs;
                    } else {
                        console.log(response.status);
                    }
                });
        },
        settingCookies(id: Number) {

            this.$cookies.set("programId", id);
            this.$cookies.set("Permission", -1);
        },
        settingCookiesNoPermission(id: Number) {

            this.$cookies.set("programId", -1);
            this.$cookies.set("Permission", id);

        },
        HasMyPrograms() {
            return this.myPrograms && this.myPrograms.length > 0;
        },
        HasPrograms() {
            return (this.programs && this.programs.length > 0) || this.IsAdmin()
        },
        IsAdmin() {
            return this.user.role === 0;
        }
    }
});
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
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

.dds__card {
    box-shadow: rgba(0, 0, 0, 0.176) 0px 3px 8px;
    border-radius: 10px;
    display: block;
    width: 250px;
    height: 225px;
}

.dds__card__content {
    padding: 20px;
}

.dds__card__header__title {
    font-size: 19px;
    color: #0672CB;
    text-align: left;
}

.dds__card__body {
    font-size: 15px;
    color: #0e0e0e;
    display: -webkit-box;
    -webkit-line-clamp: 4;
    -webkit-box-orient: vertical;
    overflow: hidden;
    text-overflow: ellipsis;
    padding-top: 20px;
    text-align: left;
}

.title {
    margin-left: 0px !important;
    text-align: left;
    color: #0672CB;
    margin: 2.5%;
    font-weight: bold;
}

.subtitle {
    margin-left: 0px !important;
    text-align: left;
    color: #0672CB;
    margin: 2.5%;
}

.message {
    text-align: center;
    color: #0672CB;
    margin-top: 5%;
    font-size: 1.5rem;
}

.dds__icon__search {
    color: #0672CB;
    font-size: 1.5rem;
    font-weight: bold;
    padding-right: 1%;

}

.link {
    color: #0672CB;
    font-size: 15px;
    position: absolute;
    bottom: 0;
    text-align: center;
    left: 0;
    margin-left: 20px;
    margin-top: 10px;
    padding-bottom: 17px;
}

.addProgramIcon {
    color: #0672CB;
    text-align: center;
    font-size: 89px;
    padding-top: 40%;
    padding-bottom: 35px;
    text-decoration: none;
}

.initialCard {
    display: block;
}
</style>  