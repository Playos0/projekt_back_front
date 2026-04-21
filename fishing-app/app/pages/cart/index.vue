<template>
  <h1>Koszyk</h1>
  <p>Twoja lista produktów w koszyku.</p>
  <div v-if="cart.items.length === 0">
    <p>Koszyk jest pusty.</p>
  </div>
    <div v-else>
        <ul>
        <li v-for="item in cart.items" :key="item.id">
            {{ item.name }} - {{ item.price }} PLN
            <button @click="cart.removeItem(item.id)">Usuń</button>
        </li>
        </ul>
        <p>Łączna cena: {{ cart.totalPrice }} PLN</p>
    </div>
</template>

<script setup lang="ts">
import { useCartStore } from "@/stores/cart";
const cart = useCartStore();
</script>
