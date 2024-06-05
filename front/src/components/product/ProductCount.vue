<script setup>
import { useProductsStore } from '@/stores/productStore';

const productStore = useProductsStore();
</script>

<template>
    <div>Mostrando {{ productStore.products.length }} de {{ productStore.totalProducts }} produtos</div>
</template>