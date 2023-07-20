import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/createprogram',
      name: 'CreateProgram',
      component: () => import('../views/CreateProgramView.vue')
    }
  ]
})

export default router