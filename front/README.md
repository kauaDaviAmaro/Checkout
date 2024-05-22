# Detalhes do projeto
## Instituição: Unimar
## Integrantes:
- Kauã Davi Amaro Mauro RA 1963968
- Leonardo Yuiti Nakamura RA 1975660

# checkout demo

Este é um aplicativo simples e experimental de checkout construído com Vue.js. Ele permite que você adicione produtos a um carrinho de compras e depois prossiga para o checkout. É um projeto de demonstração e não possui integração real com um gateway de pagamento.

O aplicativo é construído com Vue.js, Vuex, Vue Router, Bootstrap e usa o Pinia para gerenciamento de estado.

Os dados utilizados nessa demonstração são da api dummyJSON - [dummyJSON](https://dummyjson.com/docs/products)

## Demonstração

Você pode encontrar uma demonstração ao vivo do aplicativo aqui: [checkout demo](https://kauadaviamaro.github.io)

## Screenshots do Projeto

![Catalogo de Produtos](screenshots/Catalog.PNG)

Tela mostrando o catálogo com os produtos da API

![Carrinho de Compras](screenshots/shoppingCart.PNG)

Tela com o carrinho de compras com alguns produtos

![Checkout](screenshots/checkout1.PNG)

Tela com o primeiro passo do formulário de checkout 

![Checkout](screenshots/checkout2.PNG)

Tela com o segundo passo do formulário de checkout 

![Checkout](screenshots/checkout3.PNG)

Tela com o terceiro passo do formulário de checkout 

![Carrinho vazio](screenshots/empty.PNG)

Tela mostrando quando entrar em um carrinho vazio

![Tela de Obrigado](screenshots/thanks.PNG)

Tela agradecendo o usuário pela compra

# Funcionalidades 

* Visualizar catalogo de produtos
* Adicionar produtos ao carrinho de compras
* Exibir produtos e quantidade no carrinho de compras
* Remover produtos do carrinho de compras
* Exibir detalhes do produto selecionado no carrinho de compras
* Prosseguir para o checkout e finalizar a compra
* Exibir mensagem de obrigado após finalizar a compra


## Configuração do Projeto

```sh
npm install
```

### Compilar e recarregar automaticamente para Desenvolvimento

```sh
npm run dev
```

### Compilar e Minificar para Produção

```sh
npm run build
```
