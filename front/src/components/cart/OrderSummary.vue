<script setup>
import { formatPrice, total } from '@/assets/js/helpers';
import { useProductsStore } from '@/stores/products';

const shoppingCart = useProductsStore().shoppingCart;
</script>

<template>
    <h2 class="fw-bold">Order summary</h2>
    <div v-for="product in shoppingCart" :key="product.id" class="d-flex justify-content-between">
        <span class="tittle fw-bold">
            {{ product.title }}
        </span>
        <span>{{ formatPrice(product.price) }} x {{ product.quantity ?? 1 }}</span>
    </div>
    <div class="subtotal border-top d-flex justify-content-between fw-bold">
        Subtotal: <span>{{ formatPrice(total) }}</span>
    </div>
</template>