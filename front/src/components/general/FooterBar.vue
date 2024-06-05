<template>
    <footer class="mx-2 pt-4 mt-5 border-top">
        <div class="row">
            <div class="description col-sm-12 col-md-6 mb-3">
                <div class="brand">
                    <h1 class="fs-4">[AWESOME STORE]</h1>
                </div>
                <p class="mt-3 pe-5 ">Descubra os produtos mais incríveis com nós. Descubra as tendências mais recentes
                    e
                    se mantenha à frente do jogo.
                    Estamos comprometidos em trazer os melhores para você. Venha conosco nessa incrível jornada!
                </p>
            </div>
            <div class="links col">
                <div class="row">
                    <div class="useful col">
                        <h3 class="fs-5 fw-bold">Links Uteis</h3>
                        <ul class="list-unstyled">
                            <li><a class="text-decoration-none" href="#">Home</a></li>
                            <li><a class="text-decoration-none" href="#">Sobre</a></li>
                            <li><a class="text-decoration-none" href="#">Produtos</a></li>
                            <li><a class="text-decoration-none" href="#">Contato</a></li>
                        </ul>
                    </div>

                    <div class="social col">
                        <h3 class="fs-5 fw-bold">Redes Sociais</h3>
                        <ul class="list-unstyled">
                            <li><a class="text-decoration-none" href="#">
                                    <i class='bx bxl-facebook'></i>
                                    Facebook</a>
                            </li>
                            <li><a class="text-decoration-none" href="#">
                                    <i class='bx bxl-twitter'></i>
                                    Twitter
                                </a>
                            </li>
                            <li><a class="text-decoration-none" href="#">
                                    <i class='bx bxl-instagram'></i>
                                    Instagram
                                </a>
                            </li>
                            <li><a class="text-decoration-none" href="#">
                                    <i class='bx bxl-linkedin'></i>
                                    LinkedIn
                                </a>
                            </li>
                        </ul>
                    </div>

                    <div class="social col-md-6 col-sm-12">
                        <h3 class="fs-5 fw-bold">Fale conosco</h3>
                        <ul class="list-unstyled">
                            <li><a class="text-decoration-none" href="#">Telefone: 123-456-7890</a></li>
                            <li><a class="text-decoration-none" href="#">Email: awesomestore@email.com</a>
                            </li>
                            <li><a class="text-decoration-none" href="#">Endereço: endereço maneiro
                                    aqui</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-3 border-top pt-3">
            <div class="col">
                <p class="text-center">
                    Copyright © {{ new Date().getFullYear() }} [AWESOME STORE]. Todos os direitos
                    reservados.
                </p>
            </div>
        </div>
    </footer>
</template>

<style scoped>
a {
    color: var(--color-text);
}

footer {
    overflow-x: hidden;
}
</style>