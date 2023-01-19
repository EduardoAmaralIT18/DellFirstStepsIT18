<script>
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { RouterView } from 'vue-router';
import { defineComponent } from 'vue';
import axios from 'axios';
import ApiHandler from '../libs/ApiHandler';
import moment from 'moment';

export default defineComponent({
  components: {
    NavBar,
    SideBar,
    RouterView
  },
  data() {
    return {
      cookiesId: this.$cookies.get("programId"),
      program: [],
      owners: []
    }
  },
  created() {
    axios.get(ApiHandler.URL(`/Program/showInfoProgram?id1=${this.cookiesId}`))
      .then(function (response) {
        return response;
      })
      .then(response => {
        if (response.status == 200) {
          this.program = response.data;
          this.owners = response.data.owners;
        } else if (response.status == 204) {
          alert("There was an error on our database! Please, try again later.");
        }
      })
  },
  methods: {
    hasEndDate() {
      return this.program.endDate == null ? '' : (' - ' + this.formatDate(this.program.endDate));

    },
    formatDate: function (value) {
      if (value) {
        return moment(String(value)).format('MM/DD/YYYY')
      }
    }
  }

})
</script>

<template>
  <main>
    <NavBar></NavBar>
    <SideBar></SideBar>
    <div class="container">
      <p class="title">{{ program.name }}</p>
      <p class="date">{{ formatDate(this.program.startDate) }}{{ hasEndDate() }}</p>
      <p class="description">{{ program.description }}</p>
      <div class="bottomInfo">
        <p class="owner" v-for="owner in owners" :key="owner.id">{{ owner.name }}</p>
        <!-- <p>{{  program  }}</p> -->

        <p class="button dds__button dds__button--primary" type="button">
          <img src="../assets/pencil.png" alt="pencil icon" width="19">
          Edit Program</p>
      </div>
      <RouterView />
    </div>
  </main>
</template>

<style scoped>
body {
  font-family: 'Roboto', sans-serif;
}

.container {
  padding-top: 3%;
  padding-left: 17%;
  display: flex;
  flex-direction: column;
}

.title {
  color: #0672CB;
  font-size: 190%;
  text-align: left;
  margin-top: 55px;
}

.description {
  text-align: justify;
  padding-right: 30px;
  left: 0;
  position: relative;
}

.date {
  text-align: left;
  font-size: 13px;
  color: #7E7E7E;
}

.owner{
  text-align: left;
  font-size: 14px;
  color: #7E7E7E;
  margin-top: 1%;
  display: flex;
  float: left;
}
.button{
  width: 21%;
  font-size: 13px;
  height: 8%;
  margin-left: auto;
  margin-right: 15px;
  padding: 4px;
  display: flex;
  float: right
}
.bottomInfo{
  display: inline;
}
</style>