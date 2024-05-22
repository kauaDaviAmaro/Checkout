<script setup>
import { useProductsStore } from '@/stores/products';
import { formatPrice } from '@/assets/js/helpers';
import { onMounted, ref } from 'vue';

const productsStore = useProductsStore();

const addProduct = (product) => {
    productsStore.addProductQuantity(product);
}

const removeProduct = (product) => {
    productsStore.decreaseProductQuantity(product);
}


defineProps({
    product: Object
})
</script>

<template>
    <div class="card mb-3 bg-transparent border-0">
        <div class="row g-0">
            <div class="col-md-4">
                <img :src="product.thumbnail" :alt="product.title" class="img-fluid rounded">
            </div>
            <div class="col-md-8">
                <div class="card-body d-flex justify-content-between h-100">
                    <div class="card-title d-flex justify-content-between align-items-center fs-4">
                        <div class="title">
                            {{ product.title }}
                        </div>
                        <div class="price">
                            {{ formatPrice(product.price) }}
                        </div>
                    </div>
                    <span class="badge text-bg-success" style="max-width: fit-content;">
                        {{ product.stock }} in stock
                    </span>

                    <div class="card-text d-flex justify-content-between align-items-center mt-2">
                        <div class="remove">
                            <button @click="productsStore.removeFromCart(product)" class="btn btn-outline-danger">
                                <i class="bx bx-trash"></i>
                            </button>
                        </div>
                        <div class="btn-group" role="group">
                            <button @click="removeProduct(product)" class="btn border">-</button>
                            <button type="button" class="btn border-top border-bottom">
                                {{ product.quantity ? product.quantity : 1 }}
                            </button>
                            <button @click="addProduct(product)" :disabled="product.stock === product.quantity"
                                class="btn border">+</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
.total {
    width: 30px;
}

.img-fluid {
    width: 100%;
    max-height: 200px;
    object-fit: cover;
}

.card-body {
    flex-direction: column;
}
</style>