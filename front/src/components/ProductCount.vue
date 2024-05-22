<script setup>
defineProps({
    search: String,
    filteredProductsCount: Number,
    productsCount: Number
})
</script>

<template>
    <div>Showing {{ filteredProductsCount }} of {{ productsCount }} products</div>
</template>