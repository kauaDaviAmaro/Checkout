<script setup>
import OrderBy from '@/components/OrderBy.vue'
</script>

<template>
    <aside class="filter mx-4">
        <div class="orderby d-none">
            <h3>Order By</h3>
            <OrderBy class="mb-4" />
        </div>

        <div class="price mb-4">
            <h3>Price</h3>
            <div class="d-flex align-items-center">
                <input type="number" class="form-control" placeholder="Min">
                <span class="mx-2">-</span>
                <input type="number" class="form-control" placeholder="Max">
            </div>
        </div>

        <div class="categories mb-4">
            <h3>Categories</h3>
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault1">
                <label class="form-check-label" for="flexCheckDefault1">Category 1</label>
            </div>
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault2">
                <label class="form-check-label" for="flexCheckDefault2">Category 2</label>
            </div>
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault3">
                <label class="form-check-label" for="flexCheckDefault3">Category 3</label>
            </div>
        </div>

        <div class="rating mb-4">
            <h3>Rating</h3>
            
        </div>

        <div class="brand">
            <h3>Brand</h3>

        </div>
    </aside>
</template>

<style scoped>
aside {
    width: 300px;
}

@media screen and (max-width: 768px) {
    aside {
        display: none;
    }

    .show {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5);
        z-index: 9999;
    }
}
</style>