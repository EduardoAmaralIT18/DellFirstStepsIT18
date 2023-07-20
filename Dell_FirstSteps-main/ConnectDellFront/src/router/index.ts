import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'login',
      component: LoginView,
    },
    {
      path: '/Home',
      name: 'home',
      component: () => import("../views/HomeView.vue"),
    },{
      path: '/News',
      name: 'news',
      component: () => import("../views/NewsView.vue"),
    },
  ]
})

export default router
