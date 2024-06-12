import AboutView from '@/views/AboutView.vue';
import ContactView from '@/views/ContactView.vue';
import HomeView from '@/views/HomeView.vue';
import SuccessView from '@/views/SuccessView.vue';
import LoginView from '@/views/auth/LoginView.vue';
import ProfileView from '@/views/auth/ProfileView.vue';
import RegisterView from '@/views/auth/RegisterView.vue';
import CartView from '@/views/cartView.vue';
import ProductDetailsView from '@/views/product/ProductDetailsView.vue';
import ProductsView from '@/views/product/ProductsView.vue';
import UserList from '@/views/admin/UserList.vue';
import AdminLayout from '@/components/admin/AdminLayout.vue';
import PublicLayout from '@/components/PublicLayout.vue';
import CheckoutView from '@/views/CheckoutView.vue';
import Dashboard from '@/views/admin/Dashboard.vue';
import OrderList from '@/views/admin/OrderList.vue';
import ProductList from '@/views/admin/ProductList.vue';
import OrdersView from '@/views/auth/OrdersView.vue';

import { createRouter, createWebHistory } from 'vue-router';

const routes = [
  {
    path: '/admin/',
    component: AdminLayout,
    children: [
      { path: 'dashboard', name: 'dashboard', component: Dashboard },
      { path: 'users', name: 'admin-users', component: UserList },
      { path: 'orders', name: 'admin-orders', component: OrderList },
      { path: 'products', name: 'admin-products', component: ProductList },
    ]
  },
  {
    path: '/',
    component: PublicLayout,
    children: [
      { path: '/', name: 'home', component: HomeView },
      { path: '/products', name: 'product', component: ProductsView },
      { path: '/cart', name: 'cart', component: CartView },
      { path: '/checkout', name: 'checkout', component: CheckoutView },
      { path: '/login', name: 'login', component: LoginView },
      { path: '/profile', name: 'profile', component: ProfileView },
      { path: '/register', name: 'register', component: RegisterView },
      { path: '/success', name: 'success', component: SuccessView },
      { path: '/contact', name: 'contact', component: ContactView },
      { path: '/about', name: 'about', component: AboutView },
      { path: '/product/:id', name: 'product-details', component: ProductDetailsView },
      { path: '/orders', name: 'order', component: OrdersView },
    ]
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  scrollBehavior: (to, from, savedPosition) => {
    if (savedPosition) {
      return savedPosition
    }
    return { top: 0 }
  },
  routes
});

export default router;
