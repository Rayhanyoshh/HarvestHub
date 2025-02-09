import { createRouter, createWebHistory } from 'vue-router';
import UserLogin from '@/components/UserLogin.vue';
import CreateNewTask from '@/components/CreateNewTask.vue';
import Dashboard from "@/components/Dashboard.vue";
import ViewTask from "@/components/ViewTask.vue";
import ActionTask from "@/components/ActionTask.vue";
import CreateFarmField from "@/components/CreateFarmField.vue";
import ViewFarmField from "@/components/ViewFarmField.vue";

const routes = [
    {
        path: '/',
        name: 'dashboard',
        component: Dashboard
    },
    {
        path: '/login',
        name: 'UserLogin',
        component: UserLogin
    },
    {
        path: '/createnewTask',
        name: 'CreateNewTask',
        component: CreateNewTask
    },
    {
        path: '/view-task',
        name: 'View Task',
        component: ViewTask   },
    {
        path: '/action-task/:id',
        name: 'Action Task',
        component: ActionTask   },

    {
        path: '/create-farmfield',
        name: 'Create Farmfield',
        component: CreateFarmField   },
    {
        path: '/view-farmfield',
        name: 'View Farmfield',
        component: ViewFarmField   },

];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
});

export default router;
