<script setup>
import { onMounted, ref } from 'vue';
import { formatPrice } from '@/assets/js/helpers';
import Loading from '@/components/shared/Loading.vue';
import http from '@/service/http';

const messages = ref({});
const data = ref({});

const loading = ref(false);
onMounted(async () => {
    loading.value = true;
    data.value = await http.get("/message");;
    messages.value = data.value.data;
    loading.value = false
    console.log(messages.value);
});
</script>
<template>
    <Loading v-if="loading" />
    <main class="container w-100 m-2">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item ">
                    <RouterLink to="/admin">Dashboard</RouterLink>
                </li>
                <li class="breadcrumb-item active" aria-current="page">Mensagens</li>
            </ol>
        </nav>
        <div class="table-container bg-white border p-3 rounded">
            <div class="table-header d-flex justify-content-between align-items-center m-3">
                <div class="title">
                    <h2 class="fs-4 fw-bold">Lista de Mensagens</h2>
                </div>
                <button class="btn btn-success">
                    <i class="bx bx-plus"></i> Adicionar
                </button>
            </div>
            <div class="table-responsive">
                <table class="table table-borderless bg-white table-hover">
                    <thead>
                        <tr class="border-bottom">
                            <th scope="col"
                                v-for="column in ['#', 'Nome', 'Topico', 'Email', 'Mensagem', 'Ações']">
                                {{ column }}
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="align-middle" v-for="message in messages">
                            <th scope="row">
                                {{ message.id }}
                            </th>
                            <td>
                                {{ message.name }}
                            </td>
                            <td>
                                {{ message.topic }}
                            </td>
                            <td>
                                {{ message.email }}
                            </td>
                            <td>
                                {{ message.message }}
                            </td>
                            <td class="text-center">
                                <button class="btn fs-4" @click="userDataService.deleteUser(user.id)">
                                    <i class='bx bx-trash text-danger'></i>
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </main>
</template>