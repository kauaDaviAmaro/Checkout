<script setup>
import CatalogProductCard from '@/components/product/CatalogProductCard.vue';
import { onMounted, computed, ref, watch } from 'vue';
import { useProductsStore } from '@/stores/products';
import { useRoute, useRouter } from 'vue-router';
import Loading from '@/components/Loading.vue';
import Filter from '@/components/Filter.vue';
import NoProductsFound from '@/components/NoProductsFound.vue';
import ProductGrid from '@/components/ProductGrid.vue';
import ProductCount from '@/components/ProductCount.vue';
import OrderBy from '@/components/OrderBy.vue';


const productsStore = useProductsStore();

const route = useRoute();
const router = useRouter();
const search = ref(route.params.search || '');

watch(route, () => {
  search.value = route.params.search || '';
});

const filteredProducts = computed(() => {
  return productsStore.products.filter((product) => {
    return product.title.toLowerCase().includes(search.value.toLowerCase());
  });
});

const clearSearch = () => {
  router.push('/products/');
};

const loading = ref(false);

onMounted(async () => {
  loading.value = true;
  // await new Promise((resolve) => setTimeout(resolve, 10000));
  await productsStore.fetchProducts();
  loading.value = false;
});


const showFilter = ref(false);

</script>

<template>
  <Loading v-if="loading" />
  <div class="d-flex" v-if="filteredProducts.length > 0" data-aos="fade-in" data-aos-duration="1000"
    data-aos-offset="200">
    <Filter :class="{ 'show': !showFilter }"/>

    <div class="grid-container w-100 px-3">
      <div class="d-flex justify-content-between align-items-center">
        <ProductCount :search="search" :filteredProductsCount="filteredProducts.length"
          :productsCount="productsStore.products.length" />

        <OrderBy class="orderby" />

        <button class="show-filter btn btn-secondary" @click="showFilter = !showFilter">
          <i class='bx bxs-filter-alt'></i>
        </button>
      </div>

      <div class="text-muted" v-if="search">
        <div>
          Search results:
        </div>
        <div class="badge bg-danger my-2">
          {{ search }}
          <button class="btn-close" @click="clearSearch">X</button>
        </div>
      </div>

      <ProductGrid class="mt-3" :products="filteredProducts" />
    </div>
  </div>

  <NoProductsFound v-else />
</template>

<style scoped>
.show-filter {
  display: none;
}
@media screen and (max-width: 768px) {
  .grid-container {

  }
  .orderby {
    display: none;
  }

  .show-filter {
    display: block;
  }
}
</style>