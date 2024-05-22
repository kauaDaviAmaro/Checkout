<script setup>
import CatalogProductCard from '@/components/product/CatalogProductCard.vue';
defineProps({
    products: Array
});
</script>

<template>
    <div class="row row-cols-1 row-cols-sm-1 row-cols-md-3 g-4">
        <div class="col" v-for="product in products" :key="product.id">
            <CatalogProductCard :product="product" />
        </div>
    </div>
</template>