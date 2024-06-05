import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useCartStore = defineStore("cart", () => {
    const cart = ref([]);

    const addToCart = (product) => {
        if (isInCart(cart.value, product))
            return;

        product.quantity = 1;
        cart.value.push(product);
    };

    const removeFromCart = (product) => {
        cart.value = cart.value.filter((p) => p.id !== product.id);
    };

    const clearCart = () => {
        cart.value = [];
    };

    const decreaseQuantity = (product) => {
        if (product.quantity > 1) {
            product.quantity--;
        }
    };

    const increaseQuantity = (product) => {
        if (product.stock > product.quantity) {
            product.quantity++;
        }
    };

    const isInCart = (product) => {
        return cart.value.some((p) => p.id === product.id);
    };

    const total = computed(() => {
        return cart.value.reduce((total, product) => total + product.price * product.quantity, 0);
    });

    const totalQuantity = computed(() => {
        return cart.value.reduce((total, product) => total + product.quantity, 0);
    });

    const isEmpty = computed(() => cart.value.length === 0);

    return { 
        cart, 
        total, 
        totalQuantity, 
        isInCart, 
        isEmpty, 
        addToCart, 
        removeFromCart, 
        clearCart, 
        decreaseQuantity, 
        increaseQuantity 
    };
});