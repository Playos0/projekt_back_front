<script setup lang="ts">
import { useCartStore } from "~/stores/cart";
import { ref, computed } from "vue";
const cart = useCartStore();
const { data: promotionSlides } = await useFetch("/api/promotionSlides");
const config = useRuntimeConfig()

interface Product {
  id: number
  name: string
  description: string
  category: string
  imageUrl: string
  stock: number
  price: number
}

const { data: Products } = await useFetch<Product[]>(`${config.public.apiBase}/Product/GetAllProducts`)
const currentPage = ref(1);
const itemsPerPage = 6;
const maxPage = ref(4);
const paginatedGrids = computed(() => {
  const start = (currentPage.value - 1) * itemsPerPage;
  return Products.value?.slice(start, start + itemsPerPage) || [];
});
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
      <v-col v-for="grid in paginatedGrids" :key="grid.id" cols="12" md="4">
        <v-card :to="'/product/' + grid.id" class="mx-auto" max-width="400">
          <v-img :src="`/images/${grid.imageUrl}`" height="200px"></v-img>
          <v-card-title class="title-wrap">{{ grid.name }}</v-card-title>
          <v-card-subtitle class="desc-wrap">{{
            grid.description
          }}</v-card-subtitle>
          <v-card-text class="mt-2 text-h6 font-weight-bold text-red">
            {{ grid.price }} zł
          </v-card-text>
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
  <v-pagination
    v-model="currentPage"
    :length="maxPage"
  ></v-pagination>
  <v-container class="about-section mb-16 mt-16 py-10">
    <h2 class="text-center font-weight-bold mt-12">
      Dlaczego warto u nas kupować?
    </h2>
    <p
      class="text-center text-white mb-16 mx-auto text-body-1"
      style="max-width: 900px"
    >
      Witaj w miejscu stworzonym przez wędkarzy dla wędkarzy. Nasz portal to nie tylko sklep 
  z niezawodnym sprzętem, ale również kompendium wiedzy o gatunkach ryb i interaktywna baza 
  najlepszych łowisk. Niezależnie od tego, czy dopiero zaczynasz swoją przygodę z wędką, 
  czy walczysz o kolejne życiowe rekordy - dostarczymy Ci wszystko, czego potrzebujesz, 
  aby każda wyprawa nad wodę zakończyła się pełnym sukcesem.
    </p>
    <v-row class="mt-4">
      <v-col cols="12" md="4" class="text-center">
        <v-icon size="64" color="orange-darken-3">mdi-truck-fast</v-icon>
        <h3 class="mt-4 font-weight-bold">Szybka dostawa</h3>
        <p>Realizujemy zamówienia w ciągu 24 godzin.</p>
      </v-col>
      <v-col cols="12" md="4" class="text-center">
        <v-icon size="64" color="orange-darken-3">mdi-cash-multiple</v-icon>
        <h3 class="mt-4 font-weight-bold">Atrakcyjne ceny</h3>
        <p>Oferujemy konkurencyjne ceny na wszystkie produkty.</p>
      </v-col>
      <v-col cols="12" md="4" class="text-center">
        <v-icon size="64" color="orange-darken-3">mdi-headset</v-icon>
        <h3 class="mt-4 font-weight-bold">Profesjonalna obsługa</h3>
        <p>Nasz zespół jest zawsze gotowy do pomocy.</p>
      </v-col>
    </v-row>
    <v-col cols="12" md="4" class="text-center">
      <NuxtLink to="/contact">
        <Icon icon="mdi:phone-in-talk" />
        Czytaj więcej o naszym sklepie
      </NuxtLink>
    </v-col>
  </v-container>
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
.about-section {
  background-image:
    linear-gradient(rgba(17, 20, 19, 0.85), rgba(17, 20, 19, 0.85)),
    url("/images/fishingBox.jpg");
  background-size: cover;
  background-position: center;
  background-attachment: fixed;
  color: white;
}
.about-section h3 {
  color: white;
}
.about-section p {
  color: white;
}
</style>
