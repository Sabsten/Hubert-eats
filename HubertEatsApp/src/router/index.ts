import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { products } from '@/assets/products'

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
    }
  ]
})

export default router
