<script setup>
import { useProductsStore } from '@/stores/productStore';

const productsStore = useProductsStore();

</script>

<template>
    <nav class="d-flex justify-content-center" aria-label="Page navigation example">
        <ul class="pagination">
            <li class="page-item" :class="{ 'disabled': productsStore.currentPage === 1 }">
                <button class="page-link" @click="productsStore.setCurrentPage(productsStore.currentPage - 1)">
                    <i class='bx bx-chevron-left'></i>
                </button>
            </li>
            <li class="page-item number" v-for="page in productsStore.totalPages" :key="page"
                :class="{ 'active': productsStore.currentPage === page }">
                <button class="page-link" @click="productsStore.setCurrentPage(page)">{{ page }}</button>
            </li>
            <li class="page-item" :class="{ 'disabled': productsStore.currentPage === productsStore.totalPages }">
                <button class="page-link" @click="productsStore.setCurrentPage(productsStore.currentPage + 1)">
                    <i class='bx bx-chevron-right'></i>
                </button>
            </li>
        </ul>
    </nav>

</template>

<style scoped>
@media screen and (max-width: 768px) {
    .number:not(.active) {
        display: none;
    }
}
</style>