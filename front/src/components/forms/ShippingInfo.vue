<script setup>
import { reactive, ref } from 'vue';
import { useAuthStore } from '@/stores/auth';
import userDataService from '@/service/userDataService';
import { useCheckoutStore } from '@/stores/checkout';
import Loading from '../shared/Loading.vue';

const formatCep = (cep) => {
    return cep.replace(/\D/g, '')
        .replace(/(\d{5})(\d)/, '$1-$2')
        .replace(/(-\d{3})\d+$/, '$1');
}

const auth = useAuthStore();
const user = reactive(auth.user);

const address = reactive({
    cep: '',
    street: '',
    number: '',
    complement: '',
    city: '',
    state: '',
    neighborhood: '',
});

const checkout = useCheckoutStore();

const searchCep = async () => {
    if (checkout.address.cep.length === 9) {
        loading.value = true;
        const response = await userDataService.getCep(checkout.address.cep);
        checkout.address.street = response.logradouro;
        checkout.address.city = response.localidade;
        checkout.address.state = response.uf;
        checkout.address.neighborhood = response.bairro;
        checkout.address.complement = response.complemento;
        loading.value = false;
    }
}

const uf = [
    'AC', 'AL', 'AP', 'AM', 'BA', 'CE', 'DF', 'ES', 'GO',
    'MA', 'MT', 'MS', 'MG', 'PA', 'PB', 'PR', 'PE', 'PI',
    'RJ', 'RN', 'RS', 'RO', 'RR', 'SC', 'SP', 'SE', 'TO'
]

const loading = ref(false);
</script>

<template>
    <Loading v-if="loading"/>
    <h3 class="mb-3">Endereço de entrega</h3>
    <div class="row mb-2">
        <div class="col">
            <label for="cep">CEP</label>
            <input type="text" name="cep" v-model="checkout.address.cep"
                @input="checkout.address.cep = formatCep(checkout.address.cep)" class="form-control" id="cep"
                placeholder="Insira o seu cep" @keyup="searchCep" maxlength="9" required>
            <div class="invalid-feedback">
                Por favor insira o seu cep.
            </div>
        </div>
    </div>
    <div class="row mb-2">
        <div class="col-md-8 col-sm-12">
            <label for="street">Logradouro</label>
            <input type="text" name="street" v-model="checkout.address.street" class="form-control" id="street"
                placeholder="Insira a sua rua" required>
            <div class="invalid-feedback">
                Por favor insira o seu logradouro.
            </div>
        </div>
        <div class="col">
            <label for="number">Número</label>
            <input type="number" name="number" v-model="checkout.address.number" class="form-control" id="number"
                placeholder="Insira o seu número" required>
            <div class="invalid-feedback">
                Por favor insira o seu número.
            </div>
        </div>
    </div>

    <div class="row mb-2">
        <div class="col">
            <label for="neighborhood">Bairro</label>
            <input type="text" name="neighborhood" v-model="checkout.address.neighborhood" class="form-control"
                id="neighborhood" placeholder="Insira o seu bairro" required>
            <div class="invalid-feedback">
                Por favor insira o seu bairro.
            </div>
        </div>
    </div>

    <div class="row mb-2">
        <div class="col-sm-12 col-md-7">
            <label for="city">Cidade</label>
            <input type="text" name="city" v-model="checkout.address.city" class="form-control" id="city"
                placeholder="Insira a sua cidade" required>
            <div class="invalid-feedback">
                Por favor insira a sua cidade.
            </div>
        </div>
        <div class="col">
            <label for="state">Estado</label>
            <select name="state" v-model="checkout.address.state" class="form-select" id="state" required>
                <option v-for="uf in uf" :key="uf">{{ uf }}</option>
            </select>
            <div class="invalid-feedback">
                Por favor insira o seu estado.
            </div>
        </div>
    </div>

    <div class="row mb-2">
        <div class="col">
            <label for="complement">Complemento (se houver)</label>
            <input type="text" name="complement" v-model="checkout.address.complement" class="form-control" id="complement"
                placeholder="Insira o complemento">
            <div class="invalid-feedback">
                Por favor insira o complemento.
            </div>
        </div>
    </div>

</template>