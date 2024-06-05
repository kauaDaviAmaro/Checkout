<script setup>
import { reactive, ref } from 'vue';
import { useAuthStore } from '@/stores/auth';
import { useAlertStore } from '@/stores/alert';
import UserDataService from '@/service/userDataService';
import Loading from '@/components/shared/Loading.vue';

const auth = useAuthStore();

const user = reactive(auth.user);

const loading = ref(false);

const alert = useAlertStore();

const onSubmit = async () => {
    loading.value = true;
    await UserDataService.updateUser(user).then((response) => {
        if (response.status === 200) {
            alert.successAlert('Usuário atualizado com sucesso!');
            auth.setUser(user);
            return;
        }
        alert.errorAlert('Erro ao atualizar usuário!');
    }).catch((error) => {
        alert.errorAlert('Erro ao atualizar usuário!');
    });
    loading.value = false;
}
</script>

<template>
    <Loading v-if="loading" />
    <div class="container">
        <div class="row">
            <div class="col-3 border-end fs-5">
                <div class="m-2 my-4">
                    <RouterLink to="/profile"
                        class="d-inline-block text-decoration-none bg-primary text-white p-2 w-100 rounded">
                        <i class='bx bx-user'></i>
                        Meu Perfil
                    </RouterLink>
                </div>
                <div class="m-2 ">
                    <RouterLink to="/orders"
                        class="d-inline-block text-decoration-none bg-primary text-white p-2 w-100 rounded">
                        <i class='bx bx-shopping-bag'></i>
                        Meus Pedidos
                    </RouterLink>
                </div>
            </div>
            <div class="col m-2">
                <div class="row">
                    <div class="col">
                        <h1>Meu perfil</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="container">
                        <form @submit.prevent="onSubmit">
                            <h2>Informações pessoais</h2>
                            <div class="row">
                                <div class="col">
                                    <label for="firstName">Primeiro nome</label>
                                    <input type="text" name="firstName" class="form-control" required
                                        placeholder="Insira seu primeiro nome" v-model="user.firstName">
                                </div>
                                <div class="col">
                                    <label for="lastName">Último nome</label>
                                    <input type="text" name="lastName" class="form-control" required
                                        placeholder="Insira seu último nome" v-model="user.lastName">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label for="email">Email</label>
                                    <input type="email" name="email" class="form-control" required
                                        placeholder="Insira seu email" v-model="user.email">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label for="phone">Celular</label>
                                    <input type="text" name="phone" class="form-control"
                                        placeholder="Insira seu celular" v-model="user.phone">
                                </div>
                                <div class="col">
                                    <label for="cpf">CPF</label>
                                    <input type="text" name="cpf" class="form-control" placeholder="Insira o seu CPF"
                                        v-model="user.cpf">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <button type="submit" class="btn btn-primary float-end mt-3">Atualizar</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="row">
                    <div class="container">
                        <form>
                            <h2>Endereço</h2>
                            <div class="row">
                                <div class="col">
                                    <label for="street">Rua</label>
                                    <input type="text" name="street" class="form-control" placeholder="[Rua]">
                                </div>
                                <div class="col">
                                    <label for="number">Número</label>
                                    <input type="text" name="number" class="form-control" placeholder="[Número]">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label for="complement">Complemento (opcional)</label>
                                    <input type="text" name="complement" class="form-control"
                                        placeholder="[Complemento]">
                                </div>
                                <div class="col">
                                    <label for="neighborhood">Bairro</label>
                                    <input type="text" name="neighborhood" class="form-control" placeholder="[Bairro]">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label for="city">Cidade</label>
                                    <input type="text" name="city" class="form-control" placeholder="[Cidade]">
                                </div>
                                <div class="col">
                                    <label for="state">Estado</label>
                                    <input type="text" name="state" class="form-control" placeholder="[Estado]">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <button type="submit" class="btn btn-primary float-end mt-3">Atualizar</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="row">
                    <div class="container">
                        <form>
                            <h2>Informações de acesso</h2>
                            <div class="row">
                                <div class="col">
                                    <label for="password">Nova senha</label>
                                    <input type="password" name="password" class="form-control" placeholder="[Senha]">
                                </div>
                                <div class="col">
                                    <label for="confirmPassword">Confirmar a nova senha</label>
                                    <input type="password" name="confirmPassword" class="form-control"
                                        placeholder="[Confirmar senha]">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <button type="submit" class="btn btn-primary float-end mt-3">Atualizar</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>