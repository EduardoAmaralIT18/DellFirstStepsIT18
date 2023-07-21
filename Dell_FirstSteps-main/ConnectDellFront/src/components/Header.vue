<script setup lang="ts">
defineProps({
  name: String,
  role: Number,
});

const type: any = {
  0: "Admin",
  1: "Intern",
  2: "Dell Manager",
  3: "Dell Member",
  4: "Dell Pucrs Staff",
  5: "",
};
</script>

<template>
  <header class="navbar shadow-lg fixed-top">
    <img class="logo" alt="logo Dell" src="../assets/logoDell.png" />
    <p v-if="name && role" class="name">{{ name }} | {{ type[role] }}</p>
    <img
      v-if="name && role"
      class="userPicture"
      alt="icon"
      src="../assets/user.png"
    />
  </header>
</template>

<style>
.navbar {
  display: flex;
  vertical-align: bottom;

  align-items: center;
  background-color: white;
  width: 100%;
  border-bottom: 2px solid #a6a6a6;
  height: 75px;
}

.name {
  color: #0672cb;
  font-size: 145%;
  margin-top: 0.8%;
  margin-left: auto;
}

.userPicture {
  width: 47px;
}
.logo {
  height: 45px;

  margin-left: 1%;
}
</style>
