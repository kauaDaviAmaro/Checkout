<script setup>
import { useAuthStore } from '@/stores/auth';
import { onMounted, ref } from 'vue';
import purchaseDataService from '@/service/purchaseDataService';

const auth = useAuthStore();
const purchases = ref({});


onMounted(async () => {
    purchases.value = await purchaseDataService.getUserPurchases(auth.user.id);
    console.log(purchases.value);
})
</script>

<template>
    <div class="container">
        <div class="row">
            <div class="col-3 border-end fs-5">
                <div class="m-2 my-4">
                    <RouterLink to="/profile"
                        class="d-inline-block text-decoration-none bg-primary text-white p-2 w-100 rounded">
                        <i class='bx bx-user'></i>
                        Meu Perfil
                    </RouterLink>
                </div>
                <div class="m-2 ">
                    <RouterLink to="/orders"
                        class="d-inline-block text-decoration-none bg-primary text-white p-2 w-100 rounded">
                        <i class='bx bx-shopping-bag'></i>
                        Meus Pedidos
                    </RouterLink>
                </div>
            </div>
            <div class="col m-2">
                <div class="row">
                    <div class="col">
                        <h1>Meus pedidos</h1>
                    </div>
                </div>
                <table v-if="purchases.length > 0" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>
                                Indentificador da compra
                            </th>
                            <th>
                                Nome do produto
                            </th>
                            <th>
                                Data
                            </th>
                            <th>
                                Status
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="purchase in purchases">
                            <td>
                                # {{ purchase.id }}
                            </td>
                            <td>
                                {{ purchase.product.title }}
                            </td>
                            <td>
                                {{ new Date(purchase.date_Purchased).toLocaleDateString('PT-BR', { year: 'numeric', month: 'long', day: 'numeric' }) }}
                            </td>
                            <td>
                                <span class="badge bg-primary">
                                    {{ purchase.status == 0 ? 'Pendente' : 'Entregue' }}
                                </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div v-else>
                    <p class="text-center">
                        Nenhum pedido encontrado
                    </p>
                </div>
            </div>
        </div>
    </div>
</template>