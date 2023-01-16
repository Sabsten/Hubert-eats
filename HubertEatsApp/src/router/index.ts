import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/Customer/HomeView.vue'
import { products } from '@/assets/products'
import CourierHome from '../views/Courier/CourierHome.vue'
import CourierAccount from '../views/Courier/CourierAccount.vue'
import { getAccountType, useAuthStore } from '@/stores/auth'
import { useCustomerStore } from '@/stores/customer'
import { useCartStore } from '@/stores/cart'
import CustomerAccountVue from '../views/Customer/CustomerAccount.vue'


function courierGuard(to: any, from: any, next: any) {
  if (getAccountType() === 'courier') {
    next();
  } else {
    next('/');
  }
}
function customerGuard(to: any, from: any, next: any) {
  if (getAccountType() === 'customer') {
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
      next('/customer')
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
      path: '/login',
      name: 'login',
      component: () => import('../views/Auth/LoginView.vue')
    },
    {
      path: '/signup',
      name: 'signup',
      component: () => import('../views/Auth/CreateAccountView.vue')
    },
    /******************* CUSTOMER ROUTER ****************/
    {
      path: '/customer',
      component: () => import('../views/Customer/Customer.vue'),
      beforeEnter: customerGuard,
      children: [
        {
          path: '',
          name: 'customer-home',
          component: HomeView,
          beforeEnter: customerGuard,
        },
        {
          path: 'account',
          name: 'customer-account',
          component: CustomerAccountVue,
          beforeEnter: customerGuard,
        },
        {
          path: 'restaurant-selection/:id',
          name: 'restaurant-selection',
          component: () => import('../views/Customer/RestaurantView.vue'),
          beforeEnter: customerGuard,
        },
        {
          path: 'payment',
          name: 'customer-payment',
          component: () => import('../views/Customer/PaymentView.vue'),
          beforeEnter: (to, from, next) => {
            const cartStore = useCartStore();
            if(cartStore.cart.articles.length > 0) {
              const customerStore = useCustomerStore();
              customerStore.getCustomerAccount();
              customerGuard(to, from, next);
            } else {
              next({ path: '/' })
            }
          },
        }
      ],
    },
    {
      path: '/follow-command',
      name: 'follow-command',
      component: () => import('../views/DeliveryFollowUpView.vue')
    },
    {
      path: '/follow-orders',
      name: 'follow-orders',
      component: () => import('../views/OrdersFollowUpView.vue')
    },
    {
      path: '/edit-menu-products',
      name: 'edit-menu-products',
      component: () => import('../views/EditMenuProducts.vue')
    },
    {
      path: '/edit-menu-products/menu/:id',
      name: 'edit-menu',
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
      path: '/accountr',
      name: 'RestoratorAccount',
      component: () => import('../views/RestoratorAccount.vue')
    },
    /******************* COURIER ROUTER ****************/
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
