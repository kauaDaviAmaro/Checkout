<script setup>
import { formatPrice } from '@/assets/js/helpers';
import { useCartStore } from '@/stores/cartStore';

const cart = useCartStore();
</script>

<template>
    <h2 class="fw-bold">Resumo do pedido</h2>
    <div v-for="product in cart.cart" :key="product.id" class="d-flex justify-content-between mb-2">
        <span class="tittle fw-bold">
            {{ product.title }}
        </span>
        <span>{{ formatPrice(product.price) }} x {{ product.quantity ?? 1 }}</span>
    </div>
    <div class="subtotal border-top d-flex justify-content-between fw-bold pt-2">
        Subtotal: <span>{{ formatPrice(cart.total) }}</span>
    </div>
</template>