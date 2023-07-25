import { createRouter, createWebHistory } from 'vue-router';
import LoginView from '../views/LoginView.vue';
import HomeView from '../views/HomeView.vue';
import NewsView from '../views/NewsView.vue';
import ProgramView from "../views/ProgramView.vue";
import MyProgramView from '../views/MyProgramView.vue';
// import UsersView from '../views/UsersView.vue';
import CreateProgramView from '../views/CreateProgramView.vue';
import CreateEditionView from '../views/CreateEditionView.vue';
import UsersView from "@/views/UsersView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/login',
      name: 'Login',
      component: LoginView,
    },
    {
      path: '/home',
      name: 'Home',
      component: HomeView,
    },
    {
      path: '/news',
      name: 'News',
      component: NewsView,
    },
    {
      path: '/myProgram/:id',
      name: 'My Program',
      component: MyProgramView,
    },
    {
      path: '/program/:id',
      name: 'Program',
      component: ProgramView,
    },
    {
      path: '/users',
      name: 'Users',
      component: UsersView
    },
    {
      path: '/createProgram',
      name: 'CreateProgram',
      component: CreateProgramView,
    },
    {
      path: '/myProgram/:id/createEdition',
      name: 'CreateEdition',
      component: CreateEditionView,
    },
    // {
    //   path: '/addNews',
    //   name: 'Add News',
    //   component: ,
    // },
    // {
    //   path: '/editNews/:id',
    //   name: 'Edit news',
    //   component: ,
    // }
  ]
})

router.beforeEach(async (to, from, next) => {
  if (to.name === 'Login' && localStorage.getItem("userRole") !== '') {
      localStorage.setItem("userName", "");
      localStorage.setItem("userId", "");
      localStorage.setItem("userEmail", "");
      localStorage.setItem("userRole", "");
      next();
  } else {
    next();
  }
});

export default router