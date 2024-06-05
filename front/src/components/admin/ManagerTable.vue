<script setup>
defineProps({
    columns: Array,
    rows: Object
})

</script>

<template>
    <table>
        <thead>
            <th v-for="column in columns">
                {{ column }}
            </th>
        </thead>
    </table>
</template>