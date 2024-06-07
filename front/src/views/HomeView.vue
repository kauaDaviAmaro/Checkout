<script setup>
import Testimonials from '@/components/general/Testimonials.vue';

</script>

<template>
    <main>
        <div class="hero container d-flex justify-content-center align-items-center">
            <h1 class="text-center " data-aos="fade-up" data-aos-duration="1000">
                Bem vindo a nosa loja! Aqui você consegue encontrar as melhores ofertas em eletrônicos e mais.
                <span class="text-primary">Barato como um smartphone Chinês</span> e <span
                    class="text-success">econômico</span>!
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