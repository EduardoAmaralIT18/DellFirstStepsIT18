<template>
    <div class="container">
        <div class="teste">
            <h2>News</h2>
            <button class="dds__button dds__button--primary dds__button--lg" type="button">
                <i class="dds__icon dds__icon--plus-add" aria-hidden="true"></i>Add News
            </button>
        </div>
        <div v-if="news != null" class="dds__col-12 dds__col--md-6 dds__col--lg-4 dds__mb-3" id="card-news">
            <div v-for="item in news" :key="item.id" class="dds__card">
                <div v-if="item.image" class="dds__card__media">
                    <img src="item.image">
                </div>
                <div class="dds__card__content">
                    <div class="dds__card__header">
                        <span class="dds__card__header__text">
                            <h5 class="dds__card__header__title">{{ item.title }}</h5>
                        </span>
                    </div>
                    <div class="dds__card__body">{{ item.text }}
                    </div>
                    <div class="dds__card__footer">
                        <p><b>{{ item.author }} - {{ item.program }}</b> in {{ item.date }}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
import axios from 'axios';

type News = {
}[];

interface Data {
    news: null | News,
}

export default defineComponent({
    data(): Data {
        return {
            news: null,
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
            this.news = null;

            axios.get('/news/getNews')
                .then(function (response) {
                    return response;
                })
                .then(response => {
                    if (response.status == 404) {
                        this.news = null;
                        return;
                    } else if (response.status == 200) {
                        this.news = response.data;
                        return;
                    } else {
                        console.log(response.status);
                        return;
                    }
                });
        }
    },
});
</script>
<style scoped>
.smallIcons {
    width: 48px;
    margin-bottom: 3%;
}

.container {
    padding-top: 5%;
    padding-left: 20%;
    display: flex;
    flex-direction: column;
}

i {
    margin-right: 5px;
}

p {
    padding-top: 2%;
    color: #0E0E0E;
}

h2 {
    color: #0672CB;

}

.teste {
    padding-bottom: 3%;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}

.dds__card__media {}

button {
    white-space: nowrap;
}
</style>
