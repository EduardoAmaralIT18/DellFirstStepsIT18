<!-- bobl -->
<template>
  <div class="container">
    <table id="components-table--static" class="dds__table">
      <thead class="dds__thead">
        <tr class="dds__tr">
          <th class="dds__th">Name</th>
          <th class="dds__th">Email</th>
          <th class="dds__th">Role</th>
          <th class="dds__th" id="delete-th">
            <i class="dds__icon dds__icon--gear" aria-hidden="true"></i>
          </th>
        </tr>
      </thead>
      <tbody class="dds__tbody">
        <tr v-for="user in users" :key="user.id" class="dds__tr">
          <td class="dds__td">{{ user.name }}</td>
          <td class="dds__td">{{ user.email }}</td>
          <td class="dds__td">
            <div v-if="userLogged != user.id" class="dds__select__wrapper">
              <select v-model="user.role" class="dds__select" aria-describedby="select-helper-374041805" required="true"
                @change="roleChange(user.id, user.role)">
                <option v-for="item in role" :value="role.indexOf(item)" :key="item">
                  {{ item }}
                </option>
              </select>
            </div>
          </td>
          <td class="dds__td" id="delete-td">
            <button v-if="userLogged != user.id" class="dds__button dds__button--destructive" type="button"
              @click="removeUser(user.id)"> <i class="dds__icon dds__icon--user-remove" aria-hidden="true"></i></button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import axios from 'axios';

type User = {
  id: number,
  name: string,
  email: string,
  role: number,
}[];

interface Data {
  users: User | null
  role: string[],
  userLogged: number | null,
  roleLogged: number | null,
}

export default defineComponent({
  name: 'UserPage',
  components: {
  },
  data(): Data {
    return {
      users: null,
      role: ["Admin",
        "Intern",
        "DellManager",
        "DellMember",
        "PucrsStaff"],
      userLogged: null,
      roleLogged: null,
    };
  },
  created() {
    // fetch the data when the view is created and the data is
    // already being observed
    this.fetchData();
  },
  methods: {
    fetchData(): void {
      this.users = null;

      this.roleLogged = this.$cookies.get("role");
      this.userLogged = this.$cookies.get("id");

      axios.get('/user/listUsers')
        .then(function (response) {
          return response;
        })
        .then(response => {
          if (response.status == 404) {
            alert("No users found!");
            this.users = null;
          } else if (response.status == 200) {
            this.users = response.data;
          } else {
            alert("Database error. Please try again later.");
            console.log(response.status);
          }
        });
    },
    roleChange(userid: number, role: number): void {

      axios.get('user/changeRole', {
        params: {
          user: userid, role: role
        }
      })
        .then(function (response) {
          return response;
        })
        .then(response => {
          if (response.status == 200) {
            alert("Role changed sucessfully.");
          } else {
            alert("Database error. Please try again later.");
          }
        });
    },
    removeUser(userid: number): void {

      axios.get('user/removeUser', {
        params: {
          user: userid
        }
      })
        .then(function (response) {
          return response;
        })
        .then(response => {
          if (response.status == 200) {
            alert("User removed sucessfully");
            this.fetchData();
          } else {
            alert("Database error. Please try again later.");
          }
        });



    },
  }
});

</script>

<style scoped>
.container {
  padding-top: 5%;
  padding-bottom: 50vh;
  padding-left: 20%;
  display: flex;
  flex-direction: column;
}

select.dds__select {
  width: 100%;
  height: 45px;
  font-size: 14px;
  padding: .6875rem 4.5rem .6875rem 1rem;
  border: .0625rem solid #7e7e7e;
  border-radius: .125rem;
  background-clip: padding-box;
  margin-top: 1%;
  margin-bottom: 1%;
}

table.dds__table {
  display: table;
}

button {
  width: 25%;
  height: 70%;
}
</style>
