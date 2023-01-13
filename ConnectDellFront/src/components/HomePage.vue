<template>
    <NavBar></NavBar>
    <SideBar view="home"></SideBar>
    <div class="container">
        <h4 class="title">
            Welcome, {{ user.name }}!
        </h4>

        <div v-if="HasMyPrograms">
            <h4 class="subtitle">
                My Programs
            </h4>
            <div class="row">
                <div class="col-2 dds__mr-4 dds__mb-3" v-for="(item, i) in myPrograms" :key="i">
                    <div class="flip-card" tabindex="0">
                        <div class="flip-card-inner">
                            <div class="flip-card-front">
                                <div class="dds__card__content">
                                    <div class="dds__card__header">
                                        <div class="dds__card__header__text">
                                            <h5 class="dds__card__header__title">{{ item.name }}</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="flip-card-back">
                                <div class="dds__card__body">{{ item.description }}</div>
                                <div class="dds__card__footer">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div v-if="HasPrograms">
            <h4 class="subtitle">
                Programs
            </h4>
            <div class="row">
                <div class="col-2 dds__mr-4 dds__mb-3" v-for="(item, i) in programs" :key="i">
                    <div class="flip-card">
                        <div class="flip-card-inner">
                            <div class="flip-card-front">
                                <div class="dds__card__content">
                                    <div class="dds__card__header">
                                        <div class="dds__card__header__text">
                                            <h5 class="dds__card__header__title">{{ item.name }}</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="flip-card-back">
                                <div class="dds__card__body">{{ item.description }}</div>
                                <div class="dds__card__footer">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-2 dds__mr-4 dds__mb-4" v-if="IsAdmin">
                    <div class="flip-card">
                        <div class="flip-card-back">
                            <div class="dds__card__content">
                                <div class="dds__card__body">
                                    <button class="dds__button dds__button__icon" type="button">
                                        <i class="dds__icon dds__icon--plus-add dds__card__header__icon dds__icon__plus"
                                            title="Add a Program"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div v-if="!HasMyPrograms && !HasPrograms">
            <p class="message">
                <i class="dds__icon dds__icon--search dds__icon__search"></i>
                No programs found
            </p>
        </div>
    </div>
</template>

<script>
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import axios from 'axios';
import ApiHandler from '../libs/ApiHandler'

export default {
    name: 'HomePage',
    components: {
        SideBar,
        NavBar,
    },
    props: {
    },
    data() {
        return {
            user: {
                "id": "1",
                "name": "Person",
                "role": 0
            },
            myPrograms: [],
            programs: []
        }
    },
    computed: {
        HasMyPrograms() {
            return this.myPrograms && this.myPrograms.length > 0;
        },
        HasPrograms() {
            return (this.programs && this.programs.length > 0) || this.IsAdmin
        },
        IsAdmin() {
            return this.user.role === 0;
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

            //this.user.id = this.$cookies.get("id");
            //this.user.name = this.$cookies.get("name");
            //this.user.role = this.$cookies.get("role");

            axios.get(ApiHandler.URL(`/Program/GetPrograms?idUser=${this.user.id}&role=${this.user.role}`))
                .then(function (response) {
                    return response;
                })
                .then(response => {
                    if (response.status == 404) {
                        this.myPrograms = [];
                        this.programs = [];
                    } else if (response.status == 200) {
                        this.myPrograms = response.data?.myPrograms;
                        this.programs = response.data?.programs;
                    } else {
                        console.log(response.status);
                    }
                });
        }
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.container {
    padding-top: 5%;
    padding-left: 15%;
    display: inline-flex;
    flex-direction: column;
}

.dds__card__header__title {
    font-weight: 550;
    font-size: 1.25rem;
    color: #0672CB;
    text-align: center;
}

.dds__card__body {
    font-size: 1.0rem;
    padding: 10%;
    color: #0672CB;
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

.dds__button {
    background-color: white;
    border-style: none;
}

.dds__button:hover {
    background-color: unset !important;
}

.dds__icon__plus {
    color: #0672CB;
    font-size: 55px;
    font-weight: bold;
}

.dds__icon__search {
    color: #0672CB;
    font-size: 1.5rem;
    font-weight: bold;
    padding-right: 1%;

}

.flip-card {
    padding-right: 10%;
    width: 12rem;
    height: 10rem;
    color: #0672CB;
    border-radius: 10px;
    text-align: center;
    transition: transform 0.6s;
    transform-style: preserve-3d;
    backface-visibility: hidden;
    -moz-backface-visibility: hidden;
}

.flip-card-inner {
    width: 100%;
    height: 100%;
    border-radius: 10px;
    position: relative;
    text-align: center;
    transition: transform 0.6s;
    transform-style: preserve-3d;
    backface-visibility: hidden;
    -moz-backface-visibility: hidden;
}

.flip-card:focus {
    outline: 0;
}

.flip-card:hover .flip-card-inner,
.flip-card:focus .flip-card-inner {
    border-radius: 10px;
    transform: rotateY(180deg);
}

.flip-card-front,
.flip-card-back {
    width: 100%;
    border-radius: 10px;
    height: 100%;
    position: absolute;
}

.flip-card-front {
    z-index: 2;
    display: flex;
    background-color: white;
    justify-content: center;
    align-items: center;
}

.flip-card-back {
    z-index: 1;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: white;
    box-shadow: 5px 5px lightgrey;
    transform: rotateY(180deg);
}
</style>  