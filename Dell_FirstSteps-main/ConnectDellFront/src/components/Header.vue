<script setup lang="ts">
import { computed } from "vue";

const prop = defineProps({
  name:String,
  role:String
})


const showRole = computed(() =>{
  if (prop.role === '0') {
    return "Admin";
  } else if (prop.role === '1') {
    return "Intern";
  } else if (prop.role === '2') {
    return "Dell Manager";
  } else if (prop.role === '3') {
    return "Dell Member";
  } else if (prop.role === '4') {
    return "Dell Pucrs Staff";
  }
  return "-1";
})
</script>

<template>
  <header class="navbar shadow-lg fixed-top">
      <div class="container-fluid">
          <div class="row">
              <div class="col-4 dellLogo">
                <a><img class="logo" alt="logo Dell" src="../assets/logoDell.png"></a>
              </div>
              <div v-if=" showRole !== '-1'" class="col-8">
              <nav class="userName">
                  <div class="d-none d-lg-block">
                    <p class="name"> {{ name }} | {{ showRole }}<img class="userPicture" alt="user icon" src="../assets/user.png"></p>
                  </div>
                </nav>            
              </div>

          </div>
      </div>
  </header>
</template>

<style>
.navbar {
  padding-bottom: 0;
  display: flex;
  vertical-align: bottom;
  line-height: 50px;
  background-color: white;
  width: 100%;
  border-bottom: 2px solid #a6a6a6;
  height: 75px;
}
.name {
  color: #0672cb;
  font-size: 151%;
  position: absolute;
  right: 0;
  top: 0;
  margin-top: 10px;
  margin-right: 1%;
}
.userPicture {
  width: 47px;
  margin-left: 1px;
  margin-bottom: 3%;
  padding-top: 4px;
}
.icon {
  font-size: 13em;
  background-color: #0672cb;
  margin-left: 3%;
  padding: 10;
  position: relative;
  line-height: 0.2em;
}
.logo{
  height: 55px;
  margin-top: 10px;
  margin-left: 1%;
}
</style>
