<template>
    <div class="container">
        <h4 class="title">
            Welcome, {{ user.name }}!
        </h4>

        <div v-if="user.role === 'Admin'">
            <h4 class="title">
                Programs
            </h4>
        </div>
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

            <div class="col-2 dds__mr-4 dds__mb-4">
                <div class="dds__card">
                    <div class="dds__card__content">
                        <button class="dds__button dds__button__icon" type="button">
                            <i class="dds__icon dds__icon--plus-add dds__card__header__icon" title="Add a Program"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>

        <div>
            <h4 class="title">
                Your Programs
            </h4>
            <div class="row">
                <div class="col-2 dds__mr-3 dds__mb-3" v-for="(item, i) in yourPrograms" :key="i">
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
            programs: [
                {
                    "name": "IT Academy",
                    "description": "Description IT"
                },
                {
                    "name": "Design Academy",
                    "description": "Description Design"
                },
                {
                    "name": "Infrastructure Residency",
                    "description": "Description Infra"
                },
                {
                    "name": "IT Academy",
                    "description": "Description IT"
                },
                {
                    "name": "Infrastructure Residency",
                    "description": "Description Infra"
                },
                {
                    "name": "IT Academy",
                    "description": "Description IT"
                },
                {
                    "name": "Design Academy",
                    "description": "Description Design"
                },
                {
                    "name": "Infrastructure Residency",
                    "description": "Description Infra"
                }
            ],
            yourPrograms: [
                {
                    "name": "IT Academy 2",
                    "description": "Description IT"
                },
                {
                    "name": "Design Academy 2",
                    "description": "Description Design"
                },
                {
                    "name": "Infrastructure Residency 2",
                    "description": "Description Infra"
                }
            ]
        }
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.container {
    padding-top: 5%;
    padding-left: 20%;
    display: flex;
    flex-direction: column;
}
.dds__card {
    width: 12rem;
    color: #0477CE;
    box-shadow: 5px 5px lightgrey;
    border-radius: 10px;
}
.dds__card__header__title {
    font-weight: 550;
    color: #0477CE;
}
.dds__card__body {
    color: #0477CE;
}
.title {
    margin-left: 0px !important;
    text-align: left;
    color: #0477CE;
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
    color: #0477CE;
    font-size: 55px;
    font-weight: bold;
}
</style>  