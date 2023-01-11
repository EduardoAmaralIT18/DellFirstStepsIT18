<template>
    <div class="container">
        <h4 class="title">
            Welcome, {{ user.name }}!
        </h4>

        <div v-if="myPrograms && myPrograms.length > 0">
            <h4 class="subtitle">
                My Programs
            </h4>
            <div class="row">
                <div class="col-2 dds__mr-4 dds__mb-3" v-for="(item, i) in myPrograms" :key="i">
                    <div class="dds__card">
                        <div class="dds__card__content">
                            <div class="dds__card__header">
                                <span class="dds__card__header__text">
                                    <h5 class="dds__card__header__title">{{ item.name }}</h5>
                                </span>
                            </div>
                            <div class="dds__card__body">{{ item.description }}</div>
                            <div class="dds__card__footer">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div v-if="(programs && programs.length > 0) || IsAdmin">
            <h4 class="subtitle">
                Programs
            </h4>
            <div class="row">
                <div class="col-2 dds__mr-4 dds__mb-4" v-for="(item, i) in programs" :key="i">
                    <div class="dds__card">
                        <div class="dds__card__content">
                            <div class="dds__card__header">
                                <span class="dds__card__header__text">
                                    <h5 class="dds__card__header__title">{{ item.name }}</h5>
                                </span>
                            </div>
                            <div class="dds__card__body">{{ item.description }}</div>
                            <div class="dds__card__footer">
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-2 dds__mr-4 dds__mb-4" v-if="IsAdmin">
                    <div class="dds__card">
                        <div class="dds__card__content">
                            <button class="dds__button dds__button__icon" type="button">
                                <i class="dds__icon dds__icon--plus-add dds__card__header__icon"
                                    title="Add a Program"></i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'HelloWorld',
    props: {
    },
    data() {
        return {
            user: {
                "name": "Jordana",
                "role": "Admin"
            },
            myPrograms: [
                {
                    "name": "IT Academy 17",
                    "description": "Description IT"
                },

                {
                    "name": "Infrastructure Residency 2",
                    "description": "Description Infra"
                },

            ],
            programs: [

                {
                    "name": "Design Academy",
                    "description": "Description Design"
                }

            ]
        }
    },
    computed: {
        IsAdmin() {
            return this.user.role === 'Admin';
        }
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.container {
    padding-top: 5%;
    padding-left: 15%;
    display: flex;
    flex-direction: column;
}

.dds__card {
    width: 12rem;
    color: #0672CB;
    box-shadow: 5px 5px lightgrey;
    border-radius: 10px;
}

.dds__card__header__title {
    font-weight: 550;
    color: #0672CB;
}

.dds__card__body {
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

.dds__button {
    background-color: white;
    border-style: none;
}

.dds__button:hover {
    background-color: unset !important;
}

.dds__icon {
    color: #0672CB;
    font-size: 55px;
    font-weight: bold;
}
</style>  