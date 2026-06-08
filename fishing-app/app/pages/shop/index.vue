<script setup lang="ts">
import { useRoute, useRouter } from 'vue-router'
import { computed, ref } from 'vue'

const route = useRoute()
const router = useRouter()
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

const page = ref(1)
const itemsPerPage = 12

const categories = computed(() => {
  if (!Products.value) return []
  const allCategories = Products.value.map((p) => p.category)
  return ['Wszystkie', ...new Set(allCategories)]
})

const selectedCategory = computed(() => route.query.category || 'Wszystkie')

function setCategory(cat: string) {
  page.value = 1
  if (cat === 'Wszystkie') {
    router.push('/shop')
  } else {
    router.push({ path: '/shop', query: { category: cat } })
  }
}

const filteredProducts = computed(() => {
  if (!Products.value) return []
  let filtered = Products.value

  if (selectedCategory.value !== 'Wszystkie') {
    filtered = filtered.filter((item) => item.category === selectedCategory.value)
  }
  return filtered
})

const totalPages = computed(() => Math.ceil(filteredProducts.value.length / itemsPerPage))

const paginatedProducts = computed(() => {
  const start = (page.value - 1) * itemsPerPage
  const end = start + itemsPerPage
  return filteredProducts.value.slice(start, end)
})
</script>

<template>
  <v-container fluid class="mt-8 mb-16">
    <v-row>
      <v-col cols="12" md="3">
        <v-card class="pa-4 rounded-xl">
          <h3 class="text-h6 font-weight-bold mb-4">Kategorie</h3>
          <v-list>
            <v-list-item
              v-for="cat in categories"
              :key="cat"
              @click="setCategory(cat)"
              :active="selectedCategory === cat"
            >
              <v-list-item-title>{{ cat }}</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-card>
      </v-col>
      <v-col cols="12" md="9">
        <h1 class="text-h3 font-weight-bold mb-8">
          {{ selectedCategory === 'Wszystkie' ? 'Wszystkie produkty' : `Kategoria: ${selectedCategory}` }}
        </h1>
        <v-row v-if="paginatedProducts && paginatedProducts.length > 0">
          <v-col v-for="product in paginatedProducts" :key="product.id" cols="12" sm="6" md="4">
            <ProductCard :product="product" />
          </v-col>
        </v-row>
          <v-pagination v-model="page" :length="totalPages"></v-pagination>
      </v-col>
    </v-row>
  </v-container>
</template>
