<script setup>
import { useAuthStore } from '@/stores/auth';
import { reactive, ref } from 'vue';
import { useRouter } from "vue-router";
const router = useRouter();
const auth = useAuthStore();

defineProps({
    steps: Number
})

const nextStep = (steps) => {
    const form = document.querySelector(`#step-${currentStep.value}>form`);
    if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
    }

    getFormData(form);

    if (currentStep.value == 2) {
        // auth.
        console.log(data);
    }

    if (currentStep.value < steps) {
        currentStep.value++;
        return;
    }

    router.push("/success");
}

const data = reactive({});

const getFormData = (form) => {
    let formData = new FormData(form);

    for (const [key, value] of formData.entries()) {
        data[key] = value;
    }
}

const submitForm = () => {
    auth.addPurchase(data);
    router.push("/success");
}

const currentStep = ref(1);
</script>

<template>
    <slot name="progress">
        {{ currentStep }} / {{ steps }} steps
        <div class="progress mb-3">
            <div class="progress-bar progress-bar-striped progress-bar-animated" aria-valuenow="75"
                aria-valuemin="0" aria-valuemax="100" :style="`width: ${(currentStep) / steps * 100}%`"></div>
        </div>
    </slot>
    <div v-for="(step, index) in steps" :key="index" :id="`step-${index + 1}`" v-show="index === currentStep - 1">
        <form @submit.prevent="nextStep(steps)" novalidate>
            <slot class="mb-3" :name="`step-${index + 1}`"></slot>
            <slot class="mb-3" name="buttons col mt-4">
                <button class="btn me-2 mt-2 btn-secondary" v-if="currentStep > 1" type="button"
                    @click="currentStep--">Back</button>
                <button class="btn mt-2 btn-primary" v-if="currentStep < steps" type="submit">Next</button>
                <button class="btn mt-2 btn-success" v-else type="submit">Submit</button>
            </slot>
        </form>
    </div>
</template>