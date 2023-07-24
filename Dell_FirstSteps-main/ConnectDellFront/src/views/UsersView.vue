<script setup lang="ts">

import {onMounted, ref} from "vue";
import axios from "axios";
import type User from "@/interfaces/User";
import router from '@/router';
import Popup from "@/components/Popup.vue";

const users = ref<User[]>()
onMounted(async () => {
  redirectIfNotAdmin();
  await findAllUsers();
})

const selectedUser = ref<User>()

const selectUser = (user: User) => {
  selectedUser.value = user;
}

const deleteUser = async () => {
  await axios.delete(`https://localhost:5001/User/removeUser/${selectedUser.value?.id}`)
      .then(async () => {
        await findAllUsers();
        selectedUser.value = undefined;
      })
      .catch((e) => {
        console.error(e);
      })
}

const findAllUsers = async () => {
  await axios.get('https://localhost:5001/User/listUsers')
      .then((response) => {
        users.value = response.data
      }).catch((e) => {
        console.error(e);
      })
}

const itsMe = (id: number) => {
  return id == +localStorage.getItem('userId');
}

const redirectIfNotAdmin = () => {
  if (localStorage.getItem('userRole') != 0) {
    router.push('/');
  }
}
const popupTitle = "Remove user"
const roles = [
  "Admin",
  "Intern",
  "Dell Manager",
  "Dell Member",
  "Puc-RS Staff"
]
</script>

<template>
  <div v-if="selectedUser">
    <Popup :title="popupTitle"
           :text="`You are about to revoke the access of ${selectedUser.name}.`"
           :object="selectedUser" :action="deleteUser"></Popup>
  </div>
  <div class="container">
    <table id="components-table--static" class="dds__table">
      <thead class="dds__thead">
      <tr class="dds__tr">
        <th class="dds__th">Nome</th>
        <th class="dds__th">Email</th>
        <th class="dds__th">Cargo</th>
        <th id="delete-th" class="dds__th"><i class="dds__icon dds__icon--gear" aria-hidden="true"></i></th>
      </tr>
      </thead>
      <tbody class="dds__tbody">
      <tr class="dds__tr" v-for="user in users">
        <td class="dds__td">{{ user.name }}</td>
        <td id="email_td" class="dds__td">{{ user.email }}</td>
        <td class="dds__td">{{ roles[user.role] }}</td>
        <td class="dds__td" id="delete-td">
          <button v-if="!itsMe(user.id)" class="red dds__button dds__button--destructive" :id="user.id" type="button"
                  @click="selectUser(user)">
            <i class="dds__icon dds__icon--user-remove" aria-hidden="true"></i>
          </button>
        </td>
      </tr>
      </tbody>

    </table>
  </div>
</template>

<style scoped>
.container {
  padding: 5% 20% 50vh 20%;
  display: flex;
  flex-direction: column;
  background-color: #efefef;
}

td {
  word-wrap: break-word;
  overflow-wrap: break-word;
  word-break: break-all;
  height: 70px;
  padding: 0;
}

table.dds__table {
  display: table;
}

button.red {
  width: 25%;
  height: 70%;
}
</style>