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
        <tr v-for="user in usersShow" :key="user.id" class="dds__tr">
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
            <button v-if="userLogged != user.id" class="red dds__button dds__button--destructive" :id="user.id"
              type="button" @click="removeModal(user.id, user.name)"> <i class="dds__icon dds__icon--user-remove"
                aria-hidden="true"></i></button>
          </td>
        </tr>
      </tbody>
      <!--Pagination-->
      <div class="pagination dds__pagination" data-dds="pagination" id="516534716" role="navigation"
        aria-label="pagination-516534716">
        <div class="dds__pagination__nav">
          <button v-if="currentPage > 1" type="button"
            class="dds__button dds__button--tertiary dds__button--sm dds__pagination__prev-page"
            aria-label="Previous page" @click="userPagination(2)">
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
                {{ totalPages }}
              </span>
            </div>
          </div>
          <button v-if="currentPage < totalPages" type="button"
            class="dds__button dds__button--tertiary dds__button--sm dds__pagination__next-page" aria-label="Next page"
            @click="userPagination(1)">
            <span class="dds__pagination__next-page-label">Next</span>
          </button>
        </div>
      </div>
    </table>
  </div>


  <!-- Modal Confirm Remove User-->
  <div role="dialog" data-dds="modal" class="dds__modal" ref="modalConf" aria-labelledby="modal-headline-153968555">
    <div class="dds__modal--md">
      <div class="dds__modal__content">
        <div class="dds__modal__header">
          <h3 class="dds__modal__title">Remove User</h3>
        </div>
        <div id="modal-body-357113985" class="dds__modal__body">
          <p>
            You are about to revoke the access of {{ nameSelected }}. <br> Are you sure that you want to proceed?
          </p>
        </div>
        <div class="dds__modal__footer">
          <button class="dds__button dds__button--secondary dds__button--md buttonModal" type="button" name="modal-primary-button"
            @click="closeModal">No</button>
          <button class="dds__button dds__button--md buttonModal" type="button" name="modal-secondary-button"
            @click="removeUser(userSelected)">Yes</button>
        </div>
      </div>
    </div>
  </div>
  <!--Modal Ok para changeRole or removeUser-->
  <div role="dialog" data-dds="modal" class="dds__modal" ref="modalOk" aria-labelledby="modal-headline-153968555">
    <div class="dds__modal--md">
      <div class="dds__modal__content">
        <div class="dds__modal__header">
          <h3 class="dds__modal__title">{{ modalTitle }}</h3>
        </div>
        <div id="modal-body-357113985" class="dds__modal__body">
          <p>
            {{ modalText }}
          </p>
        </div>
        <div class="dds__modal__footer">
          <button class="dds__button dds__button--md buttonModal" type="button" name="modal-secondary-button" @click="closeModal">
            Ok
          </button>
        </div>
      </div>
    </div>
  </div>
  <!--Modal Error message-->
  <div role="dialog" data-dds="modal" class="dds__modal" ref="modalError" aria-labelledby="modal-headline-153968555">
    <div class="dds__modal--md">
      <div class="dds__modal__content">
        <div class="dds__modal__header">
          <h3 class="dds__modal__title">Error</h3>
        </div>
        <div id="modal-body-357113985" class="dds__modal__body">
          <p>
            I'm sorry, something went wrong. Try again later.
          </p>
        </div>
        <div class="dds__modal__footer">
          <button class="dds__button dds__button--md dds__button--detructive buttonModal" type="button"
            name="modal-secondary-button" @click="closeModal"> Ok </button>
        </div>
      </div>
    </div>
  </div>

</template>

<script lang="ts">
import { defineComponent } from 'vue';
import axios from 'axios';

declare var DDS: any;



type User = {
  id: number,
  name: string,
  email: string,
  role: number,
}[];

interface Data {
  users: User | null,
  role: string[],
  userLogged: number | null,
  roleLogged: number | null,
  userSelected: number | null,
  nameSelected: string | null,
  modalConf: unknown | null,
  modalOk: unknown | null,
  elementConf: unknown | null,
  elementOk: unknown | null,
  modalError: unknown | null,
  elementError: unknown | null,
  modalText: string,
  modalTitle: string,
  totalPages: number,
  currentPage: number,
  usersShow: User | null,
  finalUser: number,
  initUser: number,
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
      userSelected: null,
      nameSelected: null,
      modalConf: null,
      modalOk: null,
      elementConf: null,
      elementOk: null,
      elementError: null,
      modalError: null,
      modalText: "",
      modalTitle: "",
      totalPages: 0,
      currentPage: 1,
      usersShow: [],
      finalUser: 0,
      initUser: 0
    };
  },
  mounted() {
    this.elementConf = this.$refs.modalConf;
    this.modalConf = DDS.Modal(this.elementConf);

    this.elementOk = this.$refs.modalOk;
    this.modalOk = DDS.Modal(this.elementOk);

    this.elementError = this.$refs.modalError;
    this.modalError = DDS.Modal(this.elementError);
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
            this.totalPages = Math.ceil((this.users?.length) / 15);
            this.userPagination(0);
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
            this.modalTitle = "Role Changed";
            this.modalText = "Role changed successfully.";
            this.modalOk.open();
          } else {
            this.modalError.open();
          }
        });
    },
    removeModal(userid: number, userName: string) {
      this.userSelected = userid;
      this.nameSelected = userName;

      this.modalConf.open();

    },
    closeModal(): void {
      this.modalConf.close();
      this.modalOk.close();
      this.modalError.close();
    },
    removeUser(userid: number | null): void {

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
            this.modalConf.close();
            this.modalTitle = "User Removed";
            this.modalText = "The user " + this.nameSelected + " no longer has access to Dell FirstSteps.";
            this.modalOk.open();
            this.fetchData();
          } else {
            this.modalError.open();
          }
        });
    },
    userPagination(mode: number): void {
      if (mode == 2) {
        this.usersShow.length = 0;
        this.currentPage--;
        this.finalUser = (this.currentPage * 15) - 1;
        this.initUser = this.finalUser - 14;
        for (let index = this.initUser; index <= this.finalUser; index++) {
          this.usersShow?.push(this.users[index]);
        }
        this.initUser = this.finalUser + 1;
      } else if (mode == 1) {
        this.usersShow.length = 0;
        this.currentPage++;
        this.finalUser = (this.currentPage * 15) - 1;
        for (let index = this.initUser; index <= this.finalUser; index++) {
          if (this.users[index] == null) {
            break;
          }
          this.usersShow?.push(this.users[index]);
        }
        this.initUser = this.finalUser + 1;
      } else {
        this.usersShow?.length = 0;
        this.initUser = 0;
        this.finalUser = 14;
        for (let index = this.initUser; index <= this.finalUser; index++) {
          this.usersShow?.push(this.users[index]);
        }
        this.initUser = 15;
      }
      window.scrollTo(0, 0);
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

button.red {
  width: 25%;
  height: 70%;
}

.pagination {
  padding-left: 15px;
}

p {
  text-align: left;
}
</style>
