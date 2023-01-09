
import HomePageVue from '@/components/HomePage.vue'
import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'
const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/logged',
      name: 'home',
      component: HomePageVue
    },
    {
      path: '/',
      name: 'login',
      component: LoginView
    }
  ]
})

export default router
