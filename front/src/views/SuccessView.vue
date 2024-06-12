<script setup>
import { useCheckoutStore } from '@/stores/checkout';


const checkout = useCheckoutStore();

const products = checkout.purchasesProducts;

const paymentMethod = (paymentMethod) => {
    switch (paymentMethod) {
        case "CreditCard":
            return "Cartão de credito";
        case "PayPal":
            return "PayPal";
        case "Cash":
            return "Dinheiro";
    }
}
</script>

<template>
    <div class="container text-center mt-5">
        <div class="row">
            <div class="col">
                <h1>
                    Obrigado por comprar conosco !!!
                </h1>
            </div>
        </div>
        <div class="row border-bottom">
            <div class="col">
                <p class="mt-5">
                    A sua encomenda foi colocada com sucesso. Pode verificar o estado da sua encomenda na sua conta ou voltar para a página inicial
                </p>
            </div>
        </div>
        <div class="row fs-5 my-3" v-for="product in products">
            <div class="col">
                <div>
                    Indentificador da compra
                </div>
                # {{ product.id }}
            </div>
            <div class="col">
                <div>
                    Date
                </div>
                {{ new Date(product.date_Purchased).toLocaleDateString('PT-BR', { year: 'numeric', month: 'long', day: 'numeric' }) }}
            </div>
            <div class="col">
                <div>
                    Status
                </div>
                <span class="badge bg-primary">
                    {{ product.status == 0 ? 'Pendente' : 'Entregue' }}
                </span>
            </div>
            <div class="col">
                <div>
                    Payment method
                </div>
                {{ paymentMethod(product.payment.paymentMethod) }}
            </div>
        </div>
    </div>
</template>