<!-- ALTERADO -->
<template>
    <div class = "container">
        <form data-dds="form" class="dds__form dds__container">
<fieldset class="dds__form__section">
    <a class="navbar-brand" href="#">LOGO</a>
    <!-- <legend>Login System</legend> -->
    <div class="dds__row">
    <div class="dds__col--1 dds__col--sm-3">
        <legend>Select your email</legend>
        <div id="app">
        <AppDropdown>
            <template slot="toggler">
            <button>Toggle</button>
            </template>
        <AppDropdownContent>
        <AppDropdownItem>
            <div v-if="user != null" class="dds__col-12 dds__col--md-6 dds__col--lg-4 dds__mb-3" id="card-user">
            <div v-for="item in user" :key="item.id" class="dds__card">
            
                <div class="dds__card__content">
                    <div class="dds__card__header">
                        <span class="dds__card__header__text">
                            <h5 class="dds__card__header__title">{{ item.email }}</h5>
                        </span>
                    </div>
                    <div class="dds__card__body">{{ item.role }}</div>
                    <button class="dds__button dds__button--primary dds__button--lg" type="button">
                        <i class="dds__icon dds__icon--plus-add" aria-hidden="true"></i>Login
                    </button>
                </div>
            </div>
        </div>
        </AppDropdownItem>
        
    </AppDropdownContent>
    </AppDropdown>
</div>
    </div>
</div>


</fieldset>
<button class="dds__button" type="submit">Submit</button>
</form>


    </div>
</template>

<script lang="ts">
import AppDropdown from './components/AppDropdown.vue'
import AppDropdownContent from './components/AppDropdownContent.vue'
import AppDropdownItem from './components/AppDropdownItem.vue'
import { defineComponent } from 'vue';
import axios from 'axios';

type User = {

}[];

interface Data {
    user: null | User,
    item:{
        id: Number,
        name: string,
        email: string,
        role: Number
    }
}

/*export default {
    name: 'app',
    components: {
      AppDropdown,
      AppDropdownContent,
      AppDropdownItem,
    }
  }
*/
export default defineComponent({
    data(): Data {
        return {
            user: null,
            item:{
                id: 0,
                name: '',
                email: '',
                role: 1
            }
        };
    },
   

    created() {
        // fetch the data when the view is created and the data is
        // already being observed
        this.fetchData();
    },
    watch: {
        // call again the method if the route changes
        '$route': 'fetchData'
    },
    methods: {
        fetchData(): void {
            axios.get('/Login/getUserList')
                 .then(function(response){
                    return response;   
                 }).then(response=>{
                    this.user = response.data;
                    return;
                 })
        },
       setCookies(): void{
        this.$cookies.set("id",this.item.id);
        this.$cookies.set("name",this.item.name);
        this.$cookies.set("role",this.item.role);
        this.$cookies.set("email",this.item.email);
       } 
},


});
</script>
   