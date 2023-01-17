import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'
import Technicien from '../views/techView.vue'
import Commercial from '../views/CommercialView.vue'
import DevTiers from '../views/CommercialView.vue'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: LoginView
    },
    {
      path: '/tech',
      name: 'tech',
      component: Technicien
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
    }
  ]
})

export default router
