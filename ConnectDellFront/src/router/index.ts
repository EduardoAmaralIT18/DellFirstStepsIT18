
import HomePageVue from '@/components/HomePage.vue'
import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
      name: 'login',
      component: LoginView
    },
    {
      path: '/home',
      name: 'HomePage',
      component: HomePageVue
    },
    {
      path: '/news',
      name: 'news',
      component: () => import('../views/NewsView.vue')
    }
  ]
})

export default router