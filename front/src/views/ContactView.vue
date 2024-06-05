<script setup>
import { ref } from 'vue';
import { useAuthStore } from '@/stores/auth';
import Loading from '@/components/shared/Loading.vue';

const loading = ref(false);

const onSubmit = async (values) => {
    loading.value = true;
    const authStore = useAuthStore();
    authStore.returnPath = '/contact';
    await authStore.contact(values);
    loading.value = false;
}
</script>

<template>
    <Loading v-if="loading" />
    <div class="container mt-3">
        <div class="row column-gap-5 d-flex align-items-center">
            <div class="col-md-6 col-sm-12 mb-4" data-aos="fade-right" data-aos-duration="1000">
                <div class="row">
                    <h1>Fale conosco!</h1>
                    <p>Nós adoraríamos ouvir suas sugestões!</p>
                </div>
                <div class="row">
                    <div class="col">
                        <form @submit.prevent="onSubmit" novalidate >
                            <div class="mb-3">
                                <label for="name" class="form-label">Nome</label>
                                <input type="text" class="form-control" id="name" name="name" required
                                    placeholder="Insira seu nome" autocomplete="on">
                                <div class="invalid-feedback">
                                    Por favor, proporcione seu nome.
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="topic" class="form-label">Topic</label>
                                <input type="text" class="form-control" id="topic" name="topic" required
                                    placeholder="Insira seu tópico">
                                <div class="invalid-feedback">
                                    Por favor, proporcione um tópico.
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="email" class="form-label">Email</label>
                                <input type="email" class="form-control" id="email" name="email" required
                                    placeholder="Insira seu email" autocomplete="on">
                                <div class="invalid-feedback">
                                    Por favor, proporcione seu email.
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="message" class="form-label">Mensagem</label>
                                <textarea class="form-control" id="message" rows="3" name="message" required
                                    placeholder="Por favor nos diga sua sugestão"></textarea>
                                <div class="invalid-feedback">
                                    Por favor, insira sua sugestão.
                                </div>
                            </div>
                            <button type="submit" class="btn btn-primary">Concluir sua mensagem</button>
                        </form>
                    </div>
                </div>
            </div>
            <div class="col mx-3 shadow-sm" data-aos="fade-left" data-aos-duration="1000">
                <div class="row">
                    <div class="card rounded mb-3">
                        <div class="row">
                            <div class="col">
                                <div class="card-body">
                                    <h5 class="card-title">
                                        <i class="bx bx-chat pe-2"></i> Mergulhe nos seus pensamentos e ideias
                                    </h5>
                                    <p class="card-text">
                                        Você possui dúvidas, ideias ou algo que deseja compartilhar? Nos diga seus pensamentos que adoraríamos escustar. 
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card rounded mb-3">
                        <div class="row">
                            <div class="col">
                                <div class="card-body">
                                    <h5 class="card-title">
                                        <i class="bx bx-bulb pe-2"></i> Junte-se ao nosso time
                                    </h5>
                                    <p class="card-text">
                                        Nós somos um time de mentes inovadoras que sempre busca inovar e novos talentos. Venha, nos contate, vamos explorar todas as possibilidades juntos. 
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card rounded">
                        <div class="row">
                            <div class="col">
                                <div class="card-body">
                                    <h5 class="card-title">
                                        <i class="bx bx-support pe-2"></i>Suporte e manutenção
                                    </h5>
                                    <p class="card-text">
                                        Nós estamos aqui para te ajudar com qualquer dúvida ou problema que você possa ter. Nós desejamos sempre vender e dar suporte aos nossos clientes da melhor forma possível, 
                                        sempre buscando o melhor tratamento.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>