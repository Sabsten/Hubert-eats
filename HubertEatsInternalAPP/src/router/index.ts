import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'
import Commercial from '../views/CommercialView.vue'
import DevTiers from '../views/CommercialView.vue'
import { getRole } from '../stores/auth'



function redirect(to: any, from: any, next: any) {
  switch ( getRole()) {
    case 'Developpeur':
      next('/dev')
    case 'Commercial':
      next('/commercial')
    case 'Technicien':
      next('/tech')
    default:
      next('/')
  }
}

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: LoginView
    },
    {
      path: '/dev',
      name: 'dev',
      component: DevTiers
      
    },
    {
      path: '/commercial',
      name: 'commercial',
      component: Commercial
    },
    {
      path: '/tech',
      name: 'tech',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/TechView.vue')
    },
  ]
})



export default router
