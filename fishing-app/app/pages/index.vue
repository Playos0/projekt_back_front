<script setup lang="ts">
import { useCartStore } from "~/stores/cart";
const cart = useCartStore();
const { data: promotionSlides } = await useFetch("/api/promotionSlides");
const { data: promotionGrids } = await useFetch("/api/promotionGrids");
</script>

<template>
  <v-container class="mt-8">
    <v-carousel
      v-if="promotionSlides"
      show-arrows="hover"
      hide-delimiter-background
      class="rounded-xl shadow-lg"
    >
      <v-carousel-item
        v-for="slide in promotionSlides"
        :src="slide.src"
        cover
      ></v-carousel-item>
    </v-carousel>
  </v-container>

  <v-container class="mt-8">
    <h2 class="text-center font-weight-bold">Polecane produkty</h2>
    <v-row>
      <v-col v-for="grid in promotionGrids" :key="grid.id" cols="12" md="4">
        <v-card class="mx-auto" max-width="400">
          <v-img :src="grid.image" height="200px"></v-img>
          <v-card-title>{{ grid.name }}</v-card-title>
          <v-card-subtitle>{{ grid.description }}</v-card-subtitle>
          <v-card-price class="mt-2">{{ grid.price }} zł</v-card-price>
          <v-card-actions class="px-0 pb-4">
            <v-btn
              color="orange-darken-3"
              variant="elevated"
              block
              prepend-icon="mdi-cart-plus"
              @click="cart.addItem(grid)"
            >
              Do koszyka
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
  <v-pagination :length="4"></v-pagination>
</template>

<style scoped></style>
