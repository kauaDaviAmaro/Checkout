<script setup>
import { useProductsStore } from '@/stores/products';
import { useRouter } from "vue-router";
import { shoppingCart } from '@/assets/js/helpers';
import { onMounted } from 'vue';

const productsStore = useProductsStore();
const router = useRouter();

onMounted(() => {
    // productsStore.deleteCart();
})
</script>

<template>
    <div class="container text-center mt-5">
        <div class="row">
            <div class="col">
                <h1>
                    Thank you for shopping!!!
                </h1>
            </div>
        </div>
        <div class="row border-bottom">
            <div class="col">
                <p class="mt-5">
                    Your order has been successfully placed. You can check your order status in your account or go
                    back to the home page.
                </p>
            </div>
        </div>
        <div class="row fs-5 my-3">
            <div class="col">
                <div>
                    Order number
                </div>
                #1234
            </div>
            <div class="col">
                <div>
                    Date
                </div>
                12.12.2022
            </div>
            <div class="col">
                <div>
                    Status
                </div>
                <span class="badge bg-primary">Processing</span>
            </div>
            <div class="col">
                <div>
                    Payment method
                </div>
                Cash
            </div>
        </div>
        <div class="row">
            <div class="col">
                <ProductList :products="shoppingCart"/>
            </div>
        </div>
    </div>
</template>