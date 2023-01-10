import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Courier from '../views/Courier/Courier.vue'
import CourierHome from '../views/Courier/CourierHome.vue'
import CourierAccount from '../views/Courier/CourierAccount.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/profile',
      name: 'profile',
      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/basket',
      name: 'basket',
      component: () => import('../views/HomeView.vue')
    },
    {
      path: '/facts',
      name: 'facts',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/CreateAccountView.vue')
    },
    {
      path: '/livreurs',
      component: () => import('../views/Courier/Courier.vue'),
      children: [
        {
          path: '/livreurs/accueil',
          name: 'accueil',
          component: CourierHome
        },
        {
          path: '/livreurs/compte',
          name: 'compte',
          component: CourierAccount
        }
      ],
    }
  ]
});

export default router
