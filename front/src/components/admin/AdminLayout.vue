<script setup>
import Sidebar from '@/components/admin/Sidebar.vue';
import Navbar from './Navbar.vue';

</script>

<template>
    <Sidebar />
    
    <div class="content">
        <Navbar />
        <router-view  v-slot="{ Component }">
            <component :is="Component" />
        </router-view>
    </div>
</template>

<style scoped>
.content {
    margin-left: 300px;
}
</style>