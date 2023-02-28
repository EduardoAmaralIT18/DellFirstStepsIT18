<template>
    <div v-if="user != null" class="container">
        <div class="top">
            <h2>News</h2>
            <div v-if="role == 0">
                <RouterLink to="/addnews"> <button class="dds__button dds__button--primary dds__button--lg"
                        type="button">
                        <i class="dds__icon dds__icon--plus-add" aria-hidden="true"></i>Add News
                    </button>
                </RouterLink>
            </div>
        </div>
        <div v-if="news != null" class="dds__col-12 dds__col--md-6 dds__col--lg-4 dds__mb-3">
            <div v-for="item in newsShown" :key="item.id" class="dds__card" id="card-news">
                <!-- <div class="dds__card__media"></div> -->
                <div v-if="item.image != null" class="dds__card__media">
                    <img :src=item.image />
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
                        <div class="manageButton" v-if="isAuthor(item.authorId)">
                            <RouterLink :to="{ name: 'EditNews', params: { idNews: item.id } }"
                                class="insideButton dds__button dds__button--primary"
                                style="color:white ; text-decoration : none" type="button">
                                <div class="margin">
                                    <img src="../assets/pencil.png" alt="pencil icon" width="19">
                                </div>
                                Manage News
                            </RouterLink>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div v-else>
            <div class="dds__loading-indicator">
                <div class="dds__loading-indicator__label">Loading...</div>
                <div class="dds__loading-indicator__spinner"></div>
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
import { RouterLink } from 'vue-router';

type News = {
    id: number,
    title: string,
    text: string,
    author: string,
    authorId: number,
    program: string,
    date: string,
    image: null | string,
}[];

interface Data {
    user: number | null,
    news: null | News,
    role: number,
    newsShown: null | News,
    totalNews: number | undefined,
    countNews: number
}

export default defineComponent({
    name: 'NewsPage',
    components: {
        RouterLink,
    },
    data(): Data {
        return {
            user: null,
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
            this.user = this.$cookies.get("id");

            axios.get('/news/getNews')
                .then(function (response) {
                    return response;
                })
                .then(response => {
                    if (response.status == 204) {
                        this.news = null;
                        alert("No news found!");
                    } else if (response.status == 200) {
                        this.news = response.data;
                        this.totalNews = this.news?.length;
                        this.moreNews();
                    } else {
                        alert("Databade error. Please try again later.");
                        console.log(response.status);
                    }

                });
        },
        moreNews(): void {
            do {
                this.news?.every(element => {
                    this.newsShown?.push(element);
                    this.news?.shift();
                    this.countNews = this.countNews + 1;
                });
            } while ((this.countNews % 10 != 0) && (this.countNews != this.totalNews));
        },
        isAuthor(authorId: number): boolean {
            let idUser = this.$cookies.get("id") ? Number(this.$cookies.get("id")) : 0;
            return authorId === idUser;
        }
    }
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
    margin-right: 8px;
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

a {
    text-decoration: none;
}

#card-news {
    margin-bottom: 2.5%;
}

button {
    white-space: nowrap;
}

.manageButton {
    display: inline;
    width: 180px;
    font-size: 10px;
    height: 8%;
    margin-left: auto;
    margin-right: 15px;
    padding: 4px;
    display: flex;
    float: right;
    margin-top: 9px;
}

.insideButton {
    display: flex;
    font-size: 13px;
    float: right;
    height: 8%;
    margin-left: auto;
    margin-right: 15px;
    padding: 4px;
    padding-right: 8px;
    width: 140px;
}

.margin {
    margin-right: 5px;
}
</style>
