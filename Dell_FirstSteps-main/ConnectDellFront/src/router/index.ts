import {createRouter, createWebHistory} from 'vue-router'
import MyProgramView from "@/views/MyProgramView.vue";
import ProgramView from "@/views/ProgramView.vue";
import UsersView from "@/views/UsersView.vue";
import HomeView from "@/views/HomeView.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
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
        }, {
            path: '/users',
            name: 'Users',
            component: UsersView
        }

    ]
})

export default router
