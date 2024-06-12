<script setup>
import { onMounted, ref } from 'vue';
import { formatPrice } from '@/assets/js/helpers';
import Loading from '@/components/shared/Loading.vue';
import http from '@/service/http';
import { Chart } from 'chart.js';

const information = ref({});

const loading = ref(false);

function formatDate(dateString) {
    return dateString.split('T')[0];
}



const initChart = (ctx) => {
    const salesCount = information.value.purchasesDates.reduce((acc, timestamp) => {
        const date = formatDate(timestamp);
        acc[date] = (acc[date] || 0) + 1;
        return acc;
    }, {});

    const labels = Object.keys(salesCount);
    const data = Object.values(salesCount);
    const salesChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Total de compras',
                data: data,
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            },
            ]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            },
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Vendas Diárias'
                }
            }
        }
    });
}

onMounted(async () => {
    const ctx = document.getElementById('salesChart').getContext('2d');

    loading.value = true;
    const data = await http.get("/Information");;
    information.value = data.data;
    loading.value = false
    initChart(ctx);
});
</script>

<template>
    <Loading v-if="loading" />
    <main data-aos="fade-up" data-aos-duration="1000" class="container w-100 m-2">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item ">
                    <RouterLink to="/admin">Dashboard</RouterLink>
                </li>
                <li class="breadcrumb-item active" aria-current="page">Home view</li>
            </ol>
        </nav>

        <div class="row mb-2">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Total de compras</h5>
                        <p class="card-text fs-5 fw-bold">
                            {{ information.totalPurchases }} produtos comprados
                        </p>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Total de usuários</h5>
                        <p class="card-text fs-5 fw-bold">
                            {{ information.totalUsers }} usuarios
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Total de Mensagens</h5>
                        <p class="card-text fs-5 fw-bold">
                            {{ information.totalMessages }} mensagens
                        </p>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Total de produtos</h5>
                        <p class="card-text fs-5 fw-bold">
                            {{ information.totalProducts }} produtos
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col">
                <div class="card text-center">
                    <div class="card-body">
                        <h5 class="card-title">Total de vendas</h5>
                        <p class="card-text fs-5 fw-bold">
                            {{ formatPrice(information.totalSales) }}
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <canvas class="mt-3" id="salesChart" width="400" height="400"></canvas>
    </main>
</template>

<style scoped>
canvas {
    max-width: 100%;
    max-height: 50vh;
}
</style>