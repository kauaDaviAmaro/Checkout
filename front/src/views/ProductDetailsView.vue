<script setup>
import { useProductsStore } from '@/stores/products';
import { onMounted, reactive, ref } from 'vue';
import { useRoute } from 'vue-router';
import { formatPrice } from '@/assets/js/helpers';
import { isInCart } from '@/assets/js/helpers';
import Loading from '@/components/Loading.vue';

const productsStore = useProductsStore();
const id = ref(useRoute().params.id);
const product = ref({});

const imageSelected = ref();

const fillStars = ref(0);
const halfStar = ref();
const emptyStars = ref();

const selectImage = (image) => {
    imageSelected.value = image;
}


const loading = ref(false);

onMounted(async () => {
    loading.value = true;
    product.value = await productsStore.getProductById(id.value);
    fillStars.value = Math.floor(product.value.rating);
    halfStar.value = Math.floor(product.value.rating) < product.value.rating;
    emptyStars.value = 5 - Math.ceil(product.value.rating);
    imageSelected.value = product.value.images[0];
    loading.value = false;
});


const quantity = ref(1);
</script>

<template>
    <Loading v-if="loading" />
    <div class="container" v-else data-aos="fade-up" data-aos-duration="1000">
        <div class="row">
            <div class="col-sm-12 col-md-6 ">
                <div class="image-selected row my-2">
                    <img class="rounded" :src="imageSelected" :alt="product.title">
                </div>
                <div class="images row">
                    <div class="col" v-for="image in product.images" :key="image"
                        @click="selectImage(imageSelected = image)">
                        <img class="w-100 p-2 border rounded" :src="image" :alt="product.title" />
                    </div>
                </div>
            </div>
            <div class="col px-4">
                <div class="d-flex justify-content-between align-items-center">
                    <h1>{{ product.title }}</h1>
                    <h1>{{ formatPrice(product.price) }}</h1>
                </div>
                <div class="rating">
                    <i class="bx bxs-star text-warning" v-for="star in fillStars" :key="'full-' + star"></i>
                    <i class="bx bxs-star-half text-warning" v-if="halfStar"></i>
                    <i class="bx bx-star text-muted" v-if="emptyStars > 0" v-for="star in emptyStars"
                        :key="'empty-' + star"></i>
                    <span>({{ product.rating }})</span>
                </div>

                <div class="status mt-2 mb-3 text-muted">
                    <div v-if="product.stock > 0">
                        <span>In stock: </span><span>{{ product.stock }}</span>
                    </div>
                    <div v-else>
                        <span class="text-danger">Out of stock</span>
                    </div>
                </div>
                <div class="row border-bottom my-4">
                    <p>{{ product.description }}</p>
                </div>
                <div class="row my-4">
                    <!-- <div class="col-2">
                        <input type="number"  v-model.number="quantity" class="form-control" value="1">
                    </div> -->
                    <div class="col">
                        <button
                            @click="isInCart(product) ? productsStore.removeFromCart(product) : productsStore.addToCart(product)"
                            :class="isInCart(product) ? 'btn-danger' : 'btn-primary'" class="btn btn-primary w-100">
                            {{ isInCart(product) ? 'Remove from cart' : 'Add to cart' }}
                        </button>
                    </div>
                </div>
                <div class="row border-top py-3">
                    <div class="col">
                        <h5>Category:</h5>
                        <span class="me-2 text-muted">
                            {{ product.category }}
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
.badge {
    width: fit-content;
}

.image-selected {

    & img {
        -webkit-user-drag: none;
        max-height: 650px;
        min-height: 650px;
        object-fit: contain;
    }
}

.images {
    & img {
        -webkit-user-drag: none;
        cursor: pointer;
        max-height: 100px;
        min-height: 100px;
        object-fit: contain;
    }

    & .col {
        max-height: 100px;
        min-height: 100px;
    }
}

@media (max-width: 768px) {
    .image-selected {
        & img {
            max-height: 300px;
            min-height: 300px;
        }
    }

    .images {
        & img {
            max-height: 50px;
            min-height: 50px;
        }
    }

}
</style>