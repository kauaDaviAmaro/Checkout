<script setup>
import Sidebar from '@/components/admin/Sidebar.vue';
import Navbar from './Navbar.vue';

</script>

<template>
    <Sidebar />
    
    <div class="content">
        <Navbar />
        <router-view v-slot="{ Component }">
            <component :is="Component" />
        </router-view>
    </div>
</template>

<style scoped>
.content {
    margin-top: 0px;
    margin-left: 299px;
    /* background-color: #1F2021; */
}

</style>