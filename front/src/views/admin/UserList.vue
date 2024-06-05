<script setup>
import { onMounted, ref } from 'vue';
import userDataService from '@/service/userDataService';
import Loading from '@/components/shared/Loading.vue';

const users = ref({});
const data = ref({});

const hideCpf = (cpf) => {
    if (!cpf) {
        return null
    }
    const lastTreeDigits = cpf.slice(-3);
    return `***.***.***${lastTreeDigits}`
}

const loading = ref(false);
onMounted(async () => {
    loading.value = true;
    data.value = await userDataService.getUsers();
    users.value = data.value.users;
    loading.value = false
});
</script>

<template>
    <Loading v-if="loading" />
    <main class="container w-100 m-2">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item "><RouterLink to="/admin">Dashboard</RouterLink></li>
                <li class="breadcrumb-item active" aria-current="page">Usuários</li>
            </ol>
        </nav>
        <div class="table-container bg-white border p-3 rounded  w-100">
            <div class="table-header d-flex justify-content-between align-items-center m-3">
                <div class="title">
                    <h2 class="fs-4 fw-bold">Lista de usuários</h2>
                </div>
                <button class="btn btn-success">
                    <i class="bx bx-plus"></i> Adicionar
                </button>
            </div>
            <div class="table-responsive  w-100">
                <table class="table table-borderless bg-white table-hover w-100">
                    <thead>
                        <tr class="border-bottom">
                            <th scope="col"
                                v-for="column in ['#', 'Nome', 'Sobrenome', 'CPF', 'Email', 'Telefone', 'Ações']">
                                {{ column }}
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="align-middle" v-for="user in users">
                            <th scope="row">
                                {{ user.id }}
                            </th>
                            <td>
                                {{ user.firstName }}
                            </td>
                            <td>
                                {{ user.lastName }}
                            </td>
                            <td :class="user.cpf ?? 'text-danger'">
                                {{ hideCpf(user.cpf) ?? 'Não informado' }}
                            </td>
                            <td>
                                {{ user.email }}
                            </td>
                            <td :class="user.phone ?? 'text-danger'">
                                {{ user.phone ?? 'Não informado' }}
                            </td>
                            <td class="text-center">
                                <button class="btn fs-4" @click="userDataService.deleteUser(user.id)">
                                    <i class='bx bx-trash text-danger'></i>
                                </button>
                                <button class="btn fs-4" @click="userDataService.editUser(user)">
                                    <i class='bx bx-edit text-primary'></i>
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </main>
</template>
