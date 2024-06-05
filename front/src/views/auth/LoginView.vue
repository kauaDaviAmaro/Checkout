<script setup>
import { ref } from 'vue';
import { RouterLink } from 'vue-router';
import { useAuthStore } from '@/stores/auth';
import Loading from '@/components/shared/Loading.vue';

const loading = ref(false);

const onSubmit = async (values) => {
    loading.value = true;
    const authStore = useAuthStore();
    await authStore.login(values);
    loading.value = false;
}
</script>

<template>
    <Loading v-if="loading" />
    <div class="container d-flex flex-column justify-content-center" data-aos="fade-up" data-aos-duration="1000">
        <div class="title text-center mb-3">
            <h1>Faça o login de sua conta:</h1>
        </div>
        <form @submit.prevent="onSubmit" novalidate>
            <div class="row">
                <div class="col mb-3">
                    <label for="email" class="form-label">Email:</label>
                    <input type="email" name="email" class="form-control" required placeholder="Insira seu email">
                    <div class="invalid-feedback">
                        Por favor, proporcione um email válido.
                    </div>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="password" class="form-label">Senha:</label>
                    <input type="password" name="password" class="form-control" required
                        placeholder="Insira sua senha">
                    <div class="invalid-feedback">
                        Por favor, proporcione um email válido.
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <button type="submit" class="btn w-100">Login</button>
                </div>
            </div>
            <div class="row mt-3">
                <p>Não possui uma conta ainda? <RouterLink to="/register">Cadastre-se</RouterLink>
                </p>
            </div>
        </form>
    </div>
</template>

<style scoped>
.container {
    min-height: 60vh;
    max-width: 400px;
}

.btn {
    background: linear-gradient(to right, #369D5D, #2F9AAA);

}
</style>