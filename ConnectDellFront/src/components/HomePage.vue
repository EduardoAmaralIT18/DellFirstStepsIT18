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
                <div class="col-3 dds__mr-3 dds__mb-3" v-for="item in myPrograms" :key="item.id">
                    <div class="dds__col-12 dds__col--md-6 dds__col--lg-4 dds__mb-3">
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
                                    <RouterLink to="/programinfo" @click="settingCookies(item.id)">
                                        Learn moreㅤ➔
                                    </RouterLink>
                                        <!-- adicionar metodo que seta os cookies com o id referente a div clicada -->
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
                <div class="col-3 dds__mr-3 dds__mb-3" v-for="(item, i) in programs" :key="i">
                    <div class="dds__col-12 dds__col--md-6 dds__col--lg-4 dds__mb-3">
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
                                    <RouterLink to="/programinfo" @click="settingCookies(item.id)">
                                        Learn moreㅤ➔
                                    </RouterLink>
                                    <!-- adicionar metodo que seta os cookies com o id referente a div clicada -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-3 dds__mr-3 dds__mb-3" v-if="IsAdmin">
                    <div class="dds__col-12 dds__col--md-6 dds__col--lg-4 dds__mb-3">
                        <div class="dds__card">
                            <div class="dds__card__content">
                                <div class="addProgramIcon dds__card__body" data-hover="Add program">
                                    <RouterLink style="text-decoration: none;" to="/createprogram">
                                        +
                                    </RouterLink>
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
        </div>
    </div>
    <RouterView />
</template>

<script>
    import NavBar from '../components/NavBar.vue';
    import SideBar from '../components/SideBar.vue';
    import axios from 'axios';
    import ApiHandler from '../libs/ApiHandler';
    import { RouterLink, RouterView } from 'vue-router';

    export default ({
        name: 'HomePage',
        components: {
            SideBar,
            NavBar,
            RouterLink,
            RouterView
        },
        props: {
        },
        data() {
            return {
                user: {
                    id: '',
                    name: '',
                    role: '-1'
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
                return this.user.role === "0";
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

                this.user.id = this.$cookies.get("id");
                this.user.name = this.$cookies.get("name");
                this.user.role = this.$cookies.get("role");

                console.log(this.user.role);
                console.log(this.IsAdmin);

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
            },
            settingCookies(index) {
                this.$cookies.set("programId", index);
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
        height: 250px;
    }

    .dds__card__header__title {
        font-size: 22px;
        color: #0672CB;
        text-align: center;
    }

    .dds__card__body {
        font-size: 17px;
        color: #0e0e0e;
        text-align: left;
        display: -webkit-box;
        -webkit-line-clamp: 3;
        -webkit-box-orient: vertical;
        overflow: hidden;
        text-overflow: ellipsis;
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
        margin: 0 auto;
        padding-top: 15%;
        font-size: 16px;
    }

    .addProgramIcon {
        color: #0672CB;
        text-align: center;
        font-size: 63px;
        padding-top: 35px;
        padding-bottom: 35px;
        text-decoration: none;
        margin: 0 auto;

    }

    .dds__card__footer a{
        position: absolute;
        bottom: 0;
        text-align: center;
        margin-left: 30%;
        padding-bottom: 15px;
        
    }
</style>  
