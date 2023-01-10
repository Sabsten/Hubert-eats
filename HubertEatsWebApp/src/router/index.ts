// This file is used to define the routes of the application

import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import { facts } from '@/assets/facts'
import HomePage from '@/views/HomePage.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'Home',
    component: HomePage
  },
  {
    path: '/fact/:id',
    name: 'Fact',
    component: () => import('../views/FactElement.vue'),
    meta:{
      enterClass: "animate__animated animate__fadeInRight",
      leaveClass: "animate__animated animate__fadeOutLeft"
    },
    // This function is called before the route is entered
    beforeEnter: (to, _, next) => {
      const { id } = to.params

      if (Array.isArray(id)) {
        next({ path: '/error' })
        return
      }

      // Is a valid index number
      const index = parseInt(id)
      if (index < 0 || index >= facts.length) {
        next({ path: '/error' })
        return
      }

      next()
    }
  },
  {
    path: '/facts',
    name: 'FactList',
    component: () => import('../views/FactList.vue')
  },
  {
    path: '/basket',
    name: 'BasketPage',
    component: () => import('../views/BasketPage.vue')
  },
  {
    path: '/my-orders',
    name: 'My orders',
    component: () => import('../views/MyOrdersList.vue')
  },
  {
    path: '/profile',
    name: 'My profile',
    component: () => import('../views/ProfilePage.vue')
  },
  {
    // This route is used to handle errors: no page found
    path: '/:catchAll(.*)',
    name: 'PageNotFound',
    component: () => import('../views/PageNotFound.vue')
  }
]

// Create a router instance
const router = createRouter({
  // Use the browser's history API HTML5 history mode
  history: createWebHistory(),
  routes
})

export default router
