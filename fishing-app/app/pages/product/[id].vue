<script setup lang="ts">
import { useRoute } from 'vue-router'
import { useCartStore } from '~/stores/cart'
import { ref, computed } from 'vue'
const cart = useCartStore()
const route = useRoute()
const productId = route.params.id
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
const product = computed(() => {
  if (!Products.value) return null
  return Products.value.find((item: any) => item.id == productId)
})
const quantity = ref(1)
</script>

<template>
  <v-container class="mt-8 mb-16">
    <div v-if="product">
      <nav class="mb-8 text-grey">
        <NuxtLink to="/" class="text-grey text-decoration-none">Strona główna</NuxtLink>
        >
        {{ product.name }}
      </nav>

      <v-row>
        <v-col cols="12" md="6">
          <v-card class="rounded-xl">
            <v-img :src="`/images/${product.imageUrl}`" height="500" contain></v-img>
          </v-card>
        </v-col>

        <v-col cols="12" md="6" class="md-10">
          <h1 class="text-h3 font-weight-bold mb-4">{{ product.name }}</h1>

          <v-divider class="mb-6"></v-divider>

          <div class="text-h3 font-weight-bold text-orange-darken-3 mb-6">{{ product.price }} zł</div>

          <p class="text-body-1 mb-8 text-grey-darken-3" style="line-height: 1.8">
            {{ product.description }}
          </p>

          <div class="d-flex mb-8" style="gap: 16px">
            <v-text-field
              v-model.number="quantity"
              type="number"
              label="Ilość"
              variant="outlined"
              style="max-width: 120px"
              min="1"
            ></v-text-field>

            <v-btn
              color="orange-darken-3"
              size="x-large"
              variant="elevated"
              prepend-icon="mdi-cart-plus"
              @click="cart.addItem(product, quantity)"
              class="flex-grow-1"
            >
              DO KOSZYKA
            </v-btn>
          </div>
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<style scoped></style>
