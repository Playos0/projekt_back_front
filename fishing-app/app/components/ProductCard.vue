<script setup lang="ts">
import { useCartStore } from '~/stores/cart'
const cart = useCartStore()

defineProps({
  product: {
    type: Object,
    required: true,
  },
})
</script>

<template>
  <v-card :to="'/product/' + product.id" class="mx-auto" max-width="400">
    <v-img :src="`/images/${product.imageUrl}`" height="200px"></v-img>
    <v-card-title class="title-wrap">{{ product.name }}</v-card-title>
    <v-card-subtitle class="desc-wrap">{{ product.description }}</v-card-subtitle>
    <v-card-text class="mt-2 text-h6 font-weight-bold text-red"> {{ product.price }} zł </v-card-text>
    <v-card-actions class="px-0 pb-4">
      <v-btn
        color="orange-darken-3"
        variant="elevated"
        block
        prepend-icon="mdi-cart-plus"
        @click="cart.addItem(product)"
      >
        Do koszyka
      </v-btn> 
    </v-card-actions>
  </v-card>
</template>

<style scoped>
.title-wrap {
  white-space: normal;
  display: -webkit-box;
  line-clamp: 2;
  -webkit-box-orient: vertical;
  overflow: hidden;
  height: 64px;
}
.desc-wrap {
  white-space: normal;
  display: -webkit-box;
  line-clamp: 3;
  -webkit-box-orient: vertical;
  overflow: hidden;
  height: 60px;
}
</style>
