import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { products } from '@/assets/products'
import CourierHome from '../views/Courier/CourierHome.vue'
import CourierAccount from '../views/Courier/CourierAccount.vue'
import { getAccountType, useAuthStore } from '@/stores/auth'
import { useCustomerStore } from '@/stores/customer'
import { useCartStore } from '@/stores/cart'


function courierGuard(to: any, from: any, next: any) {
  if (getAccountType() === 'courier') {
    next();
  } else {
    next('/');
  }
}

function redirect(to: any, from: any, next: any) {
  switch (getAccountType()) {
    case 'courier':
      next('/courier')
      break;
    case 'customer':
      next('/home')
      break;
    default:
      next('/login')
  }
}

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'default',
      beforeEnter: redirect,
      component: () => import('../views/Auth/LoginView.vue')
    },
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
      component: () => import('../views/Auth/CreateAccountView.vue')
    },
    {
      path: '/follow-command',
      name: 'follow-command',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/DeliveryFollowUpView.vue')
    },
    {
      path: '/follow-orders',
      name: 'follow-orders',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/OrdersFollowUpView.vue')
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
        if (id === null || id === undefined) {
          next({ path: '/error' })
          return
        }
        next()
      }
    },
    {
      path: '/edit-menu-products',
      name: 'edit-menu-products',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/EditMenuProducts.vue')
    },
    {
      path: '/edit-menu-products/menu/:id',
      name: 'edit-menu',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/EditMenu.vue'),
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
      path: '/edit-menu-products/starter/:id',
      name: 'edit-starter',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/EditProduct.vue'),
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
      name: 'login',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Auth/LoginView.vue')
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
      path: '/accountr',
      name: 'RestoratorAccount',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/RestoratorAccount.vue')
    },
    {
      path: '/purchase',
      name: 'Purchase',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/PaymentView.vue'),
      beforeEnter: (to, _, next) => {
        const cartStore = useCartStore();
        if(cartStore.cart.articles.length > 0) {
          const customerStore = useCustomerStore();
          customerStore.getCustomerAccount();
          next()
        } else {
          next({ path: '/' })
        }
      }
    },
    {
      path: '/courier',
      component: () => import('../views/Courier/Courier.vue'),
      beforeEnter: courierGuard,
      children: [
        {
          path: '/courier',
          name: 'courier',
          component: CourierHome,
          beforeEnter: courierGuard,
        },
        {
          path: '/courier/account',
          name: 'courierAccount',
          component: CourierAccount,
          beforeEnter: courierGuard,
        }
      ],
    }
  ]
});

export default router
