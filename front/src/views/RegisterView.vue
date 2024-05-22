<script setup>
import { ref } from 'vue';
import { useAuthStore } from '@/stores/auth';
import Loading from '@/components/Loading.vue';

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
            <h1>Register a new account</h1>
        </div>
        <form @submit.prevent="onSubmit" novalidate>
            <div class="row">
                <div class="col mb-3">
                    <label for="name" class="form-label">Name:</label>
                    <input type="text" name="name" class="form-control" required placeholder="Insert your name">
                    <div class="invalid-feedback">
                        Please provide a valid name.
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col mb-3">
                    <label for="email" class="form-label">Email:</label>
                    <input type="email" name="email" class="form-control" required placeholder="Insert your email">
                    <div class="invalid-feedback" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$">
                        Please provide a valid email.
                    </div>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col mb-3">
                    <label for="password" class="form-label">Password:</label>
                    <input type="password" name="password" class="form-control" required v-model="password"
                        placeholder="Insert your password" 
                        pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$">
                    <div class="invalid-feedback">
                        At least one number and one uppercase and lowercase letter, and at least 8 or more characters
                    </div>
                </div>
                <div class="col-md-6 col-sm-12">
                    <label for="confirmPassword" class="form-label">Confirm password:</label>
                    <input type="password" name="confirmPassword" class="form-control" required
                        v-model="confirmPassword" placeholder="Confirm your password" :class="{
                            'is-invalid': password !== confirmPassword
                        }"
                        pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$">
                    <div class="invalid-feedback">
                        must be the same as the password
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <button type="submit" class="btn w-100" :disabled="password !== confirmPassword">Register</button>
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