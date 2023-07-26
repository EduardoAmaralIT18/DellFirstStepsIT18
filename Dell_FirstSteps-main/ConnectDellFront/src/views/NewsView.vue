<script setup lang="ts">
import axios from "axios";
import News from "@/interfaces/News";
import {onMounted, ref} from "vue";

onMounted(async () => {
  await getNews();
});

const news = ref<News[]>([]);

const getNews = async () => {
  await axios
      .get(`https://localhost:5001/News/getNews`)
      .then((response) => {
        news.value = response.data;
      })
      .catch((e) => {
        console.error(e);
      });
};

function isAdmin() {
  return +localStorage.getItem("userRole")! === 0;
}

function isAuthor(authorId: number) {
  return authorId === +localStorage.getItem("userId")!;
}
</script>

<template>
  <div class="container">
    <div class="title">
      <h2>News</h2>
      <RouterLink to="addNews">
        <button
            class="manageProgram button dds__button dds__button&#45;&#45;primary"
            type="button"
            v-if="isAdmin()"
        >
          <i class="dds__icon dds__icon--plus-add" aria-hidden="true"></i>
          Add News
        </button>
      </RouterLink>
    </div>
    <div v-for="item in news" class="dds__card" id="card-news">
      <div v-if="item.image != null" class="dds__card__media">
        <img id="news-image" alt="news image" :src="item.image"/>
      </div>
      <div class="body-card">
        <h3>{{ item.title }}</h3>
        <p id="author">Posted by {{ item.author }} from {{ item.program }}</p>
        <p>{{ item.text }}</p>
      </div>
      <div class="footer-card">
        <span>{{ item.date }}</span>
        <RouterLink :to="`editNews/${item.id}`" v-if="isAuthor(item.authorId)">
          <button
              class="manageProgram button dds__button dds__button&#45;&#45;primary"
              type="button"
          >
            <img src="../assets/pencil.png" alt="pencil icon" width="19"/>
            Manage News
          </button>
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.container {
  margin-left: 20%;
  margin-right: 20%;
  margin-bottom: 10%;
  padding-top: 70px;
  display: flex;
  flex-direction: column;
  gap: 32px;
}

.title {
  display: flex;
  justify-content: space-between;
  margin-bottom: 30px;

  i {
    margin-right: 5px;
  }
}

h2 {
  color: #0672cb;
  font-weight: 500;
}

.dds__card {
  padding: 30px 20px 40px 20px;
}

.dds__card__media {
  img {
    height: 100%;
    object-fit: contain;
  }
}

.body-card {
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
  text-align: center;

  #author {
    font-style: italic;
    margin-bottom: 20px;
  }

  h3 {
    font-weight: bold;
    font-size: 20px;
    margin-top: 10px
  }
}


.footer-card {
  display: flex;
  justify-content: space-between;
  align-items: center;

  span {
    color: gray;
  }

  img {
    margin-right: 10px;
  }
}
</style>
