<script setup>
defineProps({
    review: Object
})
</script>

<template>
    <div class="card m-2 rounded">
        <div class="card-body position-relative">
            <h5 class="card-title">
                <i class="bx bxs-star" v-for="star in review.rating" :key="star"></i>
            </h5>
            <p class="card-text">
                <i class="bx bxs-quote-alt-left translate-middle-y"></i> {{ review.review }} <i
                    class="bx bxs-quote-alt-right translate-middle-y"></i>
            </p>
            <p class="card-text position-absolute bottom-0 mb-4">
                <small class="text-muted fs-5 fw-bold">
                    {{ review.name }}
                </small>
            </p>
        </div>
    </div>
</template>

<style scoped>
.card {
    border: 1px solid #369D5D;
    height: 15rem;
}

.bxs-star,
.text-muted {
    background: linear-gradient(to right, #369D5D, #2F9AAA);
    background-clip: border-box;
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    text-shadow: 1px 1px 5px #369D5D;
}
</style>