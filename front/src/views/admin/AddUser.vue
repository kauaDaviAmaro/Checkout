<script setup>
import userDataService from '@/service/userDataService';
import { useAlertStore } from '@/stores/alert';
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();

const alert = useAlertStore();

const loading = ref(false);

const user = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    cpf: '',
    phone: '',
}

const submit = async () => {
    loading.value = true;
    await userDataService.register(user);
    loading.value = false;
    alert.successAlert('Usuário criado com sucesso!');
    router.push('/admin/users');
}
</script>

<template>
    <Loading v-if="loading" />
    <main v-else class="container w-100 m-2" data-aos="fade-up" data-aos-duration="1000">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item ">
                    <RouterLink to="/admin">Dashboard</RouterLink>
                </li>
                <li class="breadcrumb-item active" aria-current="page">Usuários</li>
            </ol>
        </nav>
        <div class="table-container bg-white border p-3 rounded">
            <div class="table-header d-flex justify-content-between align-items-center m-3">
                <div class="title">
                    <h2 class="fs-4 fw-bold">Adicionar Usuário</h2>
                </div>
            </div>
            <div class="table-responsive">
                <form @submit.prevent="submit">
                    <div class="form-group mb-3">
                        <label for="firstName">Nome</label>
                        <input type="text" class="form-control" id="firstName" name="firstName" required placeholder="Insira seu primeiro nome" v-model="user.firstName">
                    </div>
                    <div class="form-group mb-3">
                        <label for="lastName">Último nome</label>
                        <input type="text" class="form-control" id="lastName" name="lastName" required placeholder="Insira seu último nome" v-model="user.lastName">
                    </div>
                    <div class="form-group mb-3">
                        <label for="email">Email</label>
                        <input type="email" class="form-control" id="email" name="email" required placeholder="Insira seu email" v-model="user.email">
                    </div>
                    <div class="form-group mb-3">
                        <label for="password">Senha</label>
                        <input type="password" class="form-control" id="password" name="password" required placeholder="Insira sua senha" v-model="user.password">
                    </div>
                    <div class="form-group mb-3">
                        <label for="cpf">CPF</label>
                        <input type="text" class="form-control" id="cpf" name="cpf" required placeholder="Insira seu CPF" v-model="user.cpf">
                    </div>
                    <div class="form-group mb-3">
                        <label for="phone">Telefone</label>
                        <input type="text" class="form-control" id="phone" name="phone" required placeholder="Insira seu telefone" v-model="user.phone">
                    </div>
                    <button type="submit" class="btn btn-primary float-end mt-3">Adicionar</button>
                </form>
            </div>
        </div>
    </main>
</template>