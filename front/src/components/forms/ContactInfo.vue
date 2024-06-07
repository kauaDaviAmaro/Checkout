<script setup>
import { ref } from 'vue';
import { useAuthStore } from '@/stores/auth';
import { useCheckoutStore } from '@/stores/checkout';

function formatPhone(phone) {
    return phone.replace(/\D/g, '')
        .replace(/(\d{2})(\d)/, '($1) $2')
        .replace(/(\d{5})(\d)/, '$1-$2')
        .replace(/(-\d{4})\d+$/, '$1');
}

function formatCpf(cpf) {
    return cpf.replace(/\D/g, '')
        .replace(/(\d{3})(\d)/, '$1.$2')
        .replace(/(\d{3})(\d)/, '$1.$2')
        .replace(/(\d{3})(\d{1,2})/, '$1-$2')
        .replace(/(-\d{2})\d+$/, '$1');
}


const auth = useAuthStore();
const user = auth.user;

const fullname = ref(user.firstName + ' ' + user.lastName);

const checkout = useCheckoutStore();

checkout.contact = {
    cpf: user.cpf,
    name: user.firstName + ' ' + user.lastName,
    phone: user.phone,
    email: user.email,
    sendEmails: false
}
</script>

<template>
    <h3 class="mb-3">Informações de contato</h3>
    <div class="row mb-2">
        <div class="col-12 mb-2">
            <label for="fullname" class="form-label">Nome completo:</label>
            <input type="text" name="fullname" v-model="fullname" class="form-control" required
                placeholder="Insira seu primeiro nome">
            <div class="invalid-feedback">
                Por favor proporcione um nome válido.
            </div>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col">
            <label for="phone">Telefone</label>
            <input type="text" name="phone" placeholder="Insira seu telefone" class="form-control" id="phone"
                pattern="\([0-9]{2}\) [0-9]{4,6}-[0-9]{4}" maxlength="15" v-model="checkout.contact.phone"
                @input="checkout.contact.phone = formatPhone(checkout.contact.phone)" required>
            <div class="invalid-feedback">
                Por favor proporcione um número de celular válido

            </div>
        </div>
        <div class="col">
            <label for="cpf">CPF</label>
            <input type="text" name="cpf" class="form-control" id="CPF" placeholder="Insira seu CPF"
                pattern="\d{3}\.\d{3}\.\d{3}-\d{2}" v-model="checkout.contact.cpf"
                @input="checkout.contact.cpf = formatCpf(checkout.contact.cpf)" required>
            <div class="invalid-feedback">
                Por favor proporcione um CPF válido.
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <label for="email">Email</label>
            <input type="email" name="email" class="form-control" v-model="user.email" id="email"
                placeholder="Insira seu email" required>
            <div class="invalid-feedback">
                Por favor proporcione um email válido.
            </div>
        </div>
    </div>
    <div class="form-check my-2 mb-2">
        <input type="checkbox" v-model="checkout.contact.sendEmails" name="sendEmails" class="form-check-input"
            id="sendEmails">
        <label class="form-check-label" for="sendEmails">Envie-me emails ocasionais</label>
    </div>
</template>