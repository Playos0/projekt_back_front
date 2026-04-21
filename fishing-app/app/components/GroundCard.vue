<template>
    <div class="card">
        <h2>{{ name }}</h2>
        <p>{{ price }} zł</p>
        <slot/>
    </div>
</template>

<script setup lang="ts">
defineProps<{
    name: string;
    price: number;
}>();
</script>

<style scoped>
.card {
    border: 1px solid #433c8728;
    padding: 16px;
    border-radius: 8px;
    margin: 16px;
    text-align: center;
}
</style>