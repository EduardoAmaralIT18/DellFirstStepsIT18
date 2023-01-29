<script>
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import { defineComponent } from 'vue';
import axios from 'axios';
import moment from 'moment';

// interface Data {
//   cookiesId: number,
//   cookiesPermission: number,
//   cookiesUser: number,
//   program: Program | null,
//   owners: Owner | null,
//   editions: [],
//   showMore: boolean,
// }

// type Program = {
//   name: string,
//   endDate: Date | string | null,
//   startDate: Date | string, 
//   description: string
// }[];

// type Owner = {
//   name: string,
//   id: number
// }[];




export default defineComponent({
  components: {
    NavBar,
    SideBar,
  },
  data() {
    return {
      cookiesId: this.$cookies.get("programId"),
      cookiesPermission: this.$cookies.get("Permission"),
      cookiesUser: this.$cookies.get("id"),
      program: [],
      owners: [],
      editions: [],
      showMore: true,
    }
  },
  created() {
    if (this.cookiesPermission == -1) {
      axios.get(`/Program/showInfoProgram?id1=${this.cookiesId}&idUser=${this.cookiesUser}`)
        .then(function (response) {
          return response;
        })
        .then(response => {
          if (response.status == 200) {
            this.program = response.data;
            this.owners = response.data.owners;
            this.editions = response.data.editions;
          } else if (response.status == 204) {
            alert("There was an error on our database! Please, try again later.");
          }
        })
    } else if (this.cookiesId == -1) {

      axios.get(`/Program/showBasicInfo?id1=${this.cookiesPermission}`)
        .then(function (response) {
          return response
        })
        .then(response => {
          if (response.status == 200) {
            this.program = response.data;
            this.owners = response.data.owners;
          } else if (response.status == 204) {
            alert("There was an error on our database! Please, try again later.");
          }
        })
    }
  },
  methods: {
    hasEndDate() {
      return this.program.endDate == null ? '' : (' - ' + this.formatDate(this.program.endDate));
    },
    formatDate(value) {
      if (value) {
        return moment(String(value)).format('MM/DD/YYYY')
      }
    },
    showMoreMethod() {
      if ((this.program != null) && (this.program.description.length > 500 && (this.editions.length != 0 || this.isOwner))) {
        return true;
      }
      return false;
    },
    toggleShowMore() {
      this.showMore = !this.showMore;
    },
    commaAnd() {
      var pos = 0;
      var retorno = '';
      this.owners.forEach(owner => {
        if (this.owners.length == 1) {
          retorno += owner.name;
        } else {
          if (pos == this.owners.length - 2) {
            retorno += owner.name + ' and '
          } else if (pos != this.owners.length - 1) {
            retorno += owner.name + ', '
          } else {
            retorno += owner.name;
          }
        }
        pos++;
      })
      return retorno;
    },
    settingCookies(id) {
      console.log("id" + id);
      this.$cookies.set("editionId", id);
      if (this.isOwner) {
        this.$cookies.set("isOwner", 1);
      } else {
        this.$cookies.set("isOwner", 0);
      }
    },
  },
  computed: {
    isOwner() {
      const idAccess = this.$cookies.get("id");
      var boolean = false;
      this.owners.forEach(owner => {
        if (owner.id == idAccess) {
          boolean = true;
        }
      });
      return boolean;
    },
    howMuchOfDescriptionShown() {
      if (!this.showMoreMethod() || !this.showMore) {
        return this.program.description;
      } else {
        return this.program.description.slice(0, 500) + "...";
      }
    },
    toggleShowS() {
      if (this.owners.length == 1) {
        return ''
      } else {
        return 's'
      }
    }
  }
})
</script>

<template>
  <NavBar></NavBar>
  <SideBar></SideBar>
  <div class="container" v-if="program.length != 0">
    <p class="title">{{ program.name }}</p>
    <p class="date">{{ formatDate(this.program.startDate) }}{{ hasEndDate() }}</p>
    <p class="description">{{ howMuchOfDescriptionShown }} &nbsp; <a @click="toggleShowMore()" v-if="showMoreMethod()"
        href="#">View {{ showMore? 'More': 'Less' }}</a></p>

    <div class="bottomInfo">
      <p class="owner">Owner{{ toggleShowS }}: &nbsp; </p>
      <p class="owner"> {{ commaAnd() }}</p>
        <RouterLink style="text-decoration: none" :to= "{name: 'EditProgram', params:{idProgram:cookiesId}}">
      <p v-if="isOwner" class="button dds__button dds__button--primary" type="button">
        <img src="../assets/pencil.png" alt="pencil icon" width="19">
        Edit Program
      </p>
    </RouterLink>
    </div>

    <h4 class="subtitle" v-if="cookiesPermission == -1">
      Editions
    </h4>

    <div class="row">

      <div v-if="isOwner" class="initialCard col-3 dds__ml-3 dds__mr-4 dds__mb-3">
        <div class="col-lg-12 col-md-12 col-sm-12 dds__mb-3">
          <div class="dds__card">
            <div class="dds__card__content">
              <div class="addProgramIcon dds__card__body">
                <RouterLink style="text-decoration: none" to="/edition">
                  +
                </RouterLink>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="initialCard col-3 dds__ml-3 dds__mr-4 dds__mb-3" v-for="edition in editions" :key="edition.id">
        <div v-if="cookiesPermission == -1" class="col-lg-12 col-md-12 col-sm-12 dds__mb-3">
          <div class="dds__card">
            <div class="dds__card__content">
              <div class="dds__card__header">
                <span class="dds__card__header__text">
                  <h5 class="dds__card__header__title">{{ edition.name }}</h5>
                </span>
              </div>
              <div class="dds__card__body">{{ edition.description }} </div>
              <div class="dds__card__footer">
                <RouterLink
                  style="text-decoration: none;   font-size: 15px;  position: absolute;  bottom: 0;  text-align: center;   left: 0;  margin-left: 20px;  margin-top: 10px;  padding-bottom: 17px;"
                  to="/editioninfo" @click="settingCookies(edition.id)"> View More ➔
                </RouterLink>
              </div>
            </div>
          </div>
        </div>
      </div>

    </div>


  </div> <!-- ends the container-->
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
</style>