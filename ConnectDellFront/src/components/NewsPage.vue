<template>
    <div class="container">
        <div class="top">
            <h2>News</h2>
            <div v-if="role == 0">
                <button class="dds__button dds__button--primary dds__button--lg" type="button">
                    <i class="dds__icon dds__icon--plus-add" aria-hidden="true"></i>Add News
                </button>
            </div>
        </div>
        <div v-if="news != null" class="dds__col-12 dds__col--md-6 dds__col--lg-4 dds__mb-3">
            <div v-for="item in newsShown" :key="item.id" class="dds__card" id="card-news">
                <div class="dds__card__media">
                    <!-- <div v-if="item.image != null" class="dds__card__media"></div> -->
                    <img src="https://super.abril.com.br/wp-content/uploads/2017/12/a-verdadeira-histc3b3ria-de-natal.png?w=1024" />
                </div>
                <div class="dds__card__content">
                    <div class="dds__card__header">
                        <span class="dds__card__header__text">
                            <h5 class="dds__card__header__title"><b>{{ item.title }}</b></h5>
                            <p><i>Posted by {{ item.author }} from {{ item.program }}</i></p>
                        </span>
                    </div>
                    <div class="dds__card__body">
                        {{ item.text }}
                    </div>
                    <div class="dds__card__footer">
                        <p>{{ item.date }}</p>
                    </div>
                </div>
            </div>
        </div>
        <div v-if="countNews != totalNews">
            <button class="dds__button dds__button--primary dds__button--lg" type="button" @click="moreNews">
                See More
            </button>
        </div>
    </div>
</template>
<script lang="ts" >
import { defineComponent } from 'vue';
import axios from 'axios';

type News = {
}[];

interface Data {
    news: null | News,
    role: number,
    newsShown: null | News,
    totalNews: number | undefined,
    countNews: number
}

export default defineComponent({
    data(): Data {
        return {
            news: null,
            role: 5,
            newsShown: [],
            totalNews: 0,
            countNews: 0
        };
    },
    created() {
        // fetch the data when the view is created and the data is
        // already being observed
        this.fetchData();
    },
    watch: {
        // call again the method if the route changes
        '$route': 'fetchData',
    },
    methods: {
        fetchData(): void {
            this.news = null;

            this.role = this.$cookies.get("role");

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
                        this.totalNews = this.news?.length;
                        this.moreNews();
                        return;
                    } else {
                        console.log(response.status);
                        return;
                    }

                });
        },
        moreNews(): void {
            do {
                this.news?.every(element => {
                    this.newsShown?.push(element);
                    this.news?.shift();
                    console.log(element);
                    this.countNews = this.countNews + 1;
                });
            } while ((this.countNews % 10 != 0) && (this.countNews != this.totalNews));
            console.log(this.totalNews);
            console.log(this.news?.length);
            console.log(this.countNews);
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
    padding-bottom: 50vh;
    padding-left: 20%;
    display: flex;
    flex-direction: column;
}

i {
    margin-right: 5px;
}

.dds__card__footer p {
    color: #7E7E7E;
}

p {
    padding-top: 2%;
    color: #0E0E0E;
}

h2 {
    color: #0672CB;

}

.top {
    padding-bottom: 3%;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}

#card-news {
    margin-bottom: 2.5%;
}

button {
    white-space: nowrap;
}
</style>
