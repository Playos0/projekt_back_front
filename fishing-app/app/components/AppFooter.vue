<script setup lang="ts">
import { Icon } from '@iconify/vue'
const socialIcons = ['mdi:facebook', 'mdi:twitter', 'mdi:instagram', 'mdi:youtube']
</script>

<template>
  <v-footer class="bg-grey-darken-4 text-white d-flex flex-column py-6">
    <div class="d-flex justify-center mb-4">
      <v-btn v-for="icon in socialIcons" :key="icon" class="mx-2">
        <Icon :icon="icon" width="24" height="24" />
      </v-btn>
    </div>
    <p class="text-center w-50 mb-4">
      Twój kompleksowy asystent wędkarski. Łączymy pasję do wędkarstwa z nowoczesną technologią, dostarczając miłośnikom
      tego sportu zintegrowaną platformę. Znajdziesz u nas nie tylko profesjonalny sprzęt, ale również interaktywną mapę
      najlepszych łowisk oraz szczegółową encyklopedię gatunków ryb.
    </p>
    <div class="text-center text-sm text-grey-lighten-1">
      Copyright © 2026 Wędkarski Świat | Wszelkie prawa zastrzeżone
    </div>
  </v-footer>
</template>

<style scoped></style>
