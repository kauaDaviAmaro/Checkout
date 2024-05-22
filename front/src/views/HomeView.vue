<script setup>
import Testimonials from '@/components/general/Testimonials.vue';
</script>

<template>
    <main>
        <div class="hero container d-flex justify-content-center align-items-center">
            <h1 class="text-center " data-aos="fade-up" data-aos-duration="1000">
                Welcome to our online store! Here you can find the best deals on electronics and more.
                <span class="text-primary">Cheap as a chinese smartphone</span> and <span
                    class="text-success">affordable</span>!
            </h1>
        </div>

        <Testimonials data-aos="fade-up" data-aos-duration="1000" />
    </main>
</template>


<style scoped>
.hero {
    height: 60vh;
}

.text-success {
    text-shadow: 1px 1px 20px #369D5D;
}

.text-primary {
    text-shadow: 1px 1px 20px #0D6EFD;
}
</style>