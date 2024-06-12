import { defineStore } from "pinia";

export const useCheckoutStore = defineStore("checkout", () => {
    const address = {};
    const payment = {};
    const contact = {};

    const purchasesProducts = {};

    return { address, payment, contact, purchasesProducts };
});