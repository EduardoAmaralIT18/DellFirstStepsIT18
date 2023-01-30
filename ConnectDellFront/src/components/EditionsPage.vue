//Só um

<script>
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { defineComponent } from 'vue';
import axios from 'axios';
import moment from 'moment';


export default defineComponent({
  components: {
    NavBar,
    SideBar,
  },
  data() {
    return {
      cookiesId: this.$cookies.get("programId"),
      cookiesEdit: this.$cookies.get("editionId"),
      cookiesUser: this.$cookies.get("id"),
      edition: [],
      showMore: true,
    }
  },
  created() {
    axios.get(`/Edition/showInfoEdition?idProgram=${this.cookiesId}&idEdition=${this.cookiesEdit}`)
      .then(function (response) {
        return response;
      })
      .then(response => {
        if (response.status == 200) {
          this.edition = response.data;
        } else if (response.status == 204) {
          alert("There was an error on our database! Please, try again later.");
        }
      })
  },
  methods: {

    hasEndDate() {
      return this.edition.endDate == null ? '' : (' - ' + this.formatDate(this.edition.endDate));
    },
    formatDate(value) {
      if (value) {
        return moment(String(value)).format('MM/DD/YYYY')
      }
    },
    settingCookies(id) {
      this.$cookies.set("editionId", id);
    },
    modeToString() {
      switch (this.edition.mode) {
        case 0:
          return "REMOTE"
        case 1:
          return "HYBRID"
        case 2:
          return "IN-OFFICE"
      }
    },
    goBack() {
      this.$router.push({ name: 'ProgramsPage' });
      return;
    }

  },
  computed: {
    isOwner() {
      if (this.$cookies.get("isOwner") == 1)
        return true;
      else
        return false;
    },

  }
})
</script>

<template>

  <NavBar></NavBar>
  <SideBar></SideBar>
  <div class="container" v-if="edition.length != 0">
    <RouterLink to="/programinfo" class="goBack"> &larr; Go back</RouterLink>

    <p class="title">{{ edition.programName }} - {{ edition.name }} &nbsp; [ {{ modeToString() }} ]</p>
    <p class="date">{{ formatDate(this.edition.startDate) }}{{ hasEndDate() }}</p>
    <p class="description">{{ edition.description }}</p>

    <div class="bottomInfo">
      <RouterLink v-if="isOwner" class="button dds__button dds__button--primary"
        style="color:white ; text-decoration : none" type="button" to="/UpdateEdition">
        <img src="../assets/pencil.png" alt="pencil icon" width="19">
        Manage Edition
      </RouterLink>
    </div>

  </div>
  <div v-else class="container">
    <div class="dds__loading-indicator">
      <div class="dds__loading-indicator__label">Loading...</div>
      <div class="dds__loading-indicator__spinner"></div>
    </div>
  </div>
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

.description a {
  color: #0672CB;
  font-size: 15px;
}

.date {
  text-align: left;
  font-size: 13px;
  color: #7E7E7E;
}

.owner {
  text-align: left;
  font-size: 14px;
  color: #7E7E7E;
  margin-top: 1%;
  display: flex;
  float: left;
  font-weight: 590;
}

.button {
  width: 120px;
  font-size: 13px;
  height: 8%;
  margin-left: auto;
  margin-right: 15px;
  padding: 4px;
  display: flex;
  float: right;
  margin-top: 9px;
}

.button img {
  margin-right: 5px;
  margin-top: 1px;
  width: 20px;
}

.bottomInfo {
  display: inline;
}

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

.goBack {
  position: relative;
  right: 46%;
  text-decoration: none;
  color: #0672CB;
  font-weight: 300;
}
</style>