<script setup>
import { onMounted, ref } from 'vue';
import { formatPrice } from '@/assets/js/helpers';
import Loading from '@/components/shared/Loading.vue';
import http from '@/service/http';

const messages = ref({});
const data = ref({});

const deleteMessage = async (id) => {
    await http.delete(`/message/${id}`);
    data.value = await http.get("/message");;
    messages.value = data.value.data;
};

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
    <main v-else class="container w-100 m-2" data-aos="fade-up" data-aos-duration="1000">
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
                                <button class="btn fs-4" @click="deleteMessage(message.id)">
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