
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
    },
    {
      path: '/users',
      name: 'users',
      component: () => import('../components/TesteUser.vue') //teste, pode trocar, so troca so o componente, nao o path nem o name
    },
    {
      path: '/program',
      name: 'CreateProgram',
      component: () => import('../views/CreateProgramView.vue')    
    },
  ]
})

export default router
