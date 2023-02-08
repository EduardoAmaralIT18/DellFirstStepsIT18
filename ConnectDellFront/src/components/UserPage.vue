
<template>
  <div class="container">
    <table id="components-table--static" class="dds__table">
      <thead class="dds__thead">
        <tr class="dds__tr">
          <th class="dds__th">Name</th>
          <th class="dds__th">Email</th>
          <th class="dds__th">Role</th>
        </tr>
      </thead>
      <tbody class="dds__tbody">
        <tr v-for="user in users" :key="user.id" class="dds__tr">
          <td class="dds__td">{{ user.name }}</td>
          <td class="dds__td">{{ user.email }}</td>
          <td class="dds__td">
            <div class="dds__select__wrapper">
              <select :value="user.role" v-model="user.role" id="user.role" class="dds__select__field"
                aria-describedby="select-helper-374041805" required="true" @change="roleChange(user.id)">
                <option :value="user.role" selected>{{ user.roleName }}</option>
                <option v-for="item in role" :value="item.indexOf(item)" :key="item.indexOf(item)">
                  {{ item }}
                </option>
              </select>
            </div>
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
  roleName: string,
}[];

interface Data {
  users: User | null
  role: string[]
}

export default defineComponent({
  name: 'UserPage',
  components: {
  },
  data(): Data {
    return {
      users: null,
      role: [ "Admin",
        "Intern",
        "DellManager",
        "DellMember",
        "PucrsStaff"]
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
            alert("Databade error. Please try again later.");
            console.log(response.status);
          }
        });
    },
    roleChange(userid: number): void{
      console.log(userid);
    }
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

table{
  width: 50%;
}
</style>
