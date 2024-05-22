<script setup>
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

const cardExpiration = ref('');

const cardCvv = ref('');

const cardNumber = ref('');
</script>

<template>
    <h3 class="mb-3">Payment information</h3>
    <div class="row mb-2">
        <div class="col-sm-12 col-md-4 mb-2">
            <input class="btn-check" type="radio" name="payment" id="creditCard" value="CreditCard" v-model="payment"
                required>
            <label class="btn btn-outline-primary w-100 position-relative" for="creditCard">
                <i class='bx bx-credit-card-alt position-absolute top-50 start-0 ms-2 translate-middle-y fs-3'></i>
                Credit Card
            </label>
            <div class="invalid-feedback">
                Please provide a payment.
            </div>
        </div>
        <div class="col-sm-12 col-md-4 mb-2">
            <input class="btn-check" type="radio" name="payment" id="PayPal" value="PayPal" v-model="payment" required>
            <label class="btn btn-outline-primary w-100 position-relative" for="PayPal">
                <i class='bx bxl-paypal position-absolute top-50 start-0 ms-2 translate-middle-y fs-3'></i> PayPal
            </label>
        </div>
        <div class="col-sm-12 col-md-4 mb-2">
            <input class="btn-check" type="radio" name="payment" id="cash" value="Cash" v-model="payment" required>
            <label class="btn btn-outline-primary w-100 position-relative" for="cash">
                <i class='bx bx-money position-absolute top-50 start-0 ms-2 translate-middle-y fs-3'></i> Cash
            </label>
        </div>
    </div>
    <div class="CreditCard" v-if="payment === 'CreditCard'">
        <div class="row mb-2">
            <div class="col">
                <label for="cardExpiration">Card expiration</label>
                <input name="cardExpiration" type="text" class="form-control" id="cardExpiration" pattern="\d{2}/\d{2}"
                    placeholder="Input card expiration" v-model="cardExpiration"
                    @input="cardExpiration = formatCardExpiration(cardExpiration)" required>
                <div class="invalid-feedback">
                    Please provide a valid card expiration.
                </div>
            </div>
            <div class="col">
                <label for="cardCvv">Card CVV</label>
                <input name="cardCvv" type="text" class="form-control" id="cardCvv" pattern="\d{3}" v-model="cardCvv"
                    @input="cardCvv = formatCardCvv(cardCvv)" placeholder="Input card CVV" required>
                <div class="invalid-feedback" pattern="\d{3}">
                    Please provide a valid card CVV.
                </div>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col">
                <label for="cardNumber">Card number</label>
                <input name="cardNumber" type="text" class="form-control" id="cardNumber"
                    pattern="\d{4} \d{4} \d{4} \d{4}" placeholder="Input card number" v-model="cardNumber"
                    @input="cardNumber = formatCardNumber(cardNumber)" required>
                <div class="invalid-feedback">
                    Please provide a valid card number.
                </div>
            </div>
        </div>
    </div>
    <div class="PayPal" v-if="payment === 'PayPal'">
        <div class="row mb-2">
            <div class="col">
                <label for="paypalEmail">PayPal email</label>
                <input name="paypalEmail" type="email" class="form-control" id="paypalEmail"
                    placeholder="Input PayPal email" required>
                <div class="invalid-feedback">
                    Please provide a valid PayPal email.
                </div>
            </div>
        </div>
    </div>
    <div class="Cash" v-if="payment === 'Cash'">
        <div class="row mb-2">
            <div class="col">
                <label for="cashAmount">Cash amount</label>
                <input name="cashAmount" type="number" class="form-control" id="cashAmount"
                    placeholder="Input cash amount" required>
                <div class="invalid-feedback">
                    Please provide a valid cash amount.
                </div>
            </div>
        </div>
    </div>

    <div class="note">
        <label class="form-label fs-5 " for="note">Leave a note (optional)</label>
        <textarea name="note" class="form-control" id="note" placeholder="Note about your order"></textarea>   
    </div>
</template>