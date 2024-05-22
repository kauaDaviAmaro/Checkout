<script setup>
import { ref } from 'vue';
import { useAuthStore } from '@/stores/auth';
import Loading from '@/components/Loading.vue';

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
                    <h1>Speak to us!</h1>
                    <p>We'd love to hear from you!</p>
                </div>
                <div class="row">
                    <div class="col">
                        <form @submit.prevent="onSubmit" novalidate>
                            <div class="mb-3">
                                <label for="name" class="form-label">Name</label>
                                <input type="text" class="form-control" id="name" name="name" required
                                    placeholder="Input your name">
                                <div class="invalid-feedback">
                                    Please provide a valid name.
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="topic" class="form-label">Topic</label>
                                <input type="text" class="form-control" id="topic" name="topic" required
                                    placeholder="Input your topic">
                                <div class="invalid-feedback">
                                    Please provide a valid topic.
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="email" class="form-label">Email</label>
                                <input type="email" class="form-control" id="email" name="email" required
                                    placeholder="Input your email">
                                <div class="invalid-feedback">
                                    Please provide a valid email.
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="message" class="form-label">Message</label>
                                <textarea class="form-control" id="message" rows="3" name="message" required
                                    placeholder="Input your message"></textarea>
                                <div class="invalid-feedback">
                                    Please provide a valid message.
                                </div>
                            </div>
                            <button type="submit" class="btn btn-primary">Send your message</button>
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
                                        <i class="bx bx-chat pe-2"></i> Dive into the depths of our
                                        mind
                                    </h5>
                                    <p class="card-text">Do you have a question, an idea, or just want to share your
                                        thoughts? We're here to listen.</p>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card rounded mb-3">
                        <div class="row">
                            <div class="col">
                                <div class="card-body">
                                    <h5 class="card-title">
                                        <i class="bx bx-bulb pe-2"></i> Join our team
                                    </h5>
                                    <p class="card-text">We're a team of innovative minds that are passionate about
                                        creating something amazing. Let's get in touch and explore the possibilities
                                        together.</p>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card rounded">
                        <div class="row">
                            <div class="col">
                                <div class="card-body">
                                    <h5 class="card-title">
                                        <i class="bx bx-support pe-2"></i>Support and maintenance
                                    </h5>
                                    <p class="card-text">We're here to help you with any questions or issues you may
                                        have. We're passionate about creating great products and we're here to support
                                        you every step of the way.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>