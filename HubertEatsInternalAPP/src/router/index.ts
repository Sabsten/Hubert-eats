import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'
import Technicien from '../views/TechView.vue'
import Commercial from '../views/CommercialView.vue'
import DevTiers from '../views/CommercialView.vue'
import { getRole } from '../stores/auth'

function devGuard(to: any, from: any, next: any) {
  const accountType = getRole();
  if (accountType === 'Developpeur') {
    next();
  } else {
    next();
  }
}
function commercialGuard(to: any, from: any, next: any) {
  const accountType = getRole();
  console.warn(from)
  if (accountType === 'Commercial') {
    console.warn('commercialGuard');
    next();
  } else {
    next();
  }
}
function techGuard(to: any, from: any, next: any) {
  const accountType = getRole();
  if (accountType === 'Technicien') {
    next();
  } else {
    next();
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
      beforeEnter: devGuard,
      component: DevTiers
      
    },
    {
      path: '/commercial',
      name: 'commercial',
      beforeEnter: commercialGuard,
      component: Commercial
    }
    {
      path: '/tech',
      name: 'tech',
      beforeEnter: techGuard,
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/TechView.vue')
    },
  ]
})



export default router
