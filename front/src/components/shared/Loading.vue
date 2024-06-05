<template>
    <div class="blur"></div>
    <div class="position-fixed top-50 start-50 translate-middle z-index-loading">
        <div class="loader"></div>
    </div>
</template>

<style scoped>
.loader {
    border: 16px solid #f3f3f3;
    border-top: 16px solid #369D5D;
    border-radius: 50%;
    width: 120px;
    height: 120px;
    animation: spin 2s linear infinite;
}

.blur {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    z-index: 99995;
}

.z-index-loading {
    z-index: 99997;
}
</style>
