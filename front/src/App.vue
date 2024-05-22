<script setup>
import Navbar from '@/components/general/Navbar.vue';
import FooterBar from './components/general/FooterBar.vue';
</script>

<template>
  <div class="d-flex flex-column min-vh-100">
    <Navbar />

    <router-view v-slot="{ Component }">
      <component :is="Component" />
    </router-view>

    <FooterBar />
  </div>
</template>