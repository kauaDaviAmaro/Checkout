<template>
    <aside class="sidebar border-end d-flex flex-column justify-content-between position-fixed bg-dark ">
        <div class="text-white">
            <div class="title">
                <h2 class="fs-4 fw-bold">[AWESOME STORE]</h2>
            </div>

            <div class="links d-flex flex-column w-100 fs-4 mt-5 ">
                <router-link class="link text-decoration-none text-light mb-4" to="/admin/dashboard">
                    <i class='bx bx-home me-3 '></i> Dashboard
                </router-link>
                <router-link class="link text-decoration-none text-light mb-4" to="/admin/orders">
                    <i class='bx bx-package me-3 '></i> Pedidos
                </router-link>
                <router-link class="link text-decoration-none text-light mb-4" to="/admin/products">
                    <i class='bx bx-shopping-bag me-3 '></i> Produtos
                </router-link>
                <router-link class="link text-decoration-none text-light mb-4" to="/admin/users">
                    <i class='bx bx-user me-3 '></i> Usuários
                </router-link>
                <router-link class="link text-decoration-none text-light mb-4" to="/admin/messages">
                    <i class='bx bx-message me-3 '></i> Mensagens
                </router-link>
            </div>
        </div>

        <div class="profile d-flex justify-content-between">
            <div class="user d-flex align-items-center">
                <div class="avatar">
                    <i class='bx bx-user text-white fs-3 me-3'></i>
                </div>
                <div class="name text-white">
                    <h4 class="fw-bold">Admin</h4>
                </div>
            </div>

            <div class="logout">
                <button class="btn d-flex align-items-center text-white">
                    <i class='bx bx-log-out fs-3 me-3'></i>
                    Sair
                </button>
            </div>
        </div>
    </aside>
</template>

<style scoped>
.sidebar {
    width: 300px;
    height: 100vh;
    padding: 20px;
}
</style>