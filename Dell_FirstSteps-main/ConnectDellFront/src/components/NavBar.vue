<template>
  <header class="navbar shadow-lg fixed-top">
      <div class="container-fluid">
          <div class="row">
              <div class="col-4 dellLogo">
                <a><img class="logo" alt="logo Dell" src="../assets/logoDell.png"></a>
              </div>
              <div class="col-8">
              <nav class="userName">
                  <div class="d-none d-lg-block">
                    <p class="name"> {{ NAME }} | {{ showRole() }}<img class="userPicture" alt="user icon" src="../assets/user.png"></p>
                  </div>
                </nav>            
              </div>

          </div>
      </div>
  </header>
</template>

<style>
  .navbar{
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
  .name{
    color: #0672CB;
    font-size: 151%;
    position: absolute;
    right: 0;
    top:0;
    margin-top: 10px;
    margin-right: 1%;
  }
  .userPicture{
    width: 47px;
    margin-left: 1px;
    margin-bottom: 3%;
    padding-top: 4px;
  }
  .logo{
    width: 400px;
    margin-left: 3%;
    top:0;
    position: relative;
  }
</style>

<script lang="ts">

import { defineComponent } from 'vue';

interface Data {
  NAME: string,
  ROLE: number,
}

export default defineComponent({
  data(): Data {
    return {
      NAME: this.$cookies.get("name"),
      ROLE: this.$cookies.get("role")
    }
  },
  methods: {
    showRole() {
      if ((this.ROLE == 0)) {
        return "Admin";
      } else if ((this.ROLE == 1)){
          return "Intern";
      } else if ((this.ROLE == 2)){
          return "Dell Manager";
      } else if ((this.ROLE == 3)){
          return "Dell Member";
      } else if ((this.ROLE == 4)){
          return "Dell Pucrs Staff";
      }
    }
  }
})
</script>