<script setup>
import { useProductsStore } from '@/stores/products';
import { formatPrice, isInCart, isDarkMode } from '@/assets/js/helpers';

const productsStore = useProductsStore();

defineProps({
    product: Object
});
</script>

<template>
    <RouterLink :to="`/product/${product.id}`" class="text-decoration-none">
        <div class="card position-relative h-100 bg-light border-0">
            <img :src="product.thumbnail" :alt="product.title" class="card-img-top ">
            <div class="card-body" :data-bs-theme="isDarkMode ? 'dark' : 'light'">
                <div class="text">
                    <h5 class="card-title">
                        {{ product.title }}
                    </h5>
                    <p class="card-text">
                        {{ product.description }}
                    </p>
                </div>
                <div class="card-footer bg-transparent border-0 d-flex justify-content-between align-items-center p-0">
                    <div class="price">
                        {{ formatPrice(product.price) }}
                    </div>
                    <!-- <button
                    @click="isInCart(product) ? productsStore.removeFromCart(product) : productsStore.addToCart(product)"
                    :class="isInCart(product) ? 'btn-danger' : 'btn-primary'" 
                    class="btn btn-primary position-absolute top-0 end-0 m-3">
                    {{ isInCart(product) ? 'Remove from cart' : 'Add to cart' }}
                </button> -->
                </div>
            </div>
        </div>
    </RouterLink>
</template>

<style scoped>
.card-img-top {
    height: 200px;
    object-fit: cover;
}

.card {
    &:hover {
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
        
        & .card-title, & .card-text {
            color: #198754;
        }
    }

    & .price {
        font-weight: bold;
        font-size: 1.2rem;
    }

    & .text {
        min-height: 135px;
    }
}
</style>
