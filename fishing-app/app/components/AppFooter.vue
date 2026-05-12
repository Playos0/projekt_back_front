<script setup lang="ts">
import { Icon } from "@iconify/vue";
const socialIcons = [
  "mdi:facebook",
  "mdi:twitter",
  "mdi:instagram",
  "mdi:youtube",
];
</script>

<template>
  <v-footer class="bg-grey-darken-4 text-white d-flex flex-column py-6">
    <div class="d-flex justify-center mb-4">
      <v-btn v-for="icon in socialIcons" :key="icon" class="mx-2">
        <Icon :icon="icon" width="24" height="24" />
      </v-btn>
    </div>
    <div class="text-center w-50 mb-4">
      Odkąd pamiętam mój stary był fanatykiem leczo. Odkąd k**wa pamiętam tylko
      to gotował. Zaczęło się niewinnie, jakoś za komuny jak pojechali z matką
      do Budapesztu. Stary wręcz zachłysnął się kulturą Madziarów i zapragnął
      przenieść ją na nasz grunt. Pół mieszkania zaje**ne papryką, cebulą i
      przecierem pomidorowym, najgorzej.
    </div>
    <div class="text-center text-sm text-grey-lighten-1">
      Copyright © 2026 Wędkarski Świat | Wszelkie prawa zastrzeżone
    </div>
  </v-footer>
</template>

<style scoped></style>
