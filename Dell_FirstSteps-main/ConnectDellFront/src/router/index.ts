import { createRouter, createWebHistory } from 'vue-router';
import LoginView from '../views/LoginView.vue';
import HomeView from '../views/HomeView.vue';
import NewsView from '../views/NewsView.vue';
import ProgramView from "../views/ProgramView.vue";
import MyProgramView from '../views/MyProgramView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/login',
      name: 'login',
      component: LoginView,
    },
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },{
      path: '/News',
      name: 'news',
      component: NewsView,
    },
    {
      path: '/myProgram/:id',
      name: 'My Program',
      component: MyProgramView
    },
    {
      path: '/program/:id',
      name: 'Program',
      component: ProgramView
    }

  ]
})
export default router
