<template>
  <div>
    <h1>Fishing Grounds</h1>
    <p v-if="pending">Loading...</p>
    <p v-else-if="error">siemaError: {{ error }}</p>
    <div v-else>
      <GroundCard
        v-for="ground in grounds"
        :key="ground.id"
        :name="ground.name"
        :price="ground.price"
      >
        <button @click="cart.addItem(ground)">Dodaj do koszyka</button>
      </GroundCard>
    </div>
  </div>
</template>

<script setup lang="ts">
import GroundCard from "~/components/GroundCard.vue";
import { useCartStore } from "~/stores/cart";
const cart = useCartStore();

interface Ground {
  id: number;
  name: string;
  price: number;
}

const {
  data: grounds,
  pending,
  error,
} = await useFetch<Ground[]>("/api/grounds");
</script>
