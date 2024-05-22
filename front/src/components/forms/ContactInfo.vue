<script setup>
import { ref } from 'vue';
import { useAuthStore } from '@/stores/auth';

function formatPhone(phone) {
    return phone.replace(/\D/g, '')
        .replace(/(\d{2})(\d)/, '($1) $2')
        .replace(/(\d{5})(\d)/, '$1-$2')
        .replace(/(-\d{4})\d+$/, '$1');
}

const auth = useAuthStore();
const user = auth.user;

const phone = ref('');
</script>

<template>
    <h3 class="mb-3">Contact information</h3>
    <div class="row">
        <div class="col">
            <label for="email">Email</label>
            <input type="email" name="email" class="form-control" id="email" placeholder="Input email" required>
            <div class="invalid-feedback">
                Please provide a valid email.
            </div>
        </div>
    </div>
    <div class="form-check my-2 mb-2">
        <input type="checkbox" name="sendEmails" class="form-check-input" id="sendEmails">
        <label class="form-check-label" for="sendEmails">Send me occasional emails</label>
    </div>
    <div class="row mb-2">
        <div class="col">
            <label for="phone">Phone</label>
            <input type="text" name="phone" placeholder="Input phone" class="form-control" id="phone"
                pattern="\([0-9]{2}\) [0-9]{4,6}-[0-9]{4}" v-model="phone" @input="phone = formatPhone(phone)" required>
            <div class="invalid-feedback">
                Please provide a valid phone number.
            </div>
        </div>
    </div>
</template>