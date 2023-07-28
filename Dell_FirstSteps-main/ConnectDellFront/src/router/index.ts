import { createRouter, createWebHistory } from 'vue-router';
import LoginView from '../views/LoginView.vue';
import HomeView from '../views/HomeView.vue';
import NewsView from '../views/NewsView.vue';
import ProgramView from "../views/ProgramView.vue";
import MyProgramView from '../views/MyProgramView.vue';
import CreateProgramView from '../views/CreateProgramView.vue';
import EditProgramView from '../views/EditProgramView.vue'
import EditionInfoView from '../views/EditionInfoView.vue';
import CreateEditionView from '../views/CreateEditionView.vue';
import UsersView from "@/views/UsersView.vue";
import NotFoundView from "@/views/NotFoundView.vue";
import EditNewsView from "@/views/EditNewsView.vue";
import AddNewsView from "@/views/AddNewsView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
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
      path: '/editioninfo/:id',
      name: 'EditionInfo',
      component: EditionInfoView,
    },
    {
      path: '/myProgram/:id/createEdition',
      name: 'CreateEdition',
      component: CreateEditionView,
    },
    {
      path: '/addNews',
      name: 'Add News',
      component: AddNewsView,
    },
    {
      path: '/editNews/:id',
      name: 'Edit news',
      component: EditNewsView,
    },
    {
      path: '/:pathMatch(.*)*',
      component: NotFoundView
    },
    {
      path: '/editProgram/:id',
      name: 'EditProgram',
      component: EditProgramView,
    }
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