import { defineStore } from "pinia";

export const useCheckoutStore = defineStore("checkout", () => {
    const address = {};
    const payment = {};
    const contact = {};

    return { address, payment, contact };
});