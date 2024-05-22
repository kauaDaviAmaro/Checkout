import { defineStore } from "pinia";

export const useProductsStore = defineStore("products", () => {
  const url = "http://localhost:5094/Product";
  
  const products = [];
  const product = {};
  const shoppingCart = [];

  function fetchProducts() {
    fetch(url)
      .then((res) =>
        res.ok ? res.json() : Promise.reject(new Error("Failed to fetch"))
      )
      .then((json) => {
        if (!json) {
          throw new Error("Missing products");
        }

        this.products = json;
      })
      .catch((err) => console.error(err));
  }

  function addProductQuantity(product) {
    if (!product) {
      console.error("Product is null when trying to add quantity");
      return;
    }
    if (product.stock === product.quantity) return;

    product.quantity = (product.quantity || 1) + 1;
  }

  function decreaseProductQuantity(product) {
    if (product.quantity <= 1 || product.quantity === undefined) return;
    product.quantity--;
  }

  function addToCart(product) {
    this.shoppingCart.push(product);
  }

  function removeFromCart(product) {
    product.quantity = 1;
    this.shoppingCart = this.shoppingCart.filter(
      (item) => item.id !== product.id
    );
  }

  function getTotal() {
    return this.shoppingCart.reduce(
      (total, item) => total + item.price * item.quantity,
      0
    );
  }

  function deleteCart() {
    this.shoppingCart.length = 0;
  }

  function isShoppingCartEmpty() {
    return this.shoppingCart.length === 0;
  }

  function filterProducts(searchTerm) {
    if (!searchTerm) return this.products;
    return this.products.filter((product) =>
      product.title.toLowerCase().includes(searchTerm.toLowerCase())
    );
  }

  const getProductById = async (id) => {
    const response = await fetch(`${url}/${id}`);
    const data = await response.json();
    return  data;
  }

  return {
    products,
    fetchProducts,
    addToCart,
    shoppingCart,
    removeFromCart,
    filterProducts,
    addProductQuantity,
    decreaseProductQuantity,
    getTotal,
    deleteCart,
    isShoppingCartEmpty,
    getProductById
  };
});
