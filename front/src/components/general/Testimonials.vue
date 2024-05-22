<script setup>
import TestimonialsCard from '@/components/general/TestimonialsCard.vue';
import { Swiper, SwiperSlide } from 'swiper/vue';
import { EffectCoverflow } from 'swiper/modules';
import 'swiper/css/effect-coverflow';
import 'swiper/css';

</script>

<template>
    <div class="testimonials">
        <swiper :effect="'coverflow'" :grabCursor="true" :centeredSlides="true" :slidesPerView="1" :loop="true"
            :coverflowEffect="{
                rotate: 10,
                stretch: 0,
                depth: 100,
                modifier: 1,
            }" :modules="[EffectCoverflow]" :breakpoints="{
                1200: {
                    slidesPerView: 3,
                },
                992: {
                    slidesPerView: 2,
                },
                768: {
                    slidesPerView: 1,
                },
            }">
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 5, name: 'John Doe', review: 'I love this product', date: 'January 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 4, name: 'Jane Smith', review: 'I enjoy using this product', date: 'February 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 5, name: 'Bob Johnson', review: 'I really appreciate this product', date: 'March 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 5, name: 'John Doe', review: 'I love this product', date: 'January 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 4, name: 'Jane Smith', review: 'I enjoy using this product', date: 'February 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 5, name: 'Bob Johnson', review: 'I really appreciate this product', date: 'March 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 3, name: 'Alice Brown', review: 'The product is good but could be improved', date: 'April 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 5, name: 'Chris Green', review: 'Outstanding quality and service', date: 'May 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 4, name: 'Diana White', review: 'Very satisfied with the product', date: 'June 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 5, name: 'Evan Black', review: 'Exceeded my expectations', date: 'July 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 4, name: 'Fiona Blue', review: 'Good value for the price', date: 'August 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 5, name: 'George King', review: 'Highly recommend this product', date: 'September 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 3, name: 'Hannah Queen', review: 'It meets my needs', date: 'October 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 5, name: 'Ian Knight', review: 'Fantastic! Will buy again', date: 'November 1, 2020' }" />
            </swiper-slide>
            <swiper-slide>
                <TestimonialsCard
                    :review="{ rating: 4, name: 'Jenny Scott', review: 'Great product, will recommend', date: 'December 1, 2020' }" />
            </swiper-slide>

        </swiper>
    </div>
</template>

<style scoped></style>