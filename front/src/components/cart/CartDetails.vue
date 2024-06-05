<script setup>
import { useRouter } from "vue-router";
import { formatPrice } from '@/assets/js/helpers';
import { useAuthStore } from "@/stores/auth";
import { useCartStore } from "@/stores/cartStore";
const router = useRouter();

const auth = useAuthStore();

const cartStore = useCartStore();
</script>

<template>
    <div class="mb-3">
        <div class="promoCode">
            <div class="input-group">
                <input type="text" class="form-control" placeholder="Promo code">
                <button class="btn btn-outline-secondary">Confirmar</button>
            </div>
        </div>
        <div class="text p-2 mt-2">
            <div class="quantity d-flex justify-content-between">
                Quantidade de itens <span>{{ cartStore.totalQuantity }}</span>
            </div>
            <div class="total d-flex justify-content-between w-100">
                Preço total <span>{{ formatPrice(cartStore.total) }}</span>
            </div>
        </div>
        <div class="buttons d-flex flex-column mt-2">
            <button class="btn btn-primary mb-2"
                @click="auth.isAuthenticated ? router.push('/checkout') : router.push('/login')">Checkout</button>
            <button class="btn btn-secondary" @click="router.push('/products')">Continuar comprando</button>
        </div>
    </div>
</template>