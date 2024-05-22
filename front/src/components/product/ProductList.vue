<script setup>
defineProps({
    products: Array
})
</script>

<template>
    <div v-if="products.length > 0">
        <div v-for="product in products" :key="product.id">
            <ProductCard :product="product"/>
        </div>
    </div>
    <div v-else>
        No products found
    </div>
</template>