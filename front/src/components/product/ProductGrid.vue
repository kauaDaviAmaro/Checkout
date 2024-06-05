<script setup>
import ProductCard from '@/components/product/ProductCard.vue';
import { useProductsStore } from '@/stores/productStore';

const productStore = useProductsStore();
const products = productStore.products;

</script>

<template>
    <div class="row row-cols-1 row-cols-sm-1 row-cols-md-3 g-4">
        <div class="col" v-for="product in products" :key="product.id">
            <ProductCard :product="product" />
        </div>
    </div>
</template>