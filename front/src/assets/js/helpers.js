import { computed } from 'vue';
import { useProductsStore } from '@/stores/products';

export const formatPrice = (price) => {
    return new Intl.NumberFormat('us', { style: 'currency', currency: 'USD' }).format(price);
}

export const total = computed(() =>
    useProductsStore().shoppingCart.reduce(
        (acc, { price, quantity = 1 }) => acc + price * quantity,
        0
    )
);

export const isLoggedIn = () => {
    return localStorage.getItem('user') !== null;
}

export const getFormData = (form) => {
    let data = {};
    let formData = new FormData(form);

    for (const [key, value] of formData.entries()) {
        data[key] = value;
    }
    return data;
}

export function createAlert(type, message) {
    const alert = document.createElement('div');
    alert.classList.add('alert', `alert-${type}`, 'position-fixed', 'bottom-0', 'end-0', 'm-3');
    alert.textContent = message;
    document.documentElement.append(alert);
    setTimeout(() => alert.remove(), 3000);
}

export function debounce(fn, wait){
    let timer;
   return function(...args){
     if(timer) {
        clearTimeout(timer);
     }
     const context = this;
     timer = setTimeout(()=>{
        fn.apply(context, args);
     }, wait);
   }
}

export const validate = (form) => {
    if (!form.checkValidity()) {
        form.classList.add("was-validated");
        return false;
    }

    return true;
};

export const emptyForm = (form) => {
    form.reset();
    form.classList.remove("was-validated");
};

export const isDarkMode = computed(() => {
    return localStorage.getItem('darkMode') === 'true';
});

export const isInCart = (product) => useProductsStore().shoppingCart.some(p => p.id === product.id)

export const shoppingCart = computed(() => useProductsStore().shoppingCart);

export const totalItems = computed(() => useProductsStore().shoppingCart.reduce((acc, { quantity = 1 }) => acc + quantity, 0));
