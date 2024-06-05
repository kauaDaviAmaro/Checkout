<script setup>
import { ref } from 'vue';
import { useAuthStore } from '@/stores/auth';
import Loading from '@/components/shared/Loading.vue';

const loading = ref(false);

const onSubmit = async (values) => {
    loading.value = true;
    const authStore = useAuthStore();
    await authStore.register(values);
    loading.value = false;
}

const password = ref('');
const confirmPassword = ref('');
</script>

<template>
    <Loading v-if="loading" />
    <div class="container d-flex flex-column justify-content-center" data-aos="fade-up" data-aos-duration="1000">
        <div class="title text-center mb-3">
            <h1>Cadastre-se aqui:</h1>
        </div>
        <form @submit.prevent="onSubmit" novalidate>
            <div class="row">
                <div class="col-md-6 col-sm-12 mb-3">
                    <label for="firstName" class="form-label">Nome:</label>
                    <input type="text" name="firstName" class="form-control" required placeholder="Insira seu primeiro nome">
                    <div class="invalid-feedback">
                        Por favor, proporcione um primeiro nome válido.
                    </div>
                </div>
                <div class="col-md-6 col-sm-12 mb-3">
                    <label for="lastName" class="form-label">Último nome:</label>
                    <input type="text" name="lastName" class="form-control" required placeholder="Insira seu último nome">
                    <div class="invalid-feedback">
                        Por favor, proporcione um último nome válido
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col mb-3">
                    <label for="email" class="form-label">Email:</label>
                    <input type="email" name="email" class="form-control" required placeholder="Insira seu email">
                    <div class="invalid-feedback" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$">
                        Por favor, proporcione um email válido.
                    </div>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col mb-3">
                    <label for="password" class="form-label">Senha:</label>
                    <input type="password" name="password" class="form-control" required v-model="password"
                        placeholder="Insira sua senha" 
                        pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$">
                    <div class="invalid-feedback">
                        Deve possuir ao menos 8 caracteres, sendo um número, uma letra maiúscula e uma letra minúscula.
                    </div>
                </div>
                <div class="col-md-6 col-sm-12">
                    <label for="confirmPassword" class="form-label">Corfime sua senha:</label>
                    <input type="password" name="confirmPassword" class="form-control" required
                        v-model="confirmPassword" placeholder="Confirme sua senha" :class="{
                            'is-invalid': password !== confirmPassword
                        }"
                        pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$">
                    <div class="invalid-feedback">
                        Deve ser a mesma senha. 
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <button type="submit" class="btn w-100" :disabled="password !== confirmPassword">Cadastre-se</button>
                </div>
            </div>
        </form>
    </div>
</template>

<style scoped>
.container {
    min-height: 60vh;
    max-width: 500px;
}

.btn {
    background: linear-gradient(to right, #369D5D, #2F9AAA);
}
</style>