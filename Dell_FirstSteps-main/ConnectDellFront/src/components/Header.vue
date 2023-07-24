<script setup lang="ts">
defineProps({
  name: String,
  role: String,
});

function getRoleString(role: number) {
  console.log(role);
  switch (role) {
    case 0:
      return 'Admin';
    case 1:
      return 'Intern';
    case 2:
      return 'Dell Manager';
    case 3:
      return 'Dell Member';
    case 4:
      return 'Dell PUCRS Staff';
    default:
      return undefined;
  }
}

</script>

<template>
  <header class="navbar shadow-lg fixed-top">
    <picture>
      <source media="(min-width: 900px)" class="logo" alt="logo Dell" srcset="../assets/logoDell.png" />
      <img class="logo" alt="logo Dell" src="../assets/small-logo-dell.png" />
    </picture>
    <p v-if="name && role" class="name">{{ name }} | {{ getRoleString(+role) }}</p>
    <img v-if="name && role" class="userPicture" alt="icon" src="../assets/user.png" />
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
