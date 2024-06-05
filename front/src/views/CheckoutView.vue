<script setup>
import { useCartStore } from '@/stores/cartStore';
import MultiStepForm from '@/components/forms/MultiStepForm.vue';
import OrderSummary from '@/components/cart/OrderSummary.vue';
import PaymentInfo from '@/components/forms/PaymentInfo.vue';
import ShippingInfo from '@/components/forms/ShippingInfo.vue';
import ContactInfo from '@/components/forms/ContactInfo.vue';
import EmptyCart from '@/components/cart/EmptyCart.vue';

const cart = useCartStore();
</script>

<template>
  <div class="container-lg px-5 d-flex flex-column justify-content-center" v-if="!cart.isEmpty">
    <div class="row">
      <div class="col-md-8 mb-4" data-aos="fade-right" data-aos-duration="1000">
        <MultiStepForm :steps="3">
          <template #step-1>
            <ContactInfo />
          </template>
          <template #step-2>
            <ShippingInfo />
          </template>
          <template #step-3>
            <PaymentInfo />
          </template>
        </MultiStepForm >
      </div>
      <div class="col px-3" data-aos="fade-left" data-aos-duration="1000">
        <OrderSummary />
      </div>
    </div>
  </div>
  <EmptyCart v-else />
</template>

<style scoped>
.container-lg {
    min-height: 60vh;
}
</style>