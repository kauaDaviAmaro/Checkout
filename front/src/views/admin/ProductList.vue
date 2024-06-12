<script setup>
import { onMounted, ref } from 'vue';
import { formatPrice } from '@/assets/js/helpers';
import productDataService from '@/service/productDataService';
import Loading from '@/components/shared/Loading.vue';

const products = ref({});
const data = ref({});

const loading = ref(false);
onMounted(async () => {
    loading.value = true;
    data.value = await productDataService.getProducts(0, 100);
    products.value = data.value.products;
    loading.value = false
    console.log(products.value);
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
                <li class="breadcrumb-item active" aria-current="page">Produtos</li>
            </ol>
        </nav>
        <div class="table-container bg-white border p-3 rounded">
            <div class="table-header d-flex justify-content-between align-items-center m-3">
                <div class="title">
                    <h2 class="fs-4 fw-bold">Lista de produtos</h2>
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
                                v-for="column in ['#', 'Nome', 'Categoria', 'preço', 'Estoque', 'Avaliação']">
                                {{ column }}
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="align-middle" v-for="product in products">
                            <th scope="row">
                                {{ product.id }}
                            </th>
                            <td>
                                {{ product.title }}
                            </td>
                            <td>
                                {{ product.category }}
                            </td>
                            <td>
                                {{ formatPrice(product.price) }}
                            </td>
                            <td>
                                {{ product.stock }}
                            </td>
                            <td>
                                {{ product.rating }}
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