<script setup>
import { onMounted, ref } from 'vue';
import { formatPrice } from '@/assets/js/helpers';
import purchaseDataService from '@/service/purchaseDataService';
import Loading from '@/components/shared/Loading.vue';

const purchases = ref({});
const data = ref({});

const paymentMethod = (paymentMethod) => {
    switch (paymentMethod) {
        case "CreditCard":
            return "Cartão de credito";
        case "PayPal":
            return "PayPal";
        case "Cash":
            return "Dinheiro";
    }
}

const deletePurchase = async (id) => {
    await purchaseDataService.deletePurchase(id);
    data.value = await purchaseDataService.getAll();
    purchases.value = data.value;
};

const loading = ref(false);
onMounted(async () => {
    loading.value = true;
    data.value = await purchaseDataService.getAll();
    purchases.value = data.value;
    loading.value = false
    console.log(purchases.value);
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
                <li class="breadcrumb-item active" aria-current="page">Pedidos</li>
            </ol>
        </nav>
        <div class="table-container bg-white border p-3 rounded">
            <div class="table-header d-flex justify-content-between align-items-center m-3">
                <div class="title">
                    <h2 class="fs-4 fw-bold">Lista de Pedidos</h2>
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
                                v-for="column in ['#', 'Produto', 'Comprador', 'preço', 'Metodo Pagamento', 'Status']">
                                {{ column }}
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="align-middle" v-for="purchase in purchases">
                            <th scope="row">
                                {{ purchase.id }}
                            </th>
                            <td>
                                {{ purchase.product.title }}
                            </td>
                            <td>
                                {{ purchase.user.firstName }}
                            </td>
                            <td>
                                {{ formatPrice(purchase.product.price) }}
                            </td>
                            <td>
                                {{ paymentMethod(purchase.payment.paymentMethod) }}
                            </td>
                            <td :class="purchase.status == 0 ? 'text-danger' : 'text-success'">
                                {{ purchase.status == 0 ? "Pendente" : "Completo" }}
                            </td>
                            <td class="text-center">
                                <button class="btn fs-4" @click="deletePurchase(purchase.id)">
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