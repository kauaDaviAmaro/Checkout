<script setup>
import { onMounted, ref } from 'vue';
import { useProductsStore } from '@/stores/productStore';
import Loading from '@/components/shared/Loading.vue';
import ProductCount from '@/components/product/ProductCount.vue';
import OrderBy from '@/components/product/OrderBy.vue';
import ProductGrid from '@/components/product/ProductGrid.vue';
import Pagination from '@/components/product/Pagination.vue';
import NoProductsFound from '@/components/shared/NoProductsFound.vue';

const productsStore = useProductsStore();
const loading = ref(false);

onMounted(async () => {
  loading.value = true;
  await productsStore.fetchProducts();
  loading.value = false;
})
</script>

<template>
  <Loading v-if="loading" />
  <div class="d-flex m-4" v-else-if="!productsStore.isEmpty()" data-aos="fade-in" data-aos-duration="1000"
    data-aos-offset="200">
    <!-- <Filter /> -->

    <div class="grid-container w-100 px-3">
      <div class="d-flex justify-content-between align-items-center">
        <ProductCount />

        <OrderBy class="orderby" />

        <button class="show-filter btn btn-secondary" @click="showFilter = !showFilter">
          <i class='bx bxs-filter-alt'></i>
        </button>
      </div>

      <div class="text-muted" v-if="productsStore.searchQuery">
        <div>
          Search results:
        </div>
        <div class="badge bg-danger my-2">
          {{ productsStore.searchQuery }}
          <button class="btn-close" @click="productsStore.clearSearch">X</button>
        </div>
      </div>

      <ProductGrid class="mt-3" />

      <Pagination class="mt-3" />
    </div>
  </div>

  <NoProductsFound v-else />
</template>

<style scoped>
.show-filter {
  display: none;
}

/* @media screen and (max-width: 768px) {
  .orderby {
    display: none;
  }

  .show-filter {
    display: block;
  }
} */
</style>