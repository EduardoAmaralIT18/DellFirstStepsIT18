<script setup lang="ts">

import {onMounted, ref} from "vue";
import axios from "axios";
import type User from "@/interfaces/User";
import router from '@/router';
import Popup from "@/components/Popup.vue";
import Select from "@/components/Select.vue";

const users = ref<User[]>([]);
const pagedUsers = ref<User[]>([]);
const currentPage = ref<number>(1);

const pageSize = 15;
const maxPages = ref<number>(0);

onMounted(async () => {
  redirectIfNotAdmin();
  await findAllUsers();
  maxPages.value = Math.ceil(users.value.length / pageSize);
  loadPagedUsers();
})

const selectedUser = ref<User>();
const changingRoleUser = ref<User>();

const selectUser = (user: User) => {
  selectedUser.value = user;
}

const loadPagedUsers = () => {
  const startIndex = (currentPage.value - 1) * pageSize;
  const endIndex = startIndex + pageSize;
  pagedUsers.value = users.value!.slice(startIndex, endIndex);
}

const nextPage = () => {
  if (currentPage.value < maxPages.value) {
    currentPage.value++;
    loadPagedUsers()
    window.scrollTo(0, 0)
  }
}

const prevPage = () => {
  if (currentPage.value > 1) {
    currentPage.value--;
    loadPagedUsers()
    window.scrollTo(0, 0)
  }
}


const deleteUser = async () => {
  await axios.delete(`https://localhost:5001/User/removeUser/${selectedUser.value?.id}`)
      .then(async () => {
        await findAllUsers();
        selectedUser.value = undefined;
        loadPagedUsers()
      })
      .catch((e) => {
        console.error(e);
      })
}

const updateUser = async (user: User) => {
  await axios.patch(`https://localhost:5001/User/changeRole?userId=${user.id}&role=${user.role}`)
      .then(async () => {
        await findAllUsers();
        changingRoleUser.value = undefined;
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
  return id == +localStorage.getItem('userId')!;
}

const redirectIfNotAdmin = () => {
  if (+localStorage.getItem('userRole')! != 0) {
    router.push('/');
  }
}

const close = () => {
  selectedUser.value = undefined
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
  <div>
    <div id="popup-background" v-if="selectedUser">
      <Popup
          @closePopup="close"
          id="popup-delete-user"
          :title="popupTitle"
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
        <tr class="dds__tr" v-for="user in pagedUsers">
          <td class="dds__td">{{ user.name }}</td>
          <td id="email_td" class="dds__td">{{ user.email }}</td>
          <td class="dds__td">
            <select v-if="!itsMe(user.id)" id="select-control-505500786" v-model="user.role" @change="updateUser(user)"
                    class="dds__select__field">
              <option v-for="role in roles" :key="role" :value="roles.indexOf(role)">
                {{ role }}
              </option>
            </select>
            <div v-else>{{ roles[user.role] }}</div>
          </td>
          <td class="dds__td" id="delete-td">
            <button v-if="!itsMe(user.id)" class="red dds__button dds__button--destructive" type="button"
                    @click="selectUser(user)">
              <i class="dds__icon dds__icon--user-remove" aria-hidden="true"></i>
            </button>
          </td>
        </tr>
        </tbody>
        <div>
          <div class="pagination dds__pagination" data-dds="pagination" id="516534716" role="navigation"
               aria-label="pagination-516534716">
            <div class="dds__pagination__nav">
              <button @click="prevPage" :disabled="currentPage === 1" type="button"
                      class="dds__button dds__button--tertiary dds__button--sm dds__pagination__prev-page"
                      aria-label="Previous page">
                <span class="dds__pagination__prev-page-label">Previous</span>
              </button>
              <div class="dds__pagination__page-range">
                <label class="dds__pagination__page-range-label" for="pagination-current-page-516534716">Page</label>
                <div class="dds__input-text__container dds__input-text__container--sm">
                  <div class="dds__input-text__wrapper dds__pagination__page-range-current-wrapper">
                    {{ currentPage }}
                  </div>
                </div>
                <div class="dds__pagination__page-range-total-label">
                  of
                  <span class="dds__pagination__page-range-total">
                {{ maxPages }}
              </span>
                </div>
              </div>
              <button type="button"
                      class="dds__button dds__button--tertiary dds__button--sm dds__pagination__next-page"
                      aria-label="Next page"
                      @click="nextPage"
                      :disabled="currentPage === maxPages"
              >
                <span class="dds__pagination__next-page-label">Next</span>
              </button>
            </div>
          </div>
        </div>
      </table>
    </div>
  </div>
</template>

<style scoped>
.container {
  padding: 5% 20% 50vh 20%;
  display: flex;
  flex-direction: column;
  background-color: #efefef;
  overflow-x: auto;
}

#popup-background {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
}

#popup-delete-user {
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
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