import { debounce } from "@/assets/js/helpers";
import productDataService from "@/service/productDataService";
import { defineStore } from "pinia";
import { ref, watch } from "vue";

export const useProductsStore = defineStore("products", () => {
  const products = ref([]);
  const searchQuery = ref(null);
  const selectedCategory = ref(null);
  const currentPage = ref(1);
  const pageSize = ref(12);
  const totalProducts = ref(0);
  const totalPages = ref(0);
  const sort = ref(null);

  const fetchProducts = async () => {
    const data = await productDataService.getProducts(
      currentPage.value - 1,
      pageSize.value,
      searchQuery.value,
      selectedCategory.value,
      sort.value
    );

    console.log(data);

    products.value = data.products.map(product => {
      if (product.quantity === undefined)
        product.quantity = 0
      return product;
    });
    totalProducts.value = data.totalProducts;
    totalPages.value = data.totalPages;
  };

  const getProductById = async (id) => {
    const data = await productDataService.getProductById(id);
    return data;
  };

  const setQuery = async (value) => {
    currentPage.value = 1;
    searchQuery.value = value;

    products.value = [];
    await fetchProducts();
  };

  const setCategory = async (value) => {
    currentPage.value = 1;
    selectedCategory.value = value;

    await fetchProducts();
  };

  const sortBy = async (value) => {
    currentPage.value = 1;
    sort.value = value;

    products.value = [];
    await fetchProducts();
  };

  const setCurrentPage = async (value) => {
    currentPage.value = value;
    products.value = [];
    await fetchProducts();
    window.scrollTo(0, 0);
  };

  const isEmpty = () => {
    return products.value.length === 0;
  };

  const clearSearch = async () => {
    searchQuery.value = null;

    currentPage.value = 1;
    products.value = [];

    await fetchProducts();
  };

  watch(
    searchQuery,
    debounce(async (newValue) => {
      setQuery(newValue);
    }, 500)
  );

  return {
    products,
    totalPages,
    searchQuery,
    selectedCategory,
    currentPage,
    pageSize,
    totalProducts,
    sort,
    sortBy,
    fetchProducts,
    setQuery,
    setCategory,
    setCurrentPage,
    isEmpty,
    getProductById,
    clearSearch
  };

});
