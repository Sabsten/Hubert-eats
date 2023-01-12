import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { products } from '@/assets/products'
import Courier from '../views/Courier/Courier.vue'
import CourierHome from '../views/Courier/CourierHome.vue'
import CourierAccount from '../views/Courier/CourierAccount.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/home',
      name: 'home',
      component: HomeView
    },
    {
      path: '/signup',
      name: 'signup',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/CreateAccountView.vue')
    },
    {
      path: '/tests',
      name: 'tests',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/HelloWorld.vue')
    },
    {
      path: '/restaurantPage/:id',
      name: 'restaurantPage',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/RestaurantView.vue'),
      beforeEnter: (to, _, next) => {
        const { id } = to.params
  
        if (Array.isArray(id)) {
          next({ path: '/error' })
          return
        }
  
        // Is a valid index number
        const index = parseInt(id)
        if (index < 0 || index >= products.length) {
          next({ path: '/error' })
          return
        }
  
        next()
      }
    },
    {
      path: '/login',
      name: 'LoginView',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/accountc',
      name: 'CustomerAccount',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/CustomerAccount.vue')
    },
    {
      path: '/purchase',
      name: 'Purchase',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/PaymentView.vue')
    },
    {
      path: '/livreur',
      component: () => import('../views/Courier/Courier.vue'),
      children: [
        {
          path: '/livreur',
          name: 'accueil',
          component: CourierHome
        },
        {
          path: '/livreur/compte',
          name: 'compte',
          component: CourierAccount
        }
      ],
    }
  ]
});

export default router
