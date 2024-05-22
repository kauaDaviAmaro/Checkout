<script setup>
import { useRouter } from "vue-router";

const router = useRouter();
</script>

<template>
    <div class="msg text-center d-flex flex-column justify-content-center align-items-center" data-aos="fade-up"
        data-aos-duration="1000">
        <h1>Opss! Looks like your cart is empty</h1>
        <button class="btn btn-primary mt-3" @click="router.push('/products')">
            back to shopping <i class="bx bx-arrow-back"></i>
        </button>
    </div>
</template>

<style scoped>
.msg {
    min-height: 60vh;
}
</style>