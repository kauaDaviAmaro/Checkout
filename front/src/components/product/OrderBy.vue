<script setup>
import { useProductsStore } from '@/stores/productStore';

const productsStore = useProductsStore();
</script>

<template>
    <div>
        <select name="sort" class="form-select" @change="productsStore.sortBy($event.target.value)">
            <option selected disabled>Ordernar por</option>
            <option value="id" >Padrão</option>
            <option value="title">Nome</option>
            <option value="rating">Melhor avaliação</option>
            <option value="highestPrice">Maior preço</option>
            <option value="lowestPrice">Menor preço</option>
        </select>
    </div>
</template>