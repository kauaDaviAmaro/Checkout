<script setup>
import { useAuthStore } from '@/stores/auth';
import { useCheckoutStore } from '@/stores/checkout';
import { ref } from 'vue';

const payment = ref("");

function formatCardExpiration(cardExpiration) {
    return cardExpiration.replace(/\D/g, '')
        .replace(/(\d{2})(\d)/, '$1/$2')
        .replace(/(\d{2})\/(\d{2})/, '$1/$2')
        .slice(0, 5);
}

function formatCardNumber(cardNumber) {
    return cardNumber.replace(/\D/g, '').replace(/^(\d{4})(\d{4})(\d{4})(\d{0,4}).*$/, '$1 $2 $3 $4');
}

function formatCardCvv(cardCvv) {
    return cardCvv.replace(/\D/g, '').slice(0, 3);
}

const auth = useAuthStore();

const payments = ref([
    'CreditCard',
    'PayPal',
    'Cash'
]);

const checkout = useCheckoutStore();

</script>

<template>
    <h3 class="mb-3">Informações de pagamento</h3>
    <div class="row mb-2">
        <div class="col-sm-12 col-md-4 mb-2">
            <input class="btn-check" type="radio" name="payment" id="creditCard" value="CreditCard"
                v-model="checkout.payment.method" required>
            <label class="btn btn-outline-primary w-100 position-relative" for="creditCard">
                <i class='bx bx-credit-card-alt position-absolute top-50 start-0 ms-2 translate-middle-y fs-3'></i>
                Cartão de crédito
            </label>
            <div class="invalid-feedback">
                Por favor escolha uma forma de pagamento.
            </div>
        </div>
        <div class="col-sm-12 col-md-4 mb-2">
            <input class="btn-check" type="radio" name="payment" id="PayPal" value="PayPal"
                v-model="checkout.payment.method" required>
            <label class="btn btn-outline-primary w-100 position-relative" for="PayPal">
                <i class='bx bxl-paypal position-absolute top-50 start-0 ms-2 translate-middle-y fs-3'></i> PayPal
            </label>
        </div>
        <div class="col-sm-12 col-md-4 mb-2">
            <input class="btn-check" type="radio" name="payment" id="cash" value="Cash" v-model="checkout.payment.method"
                required>
            <label class="btn btn-outline-primary w-100 position-relative" for="cash">
                <i class='bx bx-money position-absolute top-50 start-0 ms-2 translate-middle-y fs-3'></i> Dinheiro
            </label>
        </div>
    </div>
    <div class="CreditCard" v-if="checkout.payment.method === 'CreditCard'">
        <div class="row mb-2">
            <div class="col">
                <label for="cardExpiration">Vencimento do cartão</label>
                <input name="cardExpiration" type="text" class="form-control" id="cardExpiration" pattern="\d{2}/\d{2}"
                    placeholder="Insira vencimento do cartão" v-model="checkout.payment.cardExpiration"
                    @input="checkout.payment.cardExpiration = formatCardExpiration(checkout.payment.cardExpiration)" required>
                <div class="invalid-feedback">
                    Por favor proporcione data de expiração de cartão válida.

                </div>
            </div>
            <div class="col">
                <label for="cardCvv">CVV do cartão</label>
                <input name="cardCvv" type="text" class="form-control" id="cardCvv" pattern="\d{3}"
                    v-model="checkout.payment.cardCvv" @input="checkout.payment.cardCvv = formatCardCvv(checkout.payment.cardCvv)"
                    placeholder="Insira CVV do cartão" required>
                <div class="invalid-feedback" pattern="\d{3}">
                    Por favor proporcione um número válido CVV de cartão.

                </div>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col">
                <label for="cardNumber">Número do cartão</label>
                <input name="cardNumber" type="text" class="form-control" id="cardNumber"
                    pattern="\d{4} \d{4} \d{4} \d{4}" placeholder="Insira número do cartão" v-model="checkout.payment.cardNumber"
                    @input="checkout.payment.cardNumber = formatCardNumber(checkout.payment.cardNumber)" required>
                <div class="invalid-feedback">
                    Por favor proporcione um número de cartão válido.

                </div>
            </div>
        </div>
    </div>
    <div class="PayPal" v-if="checkout.payment.method === 'PayPal'">
        <div class="row mb-2">
            <div class="col">
                <label for="paypalEmail">PayPal email</label>
                <input name="paypalEmail" type="email" v-model="checkout.payment.paypalEmail" class="form-control"
                    id="paypalEmail" placeholder="Insira email PayPal" required>
                <div class="invalid-feedback">
                    Por favor proporcione um email de PayPal válido.

                </div>
            </div>
        </div>
    </div>
    <div class="Cash" v-if="checkout.payment.method === 'Cash'">
        <div class="row mb-2">
            <div class="col">
                <label for="cashAmount">Valor a pagar</label>
                <input name="cashAmount" type="number" class="form-control" id="cashAmount"
                    placeholder="Insira quantia a pagar" v-model="checkout.payment.cashAmount" required>
                <div class="invalid-feedback">
                    Por favor proporcione uma quantia válida de pagamento.

                </div>
            </div>
        </div>
    </div>

    <div class="note">
        <label class="form-label fs-5 " for="note">Deixe uma nota (opcional)</label>
        <textarea name="note" class="form-control" v-model="checkout.payment.note" id="note"
            placeholder="Nota sobre seu pedido"></textarea>
    </div>
</template>