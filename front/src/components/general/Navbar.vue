<script setup>
import { totalItems, isLoggedIn } from '@/assets/js/helpers';
import { useAuthStore } from '@/stores/auth';
import { onMounted, ref, watch, computed } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const router = useRouter();

const route = useRoute();

const darkMode = ref(localStorage.getItem("darkMode") === "true");

const toggleDarkMode = () => {
    darkMode.value = !darkMode.value;
    localStorage.setItem("darkMode", darkMode.value);
    setAtributesElements();
}

function setAtributesElements() {
    document.querySelectorAll('*').forEach((element) => {
        element.setAttribute("data-bs-theme", darkMode.value ? "dark" : "light")
    })
}

const search = ref("");

watch(search, () => {
    router.push(`/products/${search.value}`);
});

watch(route, () => {
    search.value = route.params.search || '';
});

onMounted(() => {
    if (!localStorage.getItem("darkMode")) {
        localStorage.setItem("darkMode", true);
        darkMode.value = true;
    }
    setAtributesElements();
});

const auth = useAuthStore();

const userName = auth.user.name.substring(0, 7);
</script>

<template>
    <nav class="navbar sticky-top  navbar-expand-lg p-3" style="background-color: var(--bss);">
        <div class="container-fluid">
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup"
                aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="links d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <RouterLink to="/" class="navbar-brand">
                    [AWESOME STORE]
                </RouterLink>
                <div class="navbar-nav">
                    <RouterLink to="/" class="nav-link">Home</RouterLink>
                    <RouterLink to="/products" class="nav-link">Products</RouterLink>
                    <RouterLink to="/contact" class="nav-link">Contact</RouterLink>
                    <RouterLink to="/about" class="nav-link">About</RouterLink>
                </div>
            </div>
            <div class="d-flex" role="search">
                <div class="icons d-flex flex-wrap align-items-center">
                    <div class="search">
                        <i class='bx bx-search'></i>
                        <input v-model="search" type="text" class="search-click" placeholder="search here..." />
                    </div>
                    <button :class="{ 'btn-dark': !darkMode }" @click="toggleDarkMode" class="btn mx-3 ">
                        <i :class="!darkMode ? 'bx bx-moon text-light' : 'bx bxs-sun text-warning'"></i>
                    </button>
                    <div class="dropdown h-100">
                        <div class="btn h-100 d-flex align-items-center dropdown-toggle" data-bs-toggle="dropdown"
                            aria-expanded="false">
                            <span class="me-2" v-if="auth.isAuthenticated">
                                {{ userName }}
                            </span>
                            <i class='bx bx-user'></i>
                        </div>
                        <ul class="dropdown-menu">
                            <li v-if="!auth.isAuthenticated">
                                <RouterLink to="/login" class="dropdown-item">Login</RouterLink>
                            </li>
                            <li v-if="!auth.isAuthenticated">
                                <RouterLink to="/register" class="dropdown-item">Register</RouterLink>
                            </li>
                            <li v-if="auth.isAuthenticated">
                                <RouterLink to="/" class="dropdown-item">Profile</RouterLink>
                            </li>
                            <li v-if="auth.isAuthenticated">
                                <button @click="auth.logout" class="dropdown-item">Logout</button>
                            </li>
                        </ul>
                    </div>
                    <RouterLink to="/cart" class="position-relative">
                        <button class="btn">
                            <i class='bx bx-cart'></i>
                            <span v-if="totalItems > 0"
                                class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger">
                                {{ totalItems }}
                                <span class="visually-hidden">Items in cart</span>
                            </span>
                        </button>
                    </RouterLink>

                </div>
            </div>
        </div>

        <div class="collapse mt-2" id="navbarNavAltMarkup">
            <div class="navbar-nav">
                <RouterLink to="/" class="nav-link">Home</RouterLink>
                <RouterLink to="/products" class="nav-link">Products</RouterLink>
                <RouterLink to="/contact" class="nav-link">Contact</RouterLink>
                <RouterLink to="/about" class="nav-link">About</RouterLink>
            </div>

            <div class="search-icon">
                <i class='bx bx-search'></i>
                <input v-model="search" type="text" class="search-click" name="" placeholder="search here..." />
            </div>
        </div>
    </nav>
</template>

<style scoped>
i {
    font-size: 24px;
    color: var(--color-text);
}

button {
    height: 50px;
}

.search,
.search-icon {
    position: relative;
}

.search i,
.search-icon i {
    position: absolute;
    top: 50%;
    left: 15px;
    transform: translate(0, -50%);
    z-index: 1;
    color: var(--color-text);
    font-size: 24px;
    cursor: pointer;
    pointer-events: none;

}

.search-click {
    cursor: pointer;
    border: 1px solid #cccccc31;
    outline: none;
    background-size: 22px;
    background-position: 13px;
    border-radius: 10px;
    width: 50px;
    height: 50px;
    padding: 25px;
    transition: all 0.5s;
    color: transparent;
    position: relative;
    overflow: hidden;
}

.search-click:focus {
    cursor: text;
    color: var(--color-text);
    width: 300px;
    padding-left: 50px;
}

.search-click input {
    background: transparent;
    border: 1px solid #ccc;
    outline: none;
    position: absolute;
    width: 300px;
    height: 50px;
    left: 0%;
    padding: 10px;
}

.search-icon .search-click {
    width: 91vw;
    padding-left: 50px;
}

@media (max-width: 980px) {

    .links,
    .search {
        display: none !important;
    }
}
</style>