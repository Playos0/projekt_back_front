<script setup lang="ts">
import { computed } from 'vue'
import { useCartStore } from '~/stores/cart'

const cart = useCartStore()
const config = useRuntimeConfig()

// categories
const regularProducts = computed(() => cart.items.filter(item => item.category === 'Wędki' || !item.category))
const subscriptions = computed(() => cart.items.filter(item => item.category === 'subscription' || item.subscriptionAvailable === true))
const memberships = computed(() => cart.items.filter(item => item.category === 'membership'))

const handleCheckout = async () => {
  if (cart.items.length === 0) {
    alert("Koszyk jest pusty!")
    return
  }

  //tokens
  const getCookie = (name: string) => {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop()?.split(';').shift();
  }

  const token = getCookie('auth_token');

  if (!token) {
    alert("order made");
    return;
  }

  const formattedItems = cart.items.map(item => ({
    productId: item.id,       
    quantity: item.quantity   
  }))

  const payload = {
    items: formattedItems
  }

  try {
    // 2. STRZAŁ Z NAGŁÓWKIEM AUTORYZACJI
    // Adres '.../api/Order' jest poprawny (bo apiBase kończy się na /api)
    await $fetch(`${config.public.apiBase}/Order`, {
      method: 'POST',
      headers: {
        'Authorization': `Bearer ${token}`, 
        'Content-Type': 'application/json'
      },
      body: payload
    })

    alert("Orders made successfully!")
    cart.items = [] 

  } catch (error: any) {
    console.error("Szczegóły błędu:", error)
    if (error.response?.status === 401) {
      alert("error 401")
    } else {
      alert("something went wrong with your order. Please try again later.")
    }
  }
}
</script>

<template>
  <v-container class="py-8">
    <h1 class="text-h4 font-weight-bold mb-6">Twój Koszyk</h1>

    <v-row v-if="cart.items.length === 0" justify="center" class="mt-8">
      <v-col cols="12" md="6" class="text-center">
        <v-sheet class="pa-12 rounded-lg border-thin text-center" elevation="1">
          <v-icon icon="mdi-cart-outline" size="80" color="grey-lighten-1" class="mb-4"></v-icon>
          <h2 class="text-h5 font-weight-medium mb-2">Twój koszyk jest pusty</h2>
          <v-btn to="/shop" color="primary" class="mt-4" prepend-icon="mdi-arrow-left">
            Wróć do sklepu
          </v-btn>
        </v-sheet>
      </v-col>
    </v-row>

    <v-row v-else spacing="6">
      
      <v-col cols="12" lg="8">
        <div class="d-flex flex-column gap-6">
          
          <v-card v-if="regularProducts.length > 0" class="border-thin rounded-lg" elevation="0">
            <v-card-item class="bg-blue-grey-lighten-5 py-3">
              <v-card-title class="text-subtitle-1 font-weight-bold d-flex align-center">
                <v-icon icon="mdi-package-variant-closed" class="mr-2" color="primary"></v-icon>
                Produkty standardowe (Zakup jednorazowy)
              </v-card-title>
            </v-card-item>
            <v-table class="px-4">
              <tbody>
                <tr v-for="item in regularProducts" :key="item.id">
                  <td class="font-weight-medium py-4">{{ item.name }}</td>
                  <td class="text-center text-medium-emphasis">{{ item.price }} PLN</td>
                  <td class="text-center">Ilość: {{ item.quantity }}</td>
                  <td class="text-right font-weight-bold text-primary">{{ item.price * item.quantity }} PLN</td>
                  <td class="text-center">
                    <v-btn icon="mdi-trash-can-outline" variant="text" color="error" density="comfortable" @click="cart.removeItem(item.id)"></v-btn>
                  </td>
                </tr>
              </tbody>
            </v-table>
          </v-card>

          <v-card v-if="subscriptions.length > 0" class="border-thin rounded-lg" elevation="0">
            <v-card-item class="bg-purple-lighten-5 py-3">
              <v-card-title class="text-subtitle-1 font-weight-bold d-flex align-center">
                <v-icon icon="mdi-refresh" class="mr-2" color="purple"></v-icon>
                Subskrypcje odnawialne (Płatność cykliczna)
              </v-card-title>
            </v-card-item>
            <v-table class="px-4">
              <tbody>
                <tr v-for="item in subscriptions" :key="item.id">
                  <td class="font-weight-medium py-4">
                    {{ item.name }}
                    <span class="text-caption text-purple d-block font-weight-bold">Odnawiane co miesiąc</span>
                  </td>
                  <td class="text-center text-medium-emphasis">{{ item.price }} PLN / mies.</td>
                  <td class="text-center">Ilość: {{ item.quantity }}</td>
                  <td class="text-right font-weight-bold text-purple">{{ item.price * item.quantity }} PLN</td>
                  <td class="text-center">
                    <v-btn icon="mdi-trash-can-outline" variant="text" color="error" density="comfortable" @click="cart.removeItem(item.id)"></v-btn>
                  </td>
                </tr>
              </tbody>
            </v-table>
          </v-card>

          <v-card v-if="memberships.length > 0" class="border-thin rounded-lg" elevation="0">
            <v-card-item class="bg-amber-lighten-5 py-3">
              <v-card-title class="text-subtitle-1 font-weight-bold d-flex align-center">
                <v-icon icon="mdi-card-account-details-star" class="mr-2" color="amber-darken-2"></v-icon>
                Programy członkowskie (Membership)
              </v-card-title>
            </v-card-item>
            <v-table class="px-4">
              <tbody>
                <tr v-for="item in memberships" :key="item.id">
                  <td class="font-weight-medium py-4">
                    {{ item.name }}
                    <span class="text-caption text-amber-darken-3 d-block font-weight-bold">Konto Premium / Dostęp VIP</span>
                  </td>
                  <td class="text-center text-medium-emphasis">{{ item.price }} PLN</td>
                  <td class="text-center">Ilość: {{ item.quantity }}</td>
                  <td class="text-right font-weight-bold text-amber-darken-2">{{ item.price * item.quantity }} PLN</td>
                  <td class="text-center">
                    <v-btn icon="mdi-trash-can-outline" variant="text" color="error" density="comfortable" @click="cart.removeItem(item.id)"></v-btn>
                  </td>
                </tr>
              </tbody>
            </v-table>
          </v-card>

        </div>
      </v-col>

      <v-col cols="12" lg="4">
        <v-card class="border-thin rounded-lg pa-6 bg-grey-lighten-5" elevation="0">
          <h2 class="text-h5 font-weight-bold mb-4">Podsumowanie</h2>
          
          <v-divider class="mb-4"></v-divider>
          
          <div v-if="regularProducts.length > 0" class="d-flex justify-between mb-2 text-body-2 text-medium-emphasis">
            <span>Produkty jednorazowe:</span>
            <span>{{ regularProducts.reduce((acc, i) => acc + (i.price * i.quantity), 0) }} PLN</span>
          </div>

          <div v-if="subscriptions.length > 0" class="d-flex justify-between mb-2 text-body-2 text-purple font-weight-medium">
            <span>Subskrypcje (Suma):</span>
            <span>{{ subscriptions.reduce((acc, i) => acc + (i.price * i.quantity), 0) }} PLN/mc</span>
          </div>

          <div v-if="memberships.length > 0" class="d-flex justify-between mb-2 text-body-2 text-amber-darken-3 font-weight-medium">
            <span>Pakiety Membership:</span>
            <span>{{ memberships.reduce((acc, i) => acc + (i.price * i.quantity), 0) }} PLN</span>
          </div>

          <v-divider class="my-4"></v-divider>

          <div class="d-flex justify-between align-end mb-6">
            <span class="text-h6 font-weight-bold">Razem dzisiaj:</span>
            <span class="text-h5 font-weight-black text-primary">{{ cart.totalPrice }} PLN</span>
          </div>

          <v-btn color="primary" size="large" block class="py-3 font-weight-bold text-uppercase" @click="handleCheckout">
            Przejdź do kasy
          </v-btn>
        </v-card>
      </v-col>

    </v-row>
  </v-container>
</template>

<style scoped>
.justify-between {
  justify-content: space-between;
}
.gap-6 {
  gap: 24px;
}
</style>
