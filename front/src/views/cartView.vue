<script setup>
import CartDetails from '@/components/cart/CartDetails.vue';
import CartProductCard from '@/components/cart/CartProductCard.vue';
import EmptyCart from '@/components/cart/EmptyCart.vue';
import { useCartStore } from '@/stores/cartStore';

const cartStore = useCartStore();
</script>

<template>

  <main>
    <div v-if="!cartStore.isEmpty" class="container mt-3" data-aos="fade-up" data-aos-duration="1000">
      <div class="row">
        <div class="col-md-8 mb-3  p-3">
          <h1 class="mb-3">Seu carrinho</h1>
          <div v-for="product in cartStore.cart" :key="product.id">
            <CartProductCard :product="product"/>
          </div>
        </div>
        <div class="col">
          <CartDetails/>
        </div>
      </div>
    </div>
    <EmptyCart v-else/>
  </main>
</template>

<style scoped>
main {
    min-height: 70vh;
}
</style>