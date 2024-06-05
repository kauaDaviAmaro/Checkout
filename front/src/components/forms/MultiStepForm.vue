<script setup>
import addressDataService from '@/service/addressDataService';
import contactDataService from '@/service/contactDataService';
import paymentDataService from '@/service/paymentDataService';
import purchaseDataService from '@/service/purchaseDataService';
import userDataService from '@/service/userDataService';
import { useAuthStore } from '@/stores/auth';
import { useCartStore } from '@/stores/cartStore';
import { useCheckoutStore } from '@/stores/checkout';
import { useProductsStore } from '@/stores/productStore';
import { ref } from 'vue';
import { useRouter } from "vue-router";
const router = useRouter();
const auth = useAuthStore();

defineProps({
    steps: Number
})

const user = auth.user;

const cart = useCartStore();

const checkout = useCheckoutStore();

const nextStep = async (steps) => {
    const form = document.querySelector(`#step-${currentStep.value}>form`);
    if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
    }

    if (currentStep.value < steps) {
        currentStep.value++;
        return;
    }

    submitForm();
}

const submitForm = async () => {
    user.cpf = checkout.contact.cpf;
    user.phone = checkout.contact.phone;
    auth.setUser(auth.user);

    userDataService
        .updateUser(user);

    const contact = await contactDataService
        .createContact(checkout.contact);

    const address = await addressDataService
        .createAddress(checkout.address);

    const payment = await paymentDataService
        .createPayment({
            "paymentMethod": checkout.payment.method,
            "details": { ...checkout.payment, method: undefined, details: undefined },
            "note": checkout.payment.note
        });

    const productsPurchased = cart.cart;

    const purchase = {
        "userId": user.id,
        "paymentId": payment.id,
        "addressId": address.id,
        "contactId": contact.id,
        "purchases": productsPurchased.map(product => ({ "productId": product.id, "quantity": product.quantity ?? 1 }))
    }

    const response = await purchaseDataService
        .createPurchase(purchase)

    cart.clearCart();
    router.push("/success");
}

const currentStep = ref(1);
</script>

<template>
    <slot name="progress">
        {{ currentStep }} / {{ steps }} steps
        <div class="progress mb-3">
            <div class="progress-bar progress-bar-striped progress-bar-animated" aria-valuenow="75" aria-valuemin="0"
                aria-valuemax="100" :style="`width: ${(currentStep) / steps * 100}%`"></div>
        </div>
    </slot>
    <div v-for="(step, index) in steps" :key="index" :id="`step-${index + 1}`" v-show="index === currentStep - 1">
        <form @submit.prevent="nextStep(steps)" novalidate>
            <slot class="mb-3" :name="`step-${index + 1}`"></slot>
            <slot class="mb-3" name="buttons col mt-4">
                <button class="btn me-2 mt-2 btn-secondary" v-if="currentStep > 1" type="button"
                    @click="currentStep--">Back</button>
                <button class="btn mt-2 btn-primary" v-if="currentStep < steps" type="submit">Next</button>
                <button class="btn mt-2 btn-success" v-else type="submit">Submit</button>
            </slot>
        </form>
    </div>
</template>