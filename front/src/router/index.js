import { createRouter, createWebHistory } from 'vue-router';
import ProductsView from '@/views/ProductsView.vue';
import HomeView from '@/views/HomeView.vue';
import ShoppingCartView from '@/views/ShoppingCartView.vue';
import CheckoutView from '@/views/CheckoutView.vue';
import SuccessView from '@/views/SuccessView.vue';
import LoginView from '@/views/LoginView.vue';
import ContactView from '@/views/ContactView.vue';
import AboutView from '@/views/AboutView.vue';
import RegisterView from '@/views/RegisterView.vue';
import ProductDetailsView from '@/views/ProductDetailsView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  scrollBehavior: (to, from, savedPosition) => {
    if (savedPosition) {
      return savedPosition
    } else {
      return { top: 0 }
    }
  },
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/products/:search?',
      name: 'product',
      component: ProductsView
    },
    {
      path: '/cart',
      name: 'cart',
      component: ShoppingCartView
    },
    {
      path: '/checkout',
      name: 'checkout',
      component: CheckoutView
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
    {
      path: '/register',
      name: 'register',
      component: RegisterView
    },
    {
      path: '/success',
      name: 'success',
      component: SuccessView
    },
    {
      path: '/contact',
      name: 'contact',
      component: ContactView
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView
    },
    {
      path: '/product/:id',
      name: 'product-details',
      component: ProductDetailsView
    }
  ]
})

export default router
