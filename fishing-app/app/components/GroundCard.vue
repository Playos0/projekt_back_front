<script setup lang="ts">
import { useCartStore } from '~/stores/cart'
import { LMap, LTileLayer, LMarker } from '@vue-leaflet/vue-leaflet'
const cart = useCartStore()
const config = useRuntimeConfig()

interface Ground {
  id: number
  name: string
  description: string
  location: string
  subscriptionAvailable: boolean
  dayPassPrice: number
  latitude: number
  longitude: number
}

const { data: Grounds } = await useFetch<Ground[]>(`${config.public.apiBase}/fishingspots/all`)
</script>

<template>
  <v-container fluid class="mt-8 mb-16">
    <h2 class="text-center font-weight-bold">Dostępne łowiska</h2>
    <v-row>
      <v-col v-for="ground in Grounds" :key="ground.id" cols="12">
        <v-card>
          <v-row>
            <v-col cols="12" md="7" class="pa-6">
              <v-card-title class="text-h4 font-weight-bold px-0">
                {{ ground.name }}
              </v-card-title>
              <v-card-subtitle class="text-h6 px-0 text-primary">
                <v-icon icon="mdi-map-marker" class="mr-1"></v-icon>
                {{ ground.location }}
              </v-card-subtitle>
              <v-card-text class="px-0 text-grey-darken-3">
                {{ ground.description }}
              </v-card-text>
              <div>
                <details class="bg-slate-100 p-4 rounded-lg cursor-pointer">
                  <summary class="font-bold flex justify-between items-center">Rozwiń informacje o łowiskach</summary>
                  <p class="mt-2 text-gray-600">Cena za dzień: {{ ground.dayPassPrice }} zł</p>
                  <p class="mt-2 text-gray-600">
                    Dostępność subskrypcji: {{ ground.subscriptionAvailable ? 'Tak' : 'Nie' }}
                  </p>
                </details>
              </div>
              <v-card-actions>
                <v-btn
                  color="orange-darken-3"
                  size="x-large"
                  variant="elevated"
                  prepend-icon="mdi-cart-plus"
                  @click="cart.addItem(ground)"
                >
                  Kup karnet
                </v-btn>
              </v-card-actions>
            </v-col>
            <v-col cols="12" md="5">
              <ClientOnly>
                <div style="height: 100%; min-height: 300px; width: 100%; z-index: 1">
                  <l-map :zoom="13" :center="[ground.latitude, ground.longitude]" :use-global-leaflet="false">
                    <l-tile-layer
                      url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                      layer-type="base"
                      name="OpenStreetMap"
                    ></l-tile-layer>

                    <l-marker :lat-lng="[ground.latitude, ground.longitude]"></l-marker>
                  </l-map>
                </div>
              </ClientOnly>
            </v-col>
          </v-row>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<style scoped></style>
