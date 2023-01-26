
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
      name: 'NewsPage',
      component: () => import('../views/NewsView.vue')
    },
    {
      path: '/users',
      name: 'users',
      component: () => import('../components/TesteUser.vue') //teste, pode trocar, so troca so o componente, nao o path nem o name
    },
    {
      path: '/createprogram',
      name: 'CreateProgram',
      component: () => import('../views/CreateProgramView.vue')
    },

    {
      path: '/edition',
      name: 'CreateEdition',
      component: () => import('../views/CreateEditionView.vue')
    },

    {
      path: '/updateedition',
      name: 'UpdateEdition',
      component: () => import('../views/UpdateEditionView.vue')
    },
    {
      path: '/programinfo',
      name: 'ProgramsPage',
      component: () => import('../components/ProgramsPage.vue')
    },
    {
      path: '/editioninfo',
      name: 'EditionsPage',
      component: () => import('../components/EditionsPage.vue')
    },
    {
      path: '/addnews',
      name: 'addnews',
      component: () => import('../views/AddNewsView.vue')
    },
    //{ path: '/notfound(.*)*', name: 'NotFound', component:() => import ('..views/NotFoundView.vue'},
    
    // {
    //   path: '/editprogram/:idProgram',
    //   name: 'EditProgram',
    //   component: () => import('../views/EditProgramView.vue')
    // }
  ]
})

export default router
