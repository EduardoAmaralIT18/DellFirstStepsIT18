import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import MyProgramView from "@/views/MyProgramView.vue";
import ProgramView from "@/views/ProgramView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/Home',
      name: 'home',
      component: HomeView
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
