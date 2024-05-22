<script setup>
import { ref } from 'vue';
import { useAuthStore } from '@/stores/auth';

function formatCpf(cpf) {
    return cpf.replace(/\D/g, '')
        .replace(/(\d{3})(\d)/, '$1.$2')
        .replace(/(\d{3})(\d)/, '$1.$2')
        .replace(/(\d{3})(\d{1,2})/, '$1-$2')
        .replace(/(-\d{2})\d+$/, '$1');
}

const cpf = ref('');

</script>

<template>
    <h3 class="mb-3">Shipping address</h3>
    <div class="row mb-2">
        <div class="col">
            <label for="fullName">Full name</label>
            <input type="text" name="fullName" class="form-control" id="fullName" placeholder="Input full name" required>
            <div class="invalid-feedback">
                Please provide a valid name.
            </div>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col">
            <label for="street">Street address</label>
            <input type="text" name="street" class="form-control" id="street" placeholder="Input street address" required>
            <div class="invalid-feedback">
                Please provide a valid street address.
            </div>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col-sm-12 col-md-6">
            <label for="city">City</label>
            <input type="text" name="city" class="form-control" id="city" placeholder="Input city" required>
            <div class="invalid-feedback">
                Please provide a valid city.
            </div>
        </div>
        <div class="col">
            <label for="state">State</label>
            <input type="text" name="state" class="form-control" id="state" placeholder="Input state" required>
            <div class="invalid-feedback">
                Please provide a valid state.
            </div>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col">
            <label for="cpf">CPF</label>
            <input type="text" name="cpf" class="form-control" id="CPF" placeholder="Input CPF" pattern="\d{3}\.\d{3}\.\d{3}-\d{2}"
                v-model="cpf" @input="cpf = formatCpf(cpf)" required>
            <div class="invalid-feedback">
                Please provide a valid CPF.
            </div>
        </div>
    </div>
</template>