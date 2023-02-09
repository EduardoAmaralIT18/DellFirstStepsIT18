<!-- ALTERADO -->
<template>

  <header class="navbar shadow-lg fixed-top">
    <div class="container-fluid">
      <div class="row">
        <div class="col-4 dellLogo">
          <a href="index.html"><img class="logo" alt="logo Dell" src="../assets/logoDell.png"></a>
        </div>
      </div>
    </div>
  </header>

  <div class="container">



    <button class="dds__button" id="example" type="button">Launch modal button</button>
    <div role="dialog" data-dds="modal" class="dds__modal" id="uniqueid" ref="uniqueid">
      <div class="dds__modal__content">
        <div class="dds__modal__header">
          <h3 class="dds__modal__title" id="modal-headline-369536123">Present new laptop</h3>
        </div>
        <div id="modal-body-532887773" class="dds__modal__body">
          <p>
            Small, light, and stylish laptops and 2-in-1s designed for ultimate productivity. A new era of collaboration
            and connectivity to
            work anywhere. XPS laptops and 2-in-1s are precision crafted with premium materials, featuring stunning
            displays and the performance
            you demand to express your creative self and your big ideas.
            <a href="https://www.dell.com">dell.com</a>
          </p>
        </div>
        <div class="dds__modal__footer">
          <button class="dds__button dds__button--secondary dds__button--md" type="button"
            name="modal-primary-button">No</button>
          <button class="dds__button dds__button--md" type="button" name="modal-secondary-button">Yes</button>
        </div>
      </div>
    </div>

    <form>

      <div class="dds__select" data-dds="select">
        <div class="dds__select__wrapper">
          <select :value="0" v-model="us.id" id="select-control-374041805" class="dds__select__field"
            aria-describedby="select-helper-374041805">
            <option :value="0" selected>Select</option>
            <option v-for="item in user" v-bind:value="item.id" v-bind:key="item.id">
              {{ item.email }}
            </option>
          </select>
        </div>
      </div>
      <button class="submitbutton dds__button dds__button--lg" type="submit"
        @click.prevent="setCookies()">Login</button>
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import axios from "axios";
//import {nextTick} from 'vue'
//import {ref, Ref} from 'vue';
//const root = ref<HTMLElement | null>(uniqueid);
 declare var DDS: any;



type User = {
  id: Number;
  name: string;
  email: string;
  role: Number;
}[];

interface Data {
  user: null | User;
  us: {
    id: Number;
    name: string;
    email: string;
    role: Number;
  };
}


export default defineComponent({
  data(): Data {
    return {
      user: null,
      us: {
        id: 0,
        name: "",
        email: "",
        role: 1,
      },
    };
  },
  created() {
    // fetch the data when the view is created and the data is
    // already being observed
    this.fetchData();
  },
  mounted() {
    this.teste();
  },
  watch: {
    // call again the method if the route changes
    $route: "fetchData",
  },
  methods: {
    teste(): void {
      const element = this.$refs.uniqueid;
      // console.log(element);
      console.log(DDS);
      console.log(element);
      const modal = new DDS.Modal(element, { trigger: "#example" });
      console.log(modal);
    },
    fetchData(): void {
      axios
        .get("/Login/getUserList")
        .then(function (response) {
          return response;
        })
        .then((response) => {
          this.user = response.data;
          return;
        });

    },
    setCookies(): void {
      var user = this.user?.find(u => u.id == this.us.id);
      this.$cookies.set("id", user?.id);
      this.$cookies.set("name", user?.name);
      this.$cookies.set("role", user?.role);
      this.$cookies.set("email", user?.email);
      this.$router.push({ name: "HomePage" });
    },


  },
});
</script>

<style scoped>
main {
  background-color: transparent;
}

body {
  background: #EEEEEE
}

button {
  display: flex;
  width: 50%;
  margin: 8% auto;
}
.container {
  padding-top: 3%;
  display: flex;
  flex-direction: column;
  background-color: #EEEEEE;
  align-items: center;
  justify-content: center;
  position: relative;
}

.title {
  color: #0063B8;
  margin-top: 8%;
  font-size: 200%;
  margin-bottom: 3%;
}

.navbar {
  padding-bottom: 0;
  margin-bottom: 0;
  background-color: #ffffff;
  box-shadow: 2px 2px #a6a6a6ba;
  width: 100%;
  border-bottom: 2px solid #A6A6A6;
  margin-bottom: 0;
  width: 100%;
  height: 75px;
  padding-top: 3px;
}

.logo {
  width: 400px;
  margin-left: 3%;
  top: 0;
  position: relative;
}


</style>

<style>
main {
  background-color: #EEEEEE;
}
</style>